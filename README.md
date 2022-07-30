# ConsoleExtension
Extra functionality for the console
* **Read** input from the console, with interface making it easier to mock.
* **Write** to the console, with interface making it easier to mock.
* **Convert** a string to integer, double, etc.
* **Verify** the correctnes of an integer, double, etc against your business rules. 

# How to
## Read from the console
**Read** input from the console, with interface making it easier to mock.

```csharp
    IReadData read = new ReadDataFromConsole();
    string inputString = read.ReadData();
```

## Write to the console
**Write** to the console, with interface making it easier to mock.
```csharp
    IWriteData write = new WriteDataToConsole();
    write.WriteLine("Nice and pretty value... :)");
```

## Convert data
**Integer**: 
```csharp
    IResult<int> result = "1".ConvertToInt();
```

**Double**
```csharp
    IResult<double> result = input.ConvertToDouble(); //Uses default culture: en-GB
```
```csharp
    string input = "1,1";
    double defaultValue = 1.1;
    CultureInfo cultureSE = CultureInfo.CreateSpecificCulture("sv-SE");
    IResult<double> result = input.ConvertToDouble(defaultValue,cultureSE);
```
### Examples
```csharp
    IResult<int> convertedInteger = inputString.ConvertToInt();
    if (convertedInteger is IResultSuccess<int> resultInt)
    {
        write.WriteLine("Nice and pretty value... :)");
        write.WriteLine(resultInt.Value.ToString());
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
```

## Verify data
### Chain methods
Several Verify() methods can be chained together. 
**Note**: Evaluation continues even if first Verifymethod fails. All error-messages can be found in *ResultMessages*.

### Verify returns
Property **IsSuccessful** is true if _all_ Verify() evaluates successfully. If one of the chained Verify() fails the end result i allways false.


### Verify()
**Verify IResult<T>**
```csharp
    IResult<int> convertedValue = "5".ConvertToInt(); // We convert our input to integer

    IResult<int> SimpleVerifiedInteger = convertedValue.Verify(x => x < 10);
    IResult<int> ChainedVerified = convertedValue.Verify(x => x < 10).Verify(x => x > 2);
    IResult<int> VerifyWithMessageOnFail = convertedValue
        .Verify(x => x < 10, "Value is not under 10")
        .Verify(x => x > 2, "Value is not over 2");
```
**Verify literals**
Above examples also applies to literals, ie chaining, messageOnFail etc.
```csharp
    IResult<int> VerifiedInteger = 42.Verify(x => x < 10);
    IResult<double> VerifiedDouble = 42.5d.Verify(x => x < 10);
```

### Examples
```csharp
    // Maybe input from the user
    string = "42"; 

    // We convert the input to integer and verifies the value is between 6 and 10.
    IResult<int> convertedIntegerVerified = inputString
        .ConvertToInt()
        .Verify(x => x > 6, "Value is not above 6")
        .Verify(x => x < 10, "value is not under 10");

    if (convertedIntegerVerified.IsSuccessful == true)
    {
        // If we have a good value from the user we display it...
        write.WriteLine("Nice and pretty value... :)");
        write.WriteLine(convertedIntegerVerified.Value.ToString());
    }
    else
    {
        // ... but if the value is bad we display all the reasons why it failed.
        write.WriteLine($"BAD result. Entered: {inputString} Defaulted to: {convertedIntegerVerified.Value}");
        var errors = convertedIntegerVerified.ResultMessages;
        foreach (var error in errors)
        {
            write.WriteLine(error);
        }
    }
```