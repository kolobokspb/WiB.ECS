using NUnit.Framework;
using WiB.Variant;

namespace WiB.Core.Test
{
    [TestFixture]
    public class VariantBinaryTest
    {
        [Test]
        public void Test0()
        {
            var obj1 = Var.GetObject("a");
            
            obj1.Add("n", null);
            obj1.Add("b", true);
            obj1.Add("i", 100);
            obj1.Add("f", 1.0f);
            obj1.Add("s", "asd");
            obj1.Add("l", Var.GetList("1",3,4.0f, true));
            obj1.Add("vt", VariantType.Dictionary);

            int size1 = VBinary.GetSize(obj1);
            var buffer1 = new byte[size1];
            VBinary.ToBytes(buffer1, 0, obj1);

            var obj2 = VBinary.ToVariant(buffer1, 0);
            int size2 = VBinary.GetSize(obj2);
            var buffer2 = new byte[size2];
            VBinary.ToBytes(buffer2, 0, obj2);
            
            Assert.That(Memory.Memcmp(buffer1, buffer2));
        }    
    }
}