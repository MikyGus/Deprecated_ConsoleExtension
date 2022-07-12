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
All Verify methods can be chained together. 
**Note**: Evaluation continues even if first Verifymethod fails. All error-messages can be found in *ResultMessages*.

### Verify returns
**Returns ResultFailed():IResultFailed** if evaluation fails or if input is IResultFailed.
**Returns ResultSuccess():IResultSuccess** if evaluation results to valid and input is IResultSuccess. 


### Int
**VerifyBelow**
Verifies that the input value is _below_ specified value.
```csharp
int number = ResultSuccess(3);
IResult<int> result = number.VerifyBelow(10);
```
**VerifyOver**
Verifies that the input value is _over_ specified value.
```csharp
int number = ResultSuccess(10);
IResult<int> result = number.VerifyOver(5);
```

### Examples
```csharp
    IResult<int> convertedIntegerVerified = inputString.ConvertToInt().VerifyBelow(10).VerifyOver(3);

    if (convertedIntegerVerified is IResultSuccess<int> resultIntVerify)
    {
        write.WriteLine("Nice and pretty value... :)");
        write.WriteLine(resultIntVerify.Value.ToString());
    }
    else
    {
        write.WriteLine($"BAD result. Entered: {inputString} Defaulted to: {convertedInteger.Value}");
        var errors = convertedIntegerVerified.ResultMessages;
        foreach (var error in errors)
        {
            write.WriteLine(error);
        }
    }
```

## IResult, IResultSuccess, IResultFailed
