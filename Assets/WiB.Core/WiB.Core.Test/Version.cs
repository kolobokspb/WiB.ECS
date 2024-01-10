using NUnit.Framework;

namespace WiB.Core.Test
{
    [TestFixture]
    public class VersionTest
    {
        [Test]
        public void TestIsVersion()
        {
            Assert.That(Conversion.IsVersion("0.0"), Is.EqualTo(true));
            Assert.That(Conversion.IsVersion("1.0"), Is.EqualTo(true));
            Assert.That(Conversion.IsVersion("000.000"), Is.EqualTo(true));
            Assert.That(Conversion.IsVersion("1000.000"), Is.EqualTo(false));
            Assert.That(Conversion.IsVersion("000.1000"), Is.EqualTo(false));
            Assert.That(Conversion.IsVersion("a.000"), Is.EqualTo(false));
            Assert.That(Conversion.IsVersion("000.a"), Is.EqualTo(false));
        }
        
        [Test]
        public void TestHashCode()
        {
            Assert.That(new Version("0.0").GetHashCode(), Is.EqualTo(0));
            Assert.That(new Version("0.1").GetHashCode(), Is.EqualTo(1));
            Assert.That(new Version("1.0").GetHashCode(), Is.EqualTo(1000));
            Assert.That(new Version("1.1").GetHashCode(), Is.EqualTo(1001));
            Assert.That(new Version("999.999").GetHashCode(), Is.EqualTo(999_999));

        }
        
        [Test]
        public void TestOperators()
        {
            var v1 = new Version("0.1");
            var v2 = new Version("0.1");
            var v3 = new Version("0.2");
            
            Assert.That(v1 == v2, Is.EqualTo(true));
            Assert.That(v1 != v2, Is.EqualTo(false));
            Assert.That(v1 <= v2, Is.EqualTo(true));
            Assert.That(v1 >= v2, Is.EqualTo(true));
            Assert.That(v1 <= v3, Is.EqualTo(true));
            Assert.That(v1 <= v3, Is.EqualTo(true));
            Assert.That(v1 < v3, Is.EqualTo(true));
            Assert.That(v1 > v3, Is.EqualTo(false));
        }
    }
}
