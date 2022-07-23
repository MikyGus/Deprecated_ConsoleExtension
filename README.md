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
**Basic**
```csharp
    IResult<int> convertedValue = "5".ConvertToInt();
    IResult<int> verifiedValue = convertedValue.Verify(x => x < 10);
```
**Chain**
```csharp
    IResult<int> convertedValue = "5".ConvertToInt();
    IResult<int> verifiedValue = convertedValue.Verify(x => x < 10).Verify(x => x > 2);
```
**Message on fail**
```csharp
    IResult<int> convertedValue = "5".ConvertToInt();
    IResult<int> verifiedValue = convertedValue
        .Verify(x => x < 10, "Value is not under 10")
        .Verify(x => x > 2, "Value is not over 2");
```

### Examples
```csharp
    IResult<int> convertedIntegerVerified = inputString
        .ConvertToInt()
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
```