using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public interface IVerifySuccess<T> : IResultSuccess<T>, IVerify<T>
    {
    }
}
