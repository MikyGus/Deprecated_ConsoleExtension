using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.VerifyValue
{
    public static class VerifyResultValue
    {
        public static IResult<T> Verify<T>(this IResult<T> valueToVerify, Func<T,bool> evaluate, string messageOnFail = "")
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

        public static IResult<T> Verify<T>(this T valueToVerify, Func<T, bool> evaluate, string messageOnFail = "")
        {
            IResult<T> result = new ResultFactory<T>().Create(valueToVerify,valueToVerify,true);
            return Verify(result,evaluate,messageOnFail);
        }
    }
}
