using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WiB.Variant
{
    public static class VJson
    {
        private const string Type = "@Type";

        private static JToken ToJson([NotNull] Var variant)
        {
            switch (variant.VariantType)
            {
                case VariantType.Null: return JValue.CreateNull();
                case VariantType.Bool: return new JValue((bool)variant);
                case VariantType.Int32: return new JValue((int)variant);
                case VariantType.Float: return new JValue((float)variant);
                case VariantType.String: return new JValue((string)variant);
                case VariantType.List:
                {
                    var jArray = new JArray();
                    var vList = (VList)variant;

                    foreach (var data in vList)
                        jArray.Add(ToJson(data));

                    return jArray;
                }
                case VariantType.Object:
                {
                    var jObject = new JObject();
                    var vObject = (VObject)variant;

                    foreach (var data in vObject)
                        jObject.Add(data.Key, ToJson(data.Value));

                    jObject.Add(Type, (string)vObject);

                    return jObject;
                }
                case VariantType.Dictionary:
                {
                    var jObject = new JObject();
                    var vDictionary = (VDictionary)variant;

                    foreach (var data in vDictionary)
                        jObject.Add(data.Key, ToJson(data.Value));

                    return jObject;
                }

                default: throw new NotSupportedException($"Type: {variant.GetType().Name} not not supported");
            }
        }

        public static async ValueTask ToFileAsync(
            [NotNull] string path,
            [NotNull] Var variant,
            CancellationToken cancellationToken = default)
        {
            await Task.Run(async () =>
            {
                var data = ToString(variant);

                cancellationToken.ThrowIfCancellationRequested();

                await using var fs = new FileStream(
                    path: path,
                    mode: FileMode.OpenOrCreate,
                    access: FileAccess.Write,
                    share: FileShare.Read,
                    bufferSize: 4096,
                    useAsync: true);
                
                cancellationToken.ThrowIfCancellationRequested();

                await using var sw = new StreamWriter(fs);
                await sw.WriteAsync(data.AsMemory(), cancellationToken).ConfigureAwait(false);
                
            }, cancellationToken);
        }
        
        public static string ToString([NotNull] Var variant)
        {
            ArgumentNullException.ThrowIfNull(variant);

            var token = ToJson(variant);

            var sb = new StringBuilder();
            var sw = new StringWriter(sb);

            using var jtw = new JsonTextWriter(sw);

            jtw.Formatting = Formatting.Indented;
            jtw.IndentChar = ' ';
            jtw.Indentation = 4;

            token.WriteTo(jtw);

            return sb.ToString();
        }

        private static Var FromJson([NotNull] JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                {
                    var jObject = token.ToObject<JObject>()!;

                    if (jObject.TryGetValue(Type, out var type))
                    {
                        var vObject = Var.GetObject(type.ToObject<string>()!);

                        foreach (var data in jObject)
                            vObject.Add(data.Key, FromJson(data.Value!));

                        vObject.Remove(Type);

                        return vObject;
                    }
                    else
                    {
                        var vDictionary = Var.GetDictionary();

                        foreach (var data in jObject)
                            vDictionary.Add(data.Key, FromJson(data.Value!));

                        return vDictionary;
                    }
                }
                case JTokenType.Array:
                {
                    var jArray = token.ToObject<JArray>()!;
                    var vList = Var.GetList();

                    foreach (var data in jArray)
                        vList.Add(FromJson(data));

                    return vList;
                }
                case JTokenType.Null: return Var.GetNull();
                case JTokenType.Boolean: return token.ToObject<bool>();
                case JTokenType.Integer: return token.ToObject<int>();
                case JTokenType.Float: return token.ToObject<float>();
                case JTokenType.String: return token.ToObject<string>();
                case JTokenType.Bytes: return token.ToObject<byte[]>();
                default: throw new NotSupportedException($"Type: {token.Type} not not supported.");
            }
        }

        public static async ValueTask<Var> FromFileAsync(
            [NotNull] string path,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(async () =>
            {
                await using var fs = new FileStream(
                    path: path,
                    mode: FileMode.Open,
                    access: FileAccess.Read,
                    share: FileShare.Read,
                    bufferSize: 4096,
                    useAsync: true);

                cancellationToken.ThrowIfCancellationRequested();
                
                var sr = new StreamReader(fs);
                var data = await sr.ReadToEndAsync(cancellationToken).ConfigureAwait(false);
                
                return FromString(data);
            }, cancellationToken);
        }
        
        public static Var FromString([NotNull] string text)
        {
            ArgumentException.ThrowIfNullOrEmpty(text, nameof(text));

            var sr = new StringReader(text);
            using var jtr = new JsonTextReader(sr);

            var token = JToken.ReadFrom(jtr);
            return FromJson(token);
        }
    }
}