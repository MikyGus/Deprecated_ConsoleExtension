using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Converters
{
    public static class ConvertStringToInt
    {
        public static IResult<int> ConvertToInt(this string inputString, int defaultValue = 0)
        {
            if (int.TryParse(inputString, out int result))
            {
                return new ResultSuccess<int>(result);
            }

            string errorMessage = $"Could not convert string. {inputString} is not in a valid Integer format!";

            IResult<int> FailedResult = new ResultFailed<int>(defaultValue);
            FailedResult.AddResultMessage(errorMessage);
            return FailedResult;

        }
    }
}
