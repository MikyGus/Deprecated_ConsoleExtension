using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.VerifyValue;

public static class VerifyDoubleValue
{
    public static IResult<double> Verify(this double valueToVerify, Func<double, bool> evaluate, string messageOnFail = "")
    {
        IResult<double> ValueToTest = ResultFactory<double>.Create(valueToVerify, 0.0d, true);
        return VerifyResultValue.VerifyValue<double>(ValueToTest, evaluate, messageOnFail);
    }
}
