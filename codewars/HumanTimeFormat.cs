using System.Collections.Generic;
using System.Linq;

public enum TimeUnit
{
    second = 1,
    minute = 60,
    hour = 60 * 60,
    day = 60 * 60 * 24,
    year = 60 * 60 * 24 * 365
}

public class HumanTimeFormat
{
    public static string formatDuration(int seconds)
    {
        return seconds == 0 ? "now" : JoinReadableDurations(GetReadableDurations(seconds));
    }

    internal static IEnumerable<string> GetReadableDurations(int seconds)
    {
        return new List<string>
        {
            ReadableDuration(seconds, TimeUnit.year, out int remainder),
            ReadableDuration(remainder, TimeUnit.day, out remainder),
            ReadableDuration(remainder, TimeUnit.hour, out remainder),
            ReadableDuration(remainder, TimeUnit.minute, out remainder),
            ReadableDuration(remainder, TimeUnit.second, out remainder)
        }.Where(x => !string.IsNullOrEmpty(x));
    }

    internal static string ReadableDuration(int seconds, TimeUnit timeUnit, out int remainder)
    {
        int number = seconds / (int)timeUnit;
        remainder = seconds % (int)timeUnit;

        switch (number)
        {
            case 0:
                return string.Empty;
            case 1:
                return $"1 {timeUnit}";
            default:
                return $"{number} {timeUnit}s";
        }
    }

    internal static string JoinReadableDurations(IEnumerable<string> readableDurations)
    {
        var joinedReadableDurations = string.Join(", ", readableDurations);

        var lastComma = joinedReadableDurations.LastIndexOf(", ", System.StringComparison.Ordinal);

        return lastComma == -1 ? joinedReadableDurations :
                                joinedReadableDurations
                                    .Remove(lastComma, 1)
                                    .Insert(lastComma, " and");
    }
}
