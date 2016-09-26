using NUnit.Framework;

namespace codewars.Mumbling
{
    public class MumblingTests
    {
        [Test]
        [TestCase("ZpglnRxqenU", ExpectedResult = "Z-Pp-Ggg-Llll-Nnnnn-Rrrrrr-Xxxxxxx-Qqqqqqqq-Eeeeeeeee-Nnnnnnnnnn-Uuuuuuuuuuu")]
        [TestCase("NyffsGeyylB", ExpectedResult = "N-Yy-Fff-Ffff-Sssss-Gggggg-Eeeeeee-Yyyyyyyy-Yyyyyyyyy-Llllllllll-Bbbbbbbbbbb")]
        [TestCase("MjtkuBovqrU", ExpectedResult = "M-Jj-Ttt-Kkkk-Uuuuu-Bbbbbb-Ooooooo-Vvvvvvvv-Qqqqqqqqq-Rrrrrrrrrr-Uuuuuuuuuuu")]
        [TestCase("EvidjUnokmM", ExpectedResult = "E-Vv-Iii-Dddd-Jjjjj-Uuuuuu-Nnnnnnn-Oooooooo-Kkkkkkkkk-Mmmmmmmmmm-Mmmmmmmmmmm")]
        [TestCase("HbideVbxncC", ExpectedResult = "H-Bb-Iii-Dddd-Eeeee-Vvvvvv-Bbbbbbb-Xxxxxxxx-Nnnnnnnnn-Cccccccccc-Ccccccccccc")]
        [TestCase("Schrööööder", ExpectedResult = "S-Cc-Hhh-Rrrr-Ööööö-Öööööö-Ööööööö-Öööööööö-Ddddddddd-Eeeeeeeeee-Rrrrrrrrrrr")]
        [TestCase("Philip", ExpectedResult = "P-Hh-Iii-Llll-Iiiii-Pppppp")]
        [TestCase("Jawhar", ExpectedResult = "J-Aa-Www-Hhhh-Aaaaa-Rrrrrr")]
        [TestCase(@"@.ß*1", ExpectedResult = "@-..-ßßß-****-11111")]
        public string MumblingTest(string actual)
        {
            return MumblingKata.Mumble(actual);
        }
    }
}