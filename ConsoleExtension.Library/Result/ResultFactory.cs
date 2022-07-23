namespace ConsoleExtension.Library.Result;

public class ResultFactory<T> : IResultFactory<T>
{
    public IResult<T> Create(T defaultValue, T value, bool isSuccessful)
    {
        if (isSuccessful == false)
        {
            value = defaultValue;
        }
        IResult<T> newResult = new Result<T>(defaultValue, value, isSuccessful);
        return newResult;
    }
}
