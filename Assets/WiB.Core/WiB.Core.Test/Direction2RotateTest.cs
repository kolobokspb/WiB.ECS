using NUnit.Framework;
using WiB.Math2;

namespace WiB.Core.Test
{
    [TestFixture]
    public class Direction2RotateTest
    {
        //*****************************************************************************************
        [Test]
        public void Direction2RightAngle0FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle0, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2RightAngle90FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle90, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2RightAngle180FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle180, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2RightAngle270FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle270, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2TopAngle0FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle0, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2TopAngle90FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle90, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2TopAngle180FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle180, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2TopAngle270FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle270, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2LeftAngle0FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle0, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2LeftAngle90FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle90, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2LeftAngle180FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle180, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2LeftAngle270FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle270, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2BottomAngle0FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle0, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2BottomAngle90FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle90, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2BottomAngle180FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle180, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2BottomAngle270FlipNo()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle270, Flip2.No));
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        //*****************************************************************************************
        [Test]
        public void Direction2RightAngle0FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle0, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2RightAngle90FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle90, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2RightAngle180FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle180, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2RightAngle270FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle270, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2TopAngle0FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle0, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2TopAngle90FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle90, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2TopAngle180FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle180, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2TopAngle270FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle270, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2LeftAngle0FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle0, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2LeftAngle90FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle90, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2LeftAngle180FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle180, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2LeftAngle270FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle270, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2BottomAngle0FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle0, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2BottomAngle90FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle90, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2BottomAngle180FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle180, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2BottomAngle270FlipYes()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle270, Flip2.Yes));
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        //*****************************************************************************************
        [Test]
        public void Direction2RightAngle0FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle0, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2RightAngle90FlipInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle90, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2RightAngle180FlipInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle180, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2RightAngle270FlipInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle270, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2TopAngle0FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle0, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2TopAngle90FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle90, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2TopAngle180FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle180, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2TopAngle270FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle270, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2LeftAngle0FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle0, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2LeftAngle90FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle90, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2LeftAngle180FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle180, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2LeftAngle270FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle270, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2BottomAngle0FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle0, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2BottomAngle90FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle90, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2BottomAngle180FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle180, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2BottomAngle270FlipNoInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle270, Flip2.No).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        //*****************************************************************************************
        [Test]
        public void Direction2RightAngle0FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle0, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2RightAngle90FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle90, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2RightAngle180FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle180, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        [Test]
        public void Direction2RightAngle270FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle270, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Right));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2TopAngle0FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle0, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2TopAngle90FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle90, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2TopAngle180FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle180, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        [Test]
        public void Direction2TopAngle270FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle270, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Top));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2LeftAngle0FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle0, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2LeftAngle90FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle90, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2LeftAngle180FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle180, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        [Test]
        public void Direction2LeftAngle270FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle270, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Left));
        }
        //-----------------------------------------------------------------------------------------
        [Test]
        public void Direction2BottomAngle0FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Bottom, new Orientation2(Rotation2.Angle0, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2BottomAngle90FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Right, new Orientation2(Rotation2.Angle90, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2BottomAngle180FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Top, new Orientation2(Rotation2.Angle180, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        [Test]
        public void Direction2BottomAngle270FlipYesInverse()
        {
            var direction = Conversion.ToDirection(Direction2.Left, new Orientation2(Rotation2.Angle270, Flip2.Yes).Inverse());
            Assert.That(direction, Is.EqualTo(Direction2.Bottom));
        }
        //*****************************************************************************************
    }
}