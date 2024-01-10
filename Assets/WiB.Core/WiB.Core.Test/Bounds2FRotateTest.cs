using NUnit.Framework;
using WiB.Math2;

namespace WiB.Core.Test
{
    [TestFixture]
    public class Bounds2FRotateTest
    {
        [Test]
        public void Bounds2FFlipNo()
        {
            var b1 = Conversion.ToBounds2F(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f), new Vector2F(1.0f, 0.0f), new Orientation2(Rotation2.Angle0, Flip2.No));
            Assert.That(b1, Is.EqualTo(new Bounds2F(2.0f, 3.0f, 3.0f, 4.0f)));

            var b2 = Conversion.ToBounds2F(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f), new Vector2F(1.0f, 0.0f), new Orientation2(Rotation2.Angle90, Flip2.No));
            Assert.That(b2, Is.EqualTo(new Bounds2F(-3.0f, 1.0f, -2.0f, 2.0f)));

            var b3 = Conversion.ToBounds2F(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f), new Vector2F(1.0f, 0.0f), new Orientation2(Rotation2.Angle180, Flip2.No));
            Assert.That(b3, Is.EqualTo(new Bounds2F(-1.0f, -4.0f, 0.0f, -3.0f)));

            var b4 = Conversion.ToBounds2F(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f), new Vector2F(1.0f, 0.0f), new Orientation2(Rotation2.Angle270, Flip2.No));
            Assert.That(b4, Is.EqualTo(new Bounds2F(4.0f, -2.0f, 5.0f, -1.0f)));
        }

        [Test]
        public void Bounds2FFlipYes()
        {
            var b1 = Conversion.ToBounds2F(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f), new Vector2F(1.0f, 0.0f), new Orientation2(Rotation2.Angle0, Flip2.Yes));
            Assert.That(b1, Is.EqualTo(new Bounds2F(-1.0f, 3.0f, 0.0f, 4.0f)));

            var b2 = Conversion.ToBounds2F(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f), new Vector2F(1.0f, 0.0f), new Orientation2(Rotation2.Angle90, Flip2.Yes));
            Assert.That(b2, Is.EqualTo(new Bounds2F(-3.0f, -2.0f, -2.0f, -1.0f)));

            var b3 = Conversion.ToBounds2F(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f), new Vector2F(1.0f, 0.0f), new Orientation2(Rotation2.Angle180, Flip2.Yes));
            Assert.That(b3, Is.EqualTo(new Bounds2F(2.0f, -4.0f, 3.0f, -3.0f)));

            var b4 = Conversion.ToBounds2F(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f), new Vector2F(1.0f, 0.0f), new Orientation2(Rotation2.Angle270, Flip2.Yes));
            Assert.That(b4, Is.EqualTo(new Bounds2F(4.0f, 1.0f, 5.0f, 2.0f)));
        }

        [Test]
        public void Bounds2FFlipNoInverse()
        {
            var b1 = Conversion.ToBounds2F(new Bounds2F(2.0f, 3.0f, 3.0f, 4.0f), new Vector2F(1.0f, 0.0f).Inverse(), new Orientation2(Rotation2.Angle0, Flip2.No).Inverse());
            Assert.That(b1, Is.EqualTo(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f)));

            var b2 = Conversion.ToBounds2F(new Bounds2F(-3.0f, 1.0f, -2.0f, 2.0f), new Vector2F(1.0f, 0.0f).Inverse(), new Orientation2(Rotation2.Angle90, Flip2.No).Inverse());
            Assert.That(b2, Is.EqualTo(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f)));

            var b3 = Conversion.ToBounds2F(new Bounds2F(-1.0f, -4.0f, 0.0f, -3.0f), new Vector2F(1.0f, 0.0f).Inverse(), new Orientation2(Rotation2.Angle180, Flip2.No).Inverse());
            Assert.That(b3, Is.EqualTo(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f)));

            var b4 = Conversion.ToBounds2F(new Bounds2F(4.0f, -2.0f, 5.0f, -1.0f), new Vector2F(1.0f, 0.0f).Inverse(), new Orientation2(Rotation2.Angle270, Flip2.No).Inverse());
            Assert.That(b4, Is.EqualTo(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f)));
        }

        [Test]
        public void Bounds2FFlipYesInverse()
        {
            var b1 = Conversion.ToBounds2F(new Bounds2F(-1.0f, 3.0f, 0.0f, 4.0f), new Vector2F(1.0f, 0.0f).Inverse(), new Orientation2(Rotation2.Angle0, Flip2.Yes).Inverse());
            Assert.That(b1, Is.EqualTo(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f)));
    
            var b2 = Conversion.ToBounds2F(new Bounds2F(-3.0f, -2.0f, -2.0f, -1.0f), new Vector2F(1.0f, 0.0f).Inverse(), new Orientation2(Rotation2.Angle90, Flip2.Yes).Inverse());
            Assert.That(b2, Is.EqualTo(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f)));
            
            var b3 = Conversion.ToBounds2F(new Bounds2F(2.0f, -4.0f, 3.0f, -3.0f), new Vector2F(1.0f, 0.0f).Inverse(), new Orientation2(Rotation2.Angle180, Flip2.Yes).Inverse());
            Assert.That(b3, Is.EqualTo(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f)));

            var b4 = Conversion.ToBounds2F(new Bounds2F(4.0f, 1.0f, 5.0f, 2.0f), new Vector2F(1.0f, 0.0f).Inverse(), new Orientation2(Rotation2.Angle270, Flip2.Yes).Inverse());
            Assert.That(b4, Is.EqualTo(new Bounds2F(1.0f, 3.0f, 2.0f, 4.0f)));
        }  
    }
}