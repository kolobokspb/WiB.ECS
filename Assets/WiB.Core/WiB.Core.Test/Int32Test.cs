using NUnit.Framework;

namespace WiB.Core.Test
{
    [TestFixture]
    public class Int32Test
    {
        [Test]
        public void Test0()
        {
            Assert.That(Conversion.IsInt32("0", out _), Is.EqualTo(true));
            Assert.That(Conversion.IsInt32("-1", out _), Is.EqualTo(true));
            Assert.That(Conversion.IsInt32("+1", out _), Is.EqualTo(true));
            Assert.That(Conversion.IsInt32("-1.0", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsInt32("+1.0", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsInt32("-", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsInt32("+", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsInt32("-aa", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsInt32("+bb", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsInt32("-0", out _), Is.EqualTo(true));
            Assert.That(Conversion.IsInt32("+0", out _), Is.EqualTo(true));
            Assert.That(Conversion.IsInt32("0.", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsInt32(".0", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsInt32("-0..0", out _), Is.EqualTo(false));
        }    
    }
}