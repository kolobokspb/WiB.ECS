﻿using NUnit.Framework;

namespace WiB.Core.Test
{
    [TestFixture]
    public class TruncateTest
    {
        [Test]
        public void Test0()
        {
            Assert.That(Math.Truncate(-2.9f), Is.EqualTo(-2.0f));
        }
        [Test]
        public void Test1()
        {
            Assert.That(Math.Truncate(-2.0f), Is.EqualTo(-2.0f));
        }
        [Test]
        public void Test2()
        {
            Assert.That(Math.Truncate(-1.0f), Is.EqualTo(-1.0f));
        }
        [Test]
        public void Test3()
        {
            Assert.That(Math.Truncate(-0.5f), Is.EqualTo(0.0f));
        }
        [Test]
        public void Test4()
        {
            Assert.That(Math.Truncate(0.3f), Is.EqualTo(0.0f));
        }
        [Test]
        public void Test5()
        {
            Assert.That(Math.Truncate(1.0f), Is.EqualTo(1.0f));
        }
        [Test]
        public void Test6()
        {
            Assert.That(Math.Truncate(1.5f), Is.EqualTo(1.0f));
        }
        [Test]
        public void Test7()
        {
            Assert.That(Math.Truncate(2.0f), Is.EqualTo(2.0f));
        }
        [Test]
        public void Test8()
        {
            Assert.That(Math.Truncate(2.9f), Is.EqualTo(2.0f));
        }    
    }
}