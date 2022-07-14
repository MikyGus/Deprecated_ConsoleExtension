using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public class VerifySuccess<T> : ResultSuccess<T>, IVerifySuccess<T>
    {
        public VerifySuccess(T value) : base(value)
        {
        }
    }
}
