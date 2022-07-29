namespace ConsoleExtension.Library.Result;

internal class ResultFactory<T>
{
    internal static IResult<T> Create(T value, T defaultValue, bool isSuccessful)
    {
        if (isSuccessful == false)
        {
            value = defaultValue;
        }
        IResult<T> newResult = new Result<T>(value, defaultValue, isSuccessful);
        return newResult;
    }
}
