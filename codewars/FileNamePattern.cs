using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace codewars
{
    public class FileNamePattern
    {
        [Test]
        [TestCase("bla_{yyyy}", ExpectedResult = "bla_2016")]
        [TestCase(" ", ExpectedResult = "_")]
        [TestCase("bla", ExpectedResult = "bla")]
        [TestCase("{yyyy}", ExpectedResult = "2016")]
        [TestCase("_{", ExpectedResult = "_{")]
        [TestCase("_}", ExpectedResult = "_}")]
        [TestCase("_{}", ExpectedResult = "_{}")]
        [TestCase(":", ExpectedResult = "_")]
        [TestCase("huhu:haha", ExpectedResult = "huhu_haha")]
        [TestCase("_{yy:yy}", ExpectedResult = "_16_16")]
        [TestCase("_{yy:YY}", ExpectedResult = "_16_YY")]
        public string FileNamePattern_Tests(string actual) => IsFilenameValid(actual);

        private static string IsFilenameValid(string actual)
        {
            if (string.IsNullOrWhiteSpace(actual)) return "_";

            // nur so zum spaß :-=
            var validPattern = new Regex(@"[^{]*{{0,1}([^}]*)}{0,1}.*");
            var match = validPattern.Match(actual);
            if (match.Success || match.Groups.Count == 2)
            {
                var dateTimePattern = match.Groups[1].Value;
            }

            var bracketOpen = actual.IndexOf('{');
            if (bracketOpen >= 0)
            {
                var bracketClose = actual.IndexOf('}', bracketOpen);
                if (bracketClose > bracketOpen + 1)
                {
                    var dateTimePattern = actual.Substring(bracketOpen + 1, bracketClose - bracketOpen - 1);
                    var dateIn2016 = new DateTime(2016, 6, 10);
                    actual = actual.Substring(0, bracketOpen) + dateIn2016.ToString(dateTimePattern) + actual.Substring(bracketClose + 1);
                }
            }

            var dirtyChars = new List<char>();
            dirtyChars.Add(' ');
            dirtyChars.AddRange(Path.GetInvalidFileNameChars());
            dirtyChars.AddRange(Path.GetInvalidPathChars());
            var sanitizedString = new StringBuilder();
            foreach (char c in actual)
            {
                sanitizedString.Append(dirtyChars.Contains(c) ? '_' : c);
            }

            Console.WriteLine($"{sanitizedString}");
            return sanitizedString.ToString();
        }
    }
}