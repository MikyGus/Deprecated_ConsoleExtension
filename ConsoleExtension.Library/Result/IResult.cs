namespace ConsoleExtension.Library.Result
{
    public interface IResult<T>
    {
        bool IsSuccessful { get; }
        T Value { get; }
        IReadOnlyList<string> ResultMessages { get; init; }
        void AddResultMessage(string message);
        void ConvertToFail();
        void ConvertToSuccess();
        void ConvertTo(bool isSuccessfull);
    }
}
