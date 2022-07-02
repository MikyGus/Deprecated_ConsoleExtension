namespace ConsoleExtension.Library.Result
{
    public abstract class Result<T> : IResult<T>
    {
        private readonly List<string> _resultMessages = new();
        public bool IsSuccessful { get; protected set; } = false;

        public abstract T Value { get; }

        public IReadOnlyList<string> ResultMessages => _resultMessages;

        public void AddResultMessage(string message)
        {
            _resultMessages.Add(message);
        }
    }
}
