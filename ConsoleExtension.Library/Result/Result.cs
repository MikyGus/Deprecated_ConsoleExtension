namespace ConsoleExtension.Library.Result;

public class Result<T> : IResult<T>
{
    private readonly List<string> _resultMessages = new();
    private readonly T _defaultValue;
    private bool _isSuccessful;

    public bool IsSuccessful { get => _isSuccessful; }

    public T Value { get; set; }
    public T DefaultValue => _defaultValue;

    public IReadOnlyList<string> ResultMessages
    {
        get { return _resultMessages; }
        init { _resultMessages = (List<string>)value; }
    }

    public Result(T value, T defaultValue, bool isSuccessful)
    {
        _defaultValue = defaultValue;
        Value = value;
        _isSuccessful = isSuccessful;
    }

    public void AddResultMessage(string message)
    {
        _resultMessages.Add(message);
    }



    public void SetToFail()
    {
        _isSuccessful = false;
    }

    public void SetToSuccess()
    {
        _isSuccessful = true;
    }

}
