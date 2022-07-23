namespace ConsoleExtension.Library.ReadWrite;

public class WriteDataToConsole : IWriteData
{
    public void Write(string data)
    {
        Console.Write(data);
    }

    public void WriteLine(string data)
    {
        Console.WriteLine(data);
    }
}
