using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public static class VerifyValues
    {
        public static IVerify<int> Verify(this int value)
        {
            VerifyFactory<int> verifyFactory = new();
            return verifyFactory.Create(VerifyFactory<int>.ResultType.Verify, value);
        }

        public static IVerify<int> Verify(this IResult<int> result)
        {
            VerifyFactory<int> verifyFactory = new();
            return verifyFactory.ConvertTo(result, VerifyFactory<int>.ResultType.Verify);
        }
    }
}
