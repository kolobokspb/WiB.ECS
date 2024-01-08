using NUnit.Framework;

namespace WiB.Core.Test
{
    [TestFixture]
    public class PackUnpackTest
    {
        [Test]
        public void Test0()
        {
            var bytes = new byte[1000];

            byte bW = 44;
            int iW = 77;
            float fW = 12.0f;
            string sW = "dfgdfgd";
            byte[] aW = { 1, 2, 3 };

            int offsetWrite = 0;

            Memory.PackByte(bytes, ref offsetWrite, bW);
            Memory.PackInt32(bytes, ref offsetWrite, iW);
            Memory.PackFloat(bytes, ref offsetWrite, fW);
            Memory.PackString(bytes, ref offsetWrite, sW);
            Memory.PackBytes(bytes, ref offsetWrite, aW);

            int offsetRead = 0;

            var bR = Memory.UnpackByte(bytes, ref offsetRead);
            var iR = Memory.UnpackInt32(bytes, ref offsetRead);
            var fR = Memory.UnpackFloat(bytes, ref offsetRead);
            var sR = Memory.UnpackString(bytes, ref offsetRead);
            var aR = Memory.UnpackBytes(bytes, ref offsetRead);

            Assert.That(bW, Is.EqualTo(bR));
            Assert.That(iW, Is.EqualTo(iR));
            Assert.That(fW, Is.EqualTo(fR));
            Assert.That(sW, Is.EqualTo(sR));
            Assert.That(Memory.Memcmp(aW, aR));
        }
    }
}