using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public class VerifyFailed<T> : ResultFailed<T>, IVerifyFailed<T>
    {
        public VerifyFailed(T defaultValue) : base(defaultValue)
        {
        }
    }
}
