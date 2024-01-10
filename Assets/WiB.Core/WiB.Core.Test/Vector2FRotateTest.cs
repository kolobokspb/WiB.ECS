using NUnit.Framework;
using WiB.Math2;

namespace WiB.Core.Test
{
    [TestFixture]
    public class Vector2FRotateTest
    {
        //*****************************************************************************************
        [Test]
        public void Vector2FRightAngle0FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle0, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FRightAngle90FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle90, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FRightAngle180FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle180, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FRightAngle270FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle270, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FTopAngle0FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle0, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FTopAngle90FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle90, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FTopAngle180FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle180, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FTopAngle270FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle270, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FLeftAngle0FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle0, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FLeftAngle90FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle90, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FLeftAngle180FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle180, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FLeftAngle270FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle270, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FBottomAngle0FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle0, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FBottomAngle90FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle90, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FBottomAngle180FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle180, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FBottomAngle270FlipNo()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle270, Flip2.No));
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        //*****************************************************************************************
        [Test]
        public void Vector2FRightAngle0FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle0, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FRightAngle90FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle90, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FRightAngle180FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle180, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FRightAngle270FlipYes()
        {
            var vec= Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle270, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FTopAngle0FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle0, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FTopAngle90FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle90, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FTopAngle180FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle180, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FTopAngle270FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle270, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FLeftAngle0FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle0, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FLeftAngle90FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle90, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FLeftAngle180FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle180, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FLeftAngle270FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle270, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FBottomAngle0FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle0, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FBottomAngle90FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle90, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FBottomAngle180FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle180, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FBottomAngle270FlipYes()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle270, Flip2.Yes));
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        //*****************************************************************************************
        [Test]
        public void Vector2FRightAngle0FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle0, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FRightAngle90FlipInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle90, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FRightAngle180FlipInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle180, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FRightAngle270FlipInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle270, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FTopAngle0FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle0, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FTopAngle90FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle90, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FTopAngle180FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle180, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FTopAngle270FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle270, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FLeftAngle0FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle0, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FLeftAngle90FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle90, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FLeftAngle180FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle180, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FLeftAngle270FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle270, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FBottomAngle0FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle0, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FBottomAngle90FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle90, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FBottomAngle180FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle180, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FBottomAngle270FlipNoInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle270, Flip2.No).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        //*****************************************************************************************
        [Test]
        public void Vector2FRightAngle0FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle0, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FRightAngle90FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle90, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FRightAngle180FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle180, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        [Test]
        public void Vector2FRightAngle270FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle270, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Right));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FTopAngle0FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle0, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FTopAngle90FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle90, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FTopAngle180FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle180, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        [Test]
        public void Vector2FTopAngle270FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle270, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Top));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FLeftAngle0FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle0, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FLeftAngle90FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle90, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FLeftAngle180FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle180, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        [Test]
        public void Vector2FLeftAngle270FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle270, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Left));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Vector2FBottomAngle0FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Bottom, new Orientation2(Rotation2.Angle0, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FBottomAngle90FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Right, new Orientation2(Rotation2.Angle90, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FBottomAngle180FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Top, new Orientation2(Rotation2.Angle180, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        [Test]
        public void Vector2FBottomAngle270FlipYesInverse()
        {
            var vec = Conversion.ToVector2F(Vector2F.Left, new Orientation2(Rotation2.Angle270, Flip2.Yes).Inverse());
            Assert.That(vec, Is.EqualTo(Vector2F.Bottom));
        }
        //*****************************************************************************************
    }
}