using ConsoleExtension.Library.Rules;

namespace ConsoleExtension.Library.Result
{
    public interface IResultFactory<T>
    {
        IResult<T> Create(T defaultValue, T value, bool isSuccess);
        public IVerifyResult<T> ConvertToVerify(IResult<T> currentResult);

    }
}