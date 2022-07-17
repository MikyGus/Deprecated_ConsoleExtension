namespace ConsoleExtension.Library.Result
{
    internal interface IResultFactory<T>
    {
        //IResult<T> Create(T defaultValue);
        IResult<T> Create(T defaultValue, T value, bool isSuccess);
    }
}