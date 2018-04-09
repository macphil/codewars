namespace codewars
{
    public class Kata
    {
        public static string Justify(string str, int len)
        {
            return str;
        }

        internal static string JustifyLine(string text, int width)
        {
            int spacesToAdd = width - text.Length;
            int noOfSpaces = text.Length - text.Remove(' ').Length;
            return text;
        }

        internal static string GetWordsUpToWidth(string text, int width)
        {
            if (text.Trim().Length <= width)
            {
                return text.Trim();
            }

            var trimmedString = text.Trim().Substring(0, width);
            if (text.Trim()[width] == ' ')
            {
                return trimmedString;
            }

            var lastGap = trimmedString.LastIndexOf(' ');

            return lastGap == -1 ? trimmedString : trimmedString.Substring(0, lastGap).Trim();
        }
    }
}