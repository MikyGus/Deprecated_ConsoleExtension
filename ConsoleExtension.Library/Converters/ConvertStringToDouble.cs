using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Converters
{
    public static class ConvertStringToDouble
    {
        public static IResult<double> ConvertToDouble(this string inputString, double defaultValue = 0.0)
        {
            if (double.TryParse(inputString, out double result))
            {
                return new ResultSuccess<double>(result);
            }

            string errorMessage = $"Could not convert the string [{inputString}] to a double. It's not in a double-format.";
            IResult<double> FailedResult = new ResultFailed<double>(defaultValue);
            FailedResult.AddResultMessage(errorMessage);
            return FailedResult;
        }
    }
}
