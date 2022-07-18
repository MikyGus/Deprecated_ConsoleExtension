using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules;

public static class VerifyValue
{
    public static IVerifyResult<T> Verify<T>(this IResult<T> currentResult)
    {
        return new ResultFactory<T>().ConvertToVerify(currentResult);
    }
}
