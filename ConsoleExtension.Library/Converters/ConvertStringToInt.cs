using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Converters;

public static class ConvertStringToInt
{
    public static IResult<int> ConvertToInt(this string inputString, int defaultValue = 0)
    {
        bool isSuccessful = int.TryParse(inputString, out int value);

        IResult<int> result = ResultFactory<int>.Create(value, defaultValue, isSuccessful);

        if (isSuccessful == false)
        {
            result.AddResultMessage($"Could not convert string. {inputString} is not in a valid Integer format!");
        }
        return result;
    }
}
