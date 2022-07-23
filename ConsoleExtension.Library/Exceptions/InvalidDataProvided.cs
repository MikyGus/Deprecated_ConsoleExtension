namespace ConsoleExtension.Library.Exceptions;

public class InvalidDataProvided : Exception
{
    public InvalidDataProvided(string value, Exception? innerException = null)
        : base($"Provided value [{value}] is invalid", innerException)
    {
    }
}
