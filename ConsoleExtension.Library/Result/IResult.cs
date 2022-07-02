namespace ConsoleExtension.Library.Result
{
    public interface IResult<T>
    {
        bool IsSuccessful { get; }
        T Value { get; }
        IReadOnlyList<string> ResultMessages { get; }
        void AddResultMessage(string message);
    }
}
