using NUnit.Framework;
using WiB.Variant;

namespace WiB.Core.Test
{
    [TestFixture]
    public class VariantJsonTest
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
            
            var s1 = VJson.ToString(obj1);
            var obj2 = VJson.FromString(s1);
            var s2 = VJson.ToString(obj2);
            
            
            Assert.That(s1, Is.EqualTo(s2));
        }    
    }
}