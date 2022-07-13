using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public class BaseVerify
    {
        public static IResult<T> VerifyValue<T>(
            IResult<T> valueToCompare,
            bool isCompareValueSuccess,
            string messageOnFailure)
        {
            if (isCompareValueSuccess == false)
            {
                valueToCompare.AddResultMessage($"Rule violation: {messageOnFailure}");
            }
            if (valueToCompare is IResultSuccess<int> && isCompareValueSuccess)
            {
                return valueToCompare.ConvertToSuccess();
            }
            return valueToCompare.ConvertToFail();
        }
    }
}
