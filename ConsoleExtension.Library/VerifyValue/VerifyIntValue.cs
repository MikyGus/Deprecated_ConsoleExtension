using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.VerifyValue;

public static class VerifyIntValue
{
    public static IResult<int> Verify(this int valueToVerify, Func<int, bool> evaluate, string messageOnFail = "")
    {
        IResult<int> ValueToTest = ResultFactory<int>.Create(valueToVerify, 0, true);
        return VerifyResultValue.VerifyValue<int>(ValueToTest, evaluate, messageOnFail);
    }
}
