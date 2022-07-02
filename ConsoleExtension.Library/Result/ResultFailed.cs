namespace ConsoleExtension.Library.Result
{
    public class ResultFailed<T> : Result<T>, IResultFailed<T>
    {
        private readonly T _defaultValue;
        public ResultFailed(T defaultValue)
        {
            _defaultValue = defaultValue;
            IsSuccessful = false;
        }

        public override T Value => _defaultValue;
    }
}
