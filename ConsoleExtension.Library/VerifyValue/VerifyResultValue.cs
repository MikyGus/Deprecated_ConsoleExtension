using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.VerifyValue
{
    public static class VerifyResultValue
    {
        internal static IResult<T> VerifyValue<T>(IResult<T> valueToVerify, Func<T, bool> evaluate, string messageOnFail = "")
        {
            bool havePassedTest = evaluate.Invoke(valueToVerify.Value);

            if (havePassedTest == true && valueToVerify.IsSuccessful == true)
            {
                valueToVerify.SetToSuccess();
                return valueToVerify;
            }

            if (havePassedTest == false && string.IsNullOrWhiteSpace(messageOnFail) == false)
            {
                valueToVerify.AddResultMessage(messageOnFail);
            }
            valueToVerify.SetToFail();
            return valueToVerify;
        }
    }
}
