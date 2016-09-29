using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace codewars
{
    public class heavy_metal_umlauts
    {
        [Test]
        [TestCase("Announcing the Macbook Air Guitar", ExpectedResult = "Ännöüncïng thë Mäcböök Äïr Güïtär")]
        [TestCase("Facebook introduces new heavy metal reaction buttons", ExpectedResult = "Fäcëböök ïntrödücës nëw hëävÿ mëtäl rëäctïön büttöns")]
        [TestCase("Strong sales of Google's VR Metalheadsets send tech stock prices soaring", ExpectedResult = "Ströng sälës öf Gööglë's VR Mëtälhëädsëts sënd tëch stöck prïcës söärïng")]
        [TestCase("Vegan Black Metal Chef hits the big time on Amazon TV", ExpectedResult = "Vëgän Bläck Mëtäl Chëf hïts thë bïg tïmë ön Ämäzön TV")]
        public string heavy_metal_umlauts_Tests(string actual) => HeavyMetalUmlauts(actual);

        private string HeavyMetalUmlauts(string boringText)
        {
            var umlate = new Dictionary<char, char>();
            umlate.Add('A', 'Ä');
            umlate.Add('O', 'Ö');
            umlate.Add('a', 'ä');
            umlate.Add('o', 'ö');
            umlate.Add('E', 'Ë');
            umlate.Add('U', 'Ü');
            umlate.Add('e', 'ë');
            umlate.Add('u', 'ü');
            umlate.Add('I', 'Ï');
            umlate.Add('Y', 'Ÿ');
            umlate.Add('i', 'ï');
            umlate.Add('y', 'ÿ');

            var heavyMetalUmlauts = new StringBuilder();

            foreach (char c in boringText.ToCharArray().ToList())
            {
                heavyMetalUmlauts.Append((umlate.ContainsKey(c) ? umlate[c] : c));
            }

            return heavyMetalUmlauts.ToString();
        }
    }
}