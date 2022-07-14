using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public interface IVerifyFailed<T> : IResultFailed<T>, IVerify<T>
    {
    }
}
