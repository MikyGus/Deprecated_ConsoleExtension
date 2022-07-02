using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public static class VerifyIntOverValue
    {
        public static IResult<int> VerifyOver(this IResult<int> valueToCompare, int compareAgainst)
        {
            if (valueToCompare.Value > compareAgainst)
            {
                if (valueToCompare is IResultSuccess<int> resultSuccess)
                {
                    return resultSuccess;
                }
                return new ResultSuccess<int>(valueToCompare.Value);
            }


            string errorMessage = $"Rule violation: {valueToCompare.Value} is not over {compareAgainst}.";
            if (valueToCompare is IResultFailed<int> failedResult)
            {
                failedResult.AddResultMessage(errorMessage);
                return failedResult;
            }

            IResult<int> newFailedResult = new ResultFailed<int>(valueToCompare.Value);
            newFailedResult.AddResultMessage(errorMessage);
            return newFailedResult;
        }
    }
}
