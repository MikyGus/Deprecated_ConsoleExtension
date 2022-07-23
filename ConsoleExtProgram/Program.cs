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
// Convert a string to an integer //
IResult<int> convertedInteger = inputString.ConvertToInt();
//IResult<double> convertedInteger = inputString.ConvertToDouble();
//var verifyInteger = convertedInteger.Verify();

if (convertedInteger.IsSuccessful == true)
{
    write.WriteLine("Nice and pretty value... :)");
    write.WriteLine(convertedInteger.Value.ToString());
}
else
{
    write.WriteLine($"BAD result. Entered: {inputString} Defaulted to: {convertedInteger.Value}");
    var errors = convertedInteger.ResultMessages;
    foreach (var error in errors)
    {
        write.WriteLine(error);
    }
}

var test = inputString.ConvertToInt().Verify(x => x > 6).Verify(x => x < 10);
var test2 = inputString.ConvertToInt().Verify(x => x > 6 && x < 10);
var test3 = inputString.ConvertToInt().Verify(x => x > 6 && x < 10, "Failed to pass this test... :(");

// ************ //
// Verify rules //
//IResult<int> convertedIntegerVerified = inputString.ConvertToInt().VerifyOver(5);
//IResult<int> convertedIntegerVerified = inputString.ConvertToInt().VerifyBelow(5);
//IResult<int> convertedIntegerVerified = inputString.ConvertToInt().VerifyBelow(10).VerifyOver(3);

//if (convertedIntegerVerified.IsSuccessful == true)
//{
//    write.WriteLine("Nice and pretty value... :)");
//    write.WriteLine(convertedIntegerVerified.Value.ToString());
//}
//else
//{
//    write.WriteLine($"BAD result. Entered: {inputString} Defaulted to: {convertedInteger.Value}");
//    var errors = convertedIntegerVerified.ResultMessages;
//    foreach (var error in errors)
//    {
//        write.WriteLine(error);
//    }
//}