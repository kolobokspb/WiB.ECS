using NUnit.Framework;

namespace WiB.Core.Test
{
    [TestFixture]
    public class FloatTest
    {
        [Test]
        public void Test0()
        {
            Assert.That(Conversion.IsFloat("0.0", out _), Is.EqualTo(true));
            Assert.That(Conversion.IsFloat("-1.0", out _), Is.EqualTo(true));
            Assert.That(Conversion.IsFloat("0,0", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsFloat("-1,0", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsFloat("+", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsFloat("-", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsFloat("-aa", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsFloat("+aa00", out _), Is.EqualTo(false));
            Assert.That(Conversion.IsFloat("0", out _), Is.EqualTo(true));
            Assert.That(Conversion.IsFloat("-0", out _), Is.EqualTo(true));
            Assert.That(Conversion.IsFloat("0.", out _), Is.EqualTo(true));
            Assert.That(Conversion.IsFloat("-0..0", out _), Is.EqualTo(false));
        }    
    }
}