using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WiB.Variant
{
    public static class VBinary
    {
        public static int GetSize([NotNull] Var sources)
        {
            return VBinarySize.GetSize(sources);
        }

        public static void ToBytes([NotNull] byte[] destination, int destinationOffset, [NotNull] Var sources)
        {
            VBinaryPacker.ToBytes(destination, destinationOffset, sources);
        }

        public static Var ToVariant([NotNull] byte[] sources, int sourcesOffset)
        {
            return VBinaryUnpacker.ToVariant(sources, sourcesOffset);
        }

        public static async ValueTask ToFileAsync(
            [NotNull] string path, 
            [NotNull] Var sources,
            CancellationToken cancellationToken = default)
        {
            await Task.Run(async () =>
            {
                await using var fs = new FileStream(
                    path: path,
                    mode: FileMode.OpenOrCreate,
                    access: FileAccess.Write,
                    share: FileShare.Read,
                    bufferSize: 4096,
                    useAsync: true);
                
                cancellationToken.ThrowIfCancellationRequested();
                
                var size = GetSize(sources);
                var buffer = new byte[size];
                ToBytes(buffer, 0, sources);
                await fs.WriteAsync(buffer.AsMemory(0, size), cancellationToken);
                
            }, cancellationToken);
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
                
                var buffer = new byte[fs.Length];
                await fs.ReadExactlyAsync(buffer.AsMemory(), cancellationToken);
                return ToVariant(buffer, 0);

            }, cancellationToken);
        }
    }
}