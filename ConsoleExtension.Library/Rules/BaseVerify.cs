using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public class BaseVerify
    {
        public static IVerify<T> VerifyValue<T>(
            IResult<T> valueToCompare,
            bool isCompareValueSuccess,
            string messageOnFailure)
        {
            if (isCompareValueSuccess == false)
            {
                valueToCompare.AddResultMessage($"Rule violation: {messageOnFailure}");
            }
            VerifyFactory<T> verifyFactory = new VerifyFactory<T>();
            if (valueToCompare is IResultSuccess<int> && isCompareValueSuccess)
            {
                return verifyFactory.ConvertTo(valueToCompare, VerifyFactory<T>.ResultType.VerifySuccess);
            }
            return verifyFactory.ConvertTo(valueToCompare, VerifyFactory<T>.ResultType.VerifyFailed);
        }
    }
}
