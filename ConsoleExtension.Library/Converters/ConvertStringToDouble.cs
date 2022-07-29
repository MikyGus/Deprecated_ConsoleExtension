using ConsoleExtension.Library.Result;
using System.Globalization;

namespace ConsoleExtension.Library.Converters;

public static class ConvertStringToDouble
{
    public static IResult<double> ConvertToDouble(this string inputString, CultureInfo? cultureInfo = null, double defaultValue = 0)
    {
        cultureInfo ??= CultureInfo.CreateSpecificCulture("en-GB");

        bool isSuccessful = double.TryParse(inputString, NumberStyles.Any, cultureInfo, out double value);

        IResult<double> result = ResultFactory<double>.Create(value, defaultValue, isSuccessful);
        if (isSuccessful == false)
        {
            result.AddResultMessage($"Could not convert the string [{inputString}] to a double. It's not in a double-format.");
        }
        return result;
    }
}
