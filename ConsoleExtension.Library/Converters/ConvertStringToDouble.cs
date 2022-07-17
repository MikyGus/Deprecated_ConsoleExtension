using ConsoleExtension.Library.Result;
using System.Globalization;

namespace ConsoleExtension.Library.Converters
{
    public static class ConvertStringToDouble
    {
        public static IResult<double> ConvertToDouble(this string inputString, CultureInfo? cultureInfo = null, double defaultValue = 0)
        {
            cultureInfo ??= CultureInfo.CreateSpecificCulture("en-GB");

            bool isSuccessful = double.TryParse(inputString, NumberStyles.Any, cultureInfo, out double value);
            
            IResult<double> result = new ResultFactory<double>().Create(defaultValue,value,isSuccessful);
            if (isSuccessful == false)
            {
                result.AddResultMessage($"Could not convert the string [{inputString}] to a double. It's not in a double-format.");
            }
            return result;
        }

        //public static IResult<double> ConvertToDouble(
        //    this string inputString, 
        //    double defaultValue = 0.0, 
        //    CultureInfo? cultureInfo = null)
        //{
        //    var numberStyle = NumberStyles.Any;
        //    cultureInfo ??= CultureInfo.CreateSpecificCulture("en-GB");
        //    if (double.TryParse(inputString, numberStyle, cultureInfo, out double result))
        //    {
        //        IResultFactory<double> resultFactory = new ResultFactory<double>();
        //        resultFactory.Create(0);


        //    }  

        //    string errorMessage = $"Could not convert the string [{inputString}] to a double. It's not in a double-format.";
        //    IResult<double> FailedResult = new ResultFailed<double>(defaultValue);
        //    FailedResult.AddResultMessage(errorMessage);
        //    return FailedResult;
        //}
    }
}
