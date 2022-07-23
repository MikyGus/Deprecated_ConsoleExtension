namespace ConsoleExtension.Library.ReadWrite;

public class ReadDataFromConsole : IReadData
{
    public string ReadData()
    {
        return Console.ReadLine() ?? String.Empty;
    }
}
