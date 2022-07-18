using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public class VerifyResult<T> : Result<T>, IVerifyResult<T>
    {
        public VerifyResult(T defaultValue, T value, bool isSuccessful) : base(defaultValue, value, isSuccessful)
        {
        }
    }
}
