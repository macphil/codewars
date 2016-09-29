using System;
using NUnit.Framework;

namespace codewars
{
    public class heavy_metal_umlauts
    {
        [Test]
        [TestCase("Ännöüncïng thë Mäcböök Äïr Güïtär", ExpectedResult = "Announcing the Macbook Air Guitar")]
        [TestCase("Fäcëböök ïntrödücës nëw hëävÿ mëtäl rëäctïön büttöns", ExpectedResult = "Facebook introduces new heavy metal reaction buttons")]
        [TestCase("Ströng sälës öf Gööglë's VR Mëtälhëädsëts sënd tëch stöck prïcës söärïng", ExpectedResult = "Strong sales of Google's VR Metalheadsets send tech stock prices soaring")]
        [TestCase("Vëgän Bläck Mëtäl Chëf hïts thë bïg tïmë ön Ämäzön TV", ExpectedResult = "Vegan Black Metal Chef hits the big time on Amazon TV")]
        public string heavy_metal_umlauts_Tests(string actual) => HeavyMetalUmlauts(actual);

        private string HeavyMetalUmlauts(string actual)
        {
            return actual;
        }
    }
}