using ConsoleExtension.Library.Converters;
using ConsoleExtension.Library.Result;
using ConsoleExtension.Library.ReadWrite;
using ConsoleExtension.Library.VerifyValue;

Console.WriteLine("ConsoleExtention demo!");

IWriteData write = new WriteDataToConsole();
IReadData read = new ReadDataFromConsole();
string inputString = read.ReadData();

// *************Convert********** //
// string.ConvertToInt();         //
// string.ConvertToDouble();      //

// ****************************** //

IResult<int> convertedValue = inputString.ConvertToInt();
//IResult<double> convertedValue = inputString.ConvertToDouble();

if (convertedValue.IsSuccessful == true)
{
    write.WriteLine("Nice and pretty value... :)");
    write.WriteLine(convertedValue.Value.ToString());
}
else
{
    write.WriteLine($"BAD result. Entered: {inputString} Defaulted to: {convertedValue.Value}");
    var errors = convertedValue.ResultMessages;
    foreach (var error in errors)
    {
        write.WriteLine(error);
    }
}



// ************ //
// Verify rules //
int[] myCollection = { 1, 2, 3, 4 };
IResult<int> convertedIntegerVerified = inputString
    .ConvertToInt()
    .Verify(x => Array.Exists(myCollection,z => z == x),"Not Contained in collection")
    .Verify(x => x > 6, "Value is not above 6")
    .Verify(x => x < 10, "value is not under 10");
IResult<int> test0 = inputString.ConvertToInt().Verify(x => x > 6).Verify(x => x < 10);
IResult<int> test1 = inputString.ConvertToInt().Verify(x => x > 6 && x < 10);
IResult<int> test2 = inputString.ConvertToInt().Verify(x => x > 6 && x < 10, "Failed to pass this test... :(");

if (convertedIntegerVerified.IsSuccessful == true)
{
    write.WriteLine("Nice and pretty value... :)");
    write.WriteLine(convertedIntegerVerified.Value.ToString());
}
else
{
    write.WriteLine($"BAD result. Entered: {inputString} Defaulted to: {convertedIntegerVerified.Value}");
    var errors = convertedIntegerVerified.ResultMessages;
    foreach (var error in errors)
    {
        write.WriteLine(error);
    }
}