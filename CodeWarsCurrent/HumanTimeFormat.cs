using System.Collections.Generic;
using System.Linq;

public class HumanTimeFormat
{
    public static string formatDuration(int seconds)
    {
        if (seconds == 0)
        {
            return "now";
        }

        var readableDurations = GetReadableDurations(seconds);

        var humanReadableDuration = JoinReadableDurations(readableDurations);

        return humanReadableDuration;
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

    internal static string JoinReadableDurations(IEnumerable<string> readableDurations)
    {
        var joinedReadableDurations = string.Empty;
        switch (readableDurations.Count())
        {
            case 5:
            case 4:
            case 3:
                var lastButTwoComponents = readableDurations.ToList().GetRange(0, readableDurations.Count() - 2);
                joinedReadableDurations = string.Join(", ", lastButTwoComponents) + ", ";
                goto case 2;
            case 2:
                var lastButOneComponent = readableDurations.Skip(readableDurations.Count() - 2).Take(1);
                joinedReadableDurations += $"{lastButOneComponent.Single()} and ";
                goto default;
            default:
                joinedReadableDurations += readableDurations.Last();
                break;
        }

        return joinedReadableDurations;
    }

    internal static string ReadableDuration(int seconds, TimeUnit timeUnit, out int remainder)
    {
        remainder = 0;
        int number = timeUnit == TimeUnit.second ? seconds : HumanTimeFormat.EuclideanDivision(seconds, (int)timeUnit, out remainder);

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

    internal static int EuclideanDivision(int divident, int divisor, out int remainder)
    {
        int quotient = divident / divisor;
        remainder = divident % divisor;

        return quotient;
    }
}

internal enum TimeUnit
{
    second = 1,
    minute = 60,
    hour = 60 * 60,
    day = 60 * 60 * 24,
    year = 60 * 60 * 24 * 365
}
