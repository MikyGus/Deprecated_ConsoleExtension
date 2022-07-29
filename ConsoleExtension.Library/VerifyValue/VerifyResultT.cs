using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.VerifyValue;

public static class VerifyResultT
{
    public static IResult<T> Verify<T>(this IResult<T> valueToVerify, Func<T, bool> evaluate, string messageOnFail = "")
    {
        return VerifyResultValue.VerifyValue<T>(valueToVerify, evaluate, messageOnFail);
    }
}
