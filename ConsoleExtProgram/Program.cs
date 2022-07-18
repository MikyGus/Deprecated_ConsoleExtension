using ConsoleExtension.Library.Converters;
using ConsoleExtension.Library.Result;
using ConsoleExtension.Library.ReadWrite;
using ConsoleExtension.Library.Rules;

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
var verifyInteger = convertedInteger.Verify();

if (verifyInteger.IsSuccessful == true)
{
    write.WriteLine("Nice and pretty value... :)");
    write.WriteLine(verifyInteger.Value.ToString());
}
else
{
    write.WriteLine($"BAD result. Entered: {inputString} Defaulted to: {verifyInteger.Value}");
    var errors = verifyInteger.ResultMessages;
    foreach (var error in errors)
    {
        write.WriteLine(error);
    }
}

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