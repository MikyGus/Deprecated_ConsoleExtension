using ConsoleExtension.Library.Converters;
using ConsoleExtension.Library.Result;
using ConsoleExtension.Library.ReadWrite;
using ConsoleExtension.Library.VerifyValue;
using ConsoleExtension.Library.DataModifiers;

(IWriteData consoleWrite, IReadData consoleRead) = Init();

//string inputValue = GetValueFromUser(consoleRead);
//ConvertValues(inputValue, consoleWrite);
//VerifyValue(inputValue, consoleWrite);
StringModifyDemo(consoleWrite);

static (IWriteData, IReadData) Init()
{
    Console.WriteLine("ConsoleExtention demo!");

    IWriteData write = new WriteDataToConsole();
    IReadData read = new ReadDataFromConsole();

    return (write, read);
}
static string GetValueFromUser(IReadData read)
{
    Console.Write("Please enter your value: ");
    string inputString = read.ReadData();
    return inputString;
}
static void ConvertValues(string inputString, IWriteData write)
{
    // *************Convert********** //
    // string.ConvertToInt();         //
    // string.ConvertToDouble();      //
    // ****************************** //
    Console.WriteLine("******************\nConvert: START\n******************");
    IResult<int> convertedValue = inputString.ConvertToInt();
    //IResult<double> convertedValue = await inputString.ConvertToDouble();

    PrintResult<int>(convertedValue, inputString, write);
    Console.WriteLine("\nConvert: END\n******************\n\n");
}
static void VerifyValue(string inputString, IWriteData write)
{
    Console.WriteLine("******************\nConvert and verify: START\n******************");
    // ************ //
    // Verify rules //
    int[] myCollection = { 1, 2, 3, 4, 7 };
    IResult<int> convertedIntegerVerified = inputString
        .ConvertToInt()
        .Verify(x => Array.Exists(myCollection, z => z == x), "Not Contained in collection")
        .Verify(x => x > 6, "Value is not above 6")
        .Verify(x => x < 10, "value is not under 10");
    IResult<int> test0 = inputString.ConvertToInt().Verify(x => x > 6).Verify(x => x < 10);
    IResult<int> test1 = inputString.ConvertToInt().Verify(x => x > 6 && x < 10);
    IResult<int> test2 = inputString.ConvertToInt().Verify(x => x > 6 && x < 10, "Failed to pass this test... :(");

    IResult<int> VerifyAnInt = 42.Verify(x => x > 6, "Value is not above 6");
    IResult<double> VerifyADouble = 42.0d.Verify(x => x > 6, "Value is not above 6");

    PrintResult<int>(convertedIntegerVerified, inputString, write);
    Console.WriteLine("\nConvert and verify: END\n******************\n\n");
}


static void PrintResult<T>(IResult<T> result, string userInput, IWriteData write)
{
    if (result.IsSuccessful == true)
    {
        write.WriteLine($"The entered value [{result.Value}] is a nice and pretty value... :)");
    }
    else
    {
        write.WriteLine($"BAD result.\n\tEntered: {userInput}\n\tValue in result is: {result.Value}");
        Console.WriteLine("Errors:");
        IReadOnlyList<string> errors = result.ResultMessages;
        string prefix = "\t";
        string suffix = String.Empty;
        foreach (var error in errors)
        {
            write.WriteLine($"{prefix}{error}{suffix}");
        }
    }
}



static void StringModifyDemo(IWriteData write)
{
    string[] names = { "Adam", "Bridgette", "Carla", "Daniel", "Ebenezer", "Francine", "George" };
    decimal[] hours = { 40, 6.667m, 40.39m, 82, 40.333m, 80, 16.75m };

    StringModifier stringModifier = new();

    for (int i = 0; i < names.Length; i++)
    {
        string name = stringModifier.Padding(names[i], Alignment.LEFT, 15);
        string hour = stringModifier.Padding(hours[i], Alignment.RIGHT, 5);
        write.WriteLine(name + hour);
    }


    string myString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ut " +
        "volutpat enim. Cras sollicitudin quam et ligula aliquet, sed commodo felis dapibus.";
    write.WriteLine("");
    write.WriteLine(stringModifier.Padding("Truncate",Alignment.CENTER,20,'*'));
    write.WriteLine(stringModifier.Truncate(myString, 11));

}