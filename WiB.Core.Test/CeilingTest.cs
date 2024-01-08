using NUnit.Framework;

namespace WiB.Core.Test
{
    [TestFixture]
    public class CeilingTest
    {
        [Test]
        public void Test0()
        {
            Assert.That(Math.Ceiling(-2.9f), Is.EqualTo(-2.0f));
        }

        [Test]
        public void Test1()
        {
            Assert.That(Math.Ceiling(-2.0f), Is.EqualTo(-2.0f));
        }

        [Test]
        public void Test2()
        {
            Assert.That(Math.Ceiling(-1.0f), Is.EqualTo(-1.0f));
        }

        [Test]
        public void Test3()
        {
            Assert.That(Math.Ceiling(-0.5f), Is.EqualTo(0.0f));
        }

        [Test]
        public void Test4()
        {
            Assert.That(Math.Ceiling(0.3f), Is.EqualTo(1.0f));
        }

        [Test]
        public void Test5()
        {
            Assert.That(Math.Ceiling(1.0f), Is.EqualTo(1.0f));
        }

        [Test]
        public void Test6()
        {
            Assert.That(Math.Ceiling(1.5f), Is.EqualTo(2.0f));
        }

        [Test]
        public void Test7()
        {
            Assert.That(Math.Ceiling(2.0f), Is.EqualTo(2.0f));
        }

        [Test]
        public void Test8()
        {
            Assert.That(Math.Ceiling(2.9f), Is.EqualTo(3.0f));
        }
    }
}