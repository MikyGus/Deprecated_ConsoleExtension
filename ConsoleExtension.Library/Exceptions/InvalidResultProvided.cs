namespace ConsoleExtension.Library.Exceptions;

public class InvalidResultProvided : Exception
{
    public InvalidResultProvided(string value, Exception? innerException = null)
        : base($"Provided result [{value}] is invalid!", innerException)
    {
    }
}
