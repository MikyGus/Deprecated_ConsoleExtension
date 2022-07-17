using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Converters;

public static class ConvertStringToInt
{
    public static IResult<int> ConvertToInt(this string inputString, int defaultValue = 0)
    {
        bool isSuccessful = int.TryParse(inputString, out int value);

        IResult<int> result = new ResultFactory<int>().Create(defaultValue,value,isSuccessful);

        if (isSuccessful == false)
        {
            result.AddResultMessage($"Could not convert string. {inputString} is not in a valid Integer format!");
        }
        return result;

        //if (int.TryParse(inputString, out int result))
        //{
        //    return new ResultSuccess<int>(result);
        //}

        //string errorMessage = $"Could not convert string. {inputString} is not in a valid Integer format!";

        //IResult<int> FailedResult = new ResultFailed<int>(defaultValue);
        //FailedResult.AddResultMessage(errorMessage);
        //return FailedResult;

    }
}
