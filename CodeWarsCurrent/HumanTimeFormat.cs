using System.Linq;

public class HumanTimeFormat
{
    public static string formatDuration(int seconds)
    {
        if (seconds == 0)
        {
            return "now";
        }
        var humanTimeFormat = new System.Collections.Generic.List<string>
        {
            ParseForTimeUnit(seconds, TimeUnit.year, out int remainder),
            ParseForTimeUnit(remainder, TimeUnit.day, out remainder),
            ParseForTimeUnit(remainder, TimeUnit.hour, out remainder),
            ParseForTimeUnit(remainder, TimeUnit.minute, out remainder),
            ParseForTimeUnit(remainder, TimeUnit.second, out remainder)
        };

        var nonZeroComponents = humanTimeFormat.Where(x => !string.IsNullOrEmpty(x));
        var humanReadableDuration = string.Empty;

        if (nonZeroComponents.Count() > 2)
        {
            var csvComponents = nonZeroComponents.ToList().GetRange(0, nonZeroComponents.Count() - 2);
            humanReadableDuration = string.Join(", ", csvComponents) + ", ";
        }

        if (nonZeroComponents.Count() > 1)
        {
            var recentButOneComponent = nonZeroComponents.Skip(nonZeroComponents.Count() - 2).Take(1);
            humanReadableDuration += $"{recentButOneComponent.Single()} and ";
        }

        humanReadableDuration += nonZeroComponents.Last();

        return humanReadableDuration;
    }

    internal static string ParseForTimeUnit(int seconds, TimeUnit timeUnit, out int remainder)
    {
        remainder = 0;
        int number = 0;

        if (timeUnit == TimeUnit.second)
        {
            number = seconds;
        }
        else
        {
            HumanTimeFormat.EuclideanDivision(seconds, (int)timeUnit, out number, out remainder);
        }


        if (number == 0)
        {
            return string.Empty;
        }
        if (number == 1)
        {
            return $"1 {timeUnit}";
        }
        else
        {
            return $"{number} {timeUnit}s";
        }
    }


    internal static void EuclideanDivision(int divident, int divisor, out int quotient, out int remainder)
    {
        quotient = divident / divisor;
        remainder = divident % divisor;
    }
}
