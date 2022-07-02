namespace ConsoleExtension.Library.Result
{
    public class ResultSuccess<T> : Result<T>, IResultSuccess<T>
    {
        private readonly T _value;

        public ResultSuccess(T value)
        {
            _value = value;
            IsSuccessful = true;
        }

        public override T Value => _value;
    }
}
