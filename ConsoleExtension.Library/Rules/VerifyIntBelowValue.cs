using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public static class VerifyIntBelowValue
    {

        public static IResult<int> VerifyBelow(this IResult<int> valueToCompare, int compareAgainst)
        {
            bool IsBelowValue = valueToCompare.Value < compareAgainst;
            if (IsBelowValue == false)
            {
                valueToCompare.AddResultMessage($"Rule violation: {valueToCompare.Value} is not below {compareAgainst}.");
            }
            if (valueToCompare is IResultSuccess<int> && IsBelowValue)
            {
                return valueToCompare.ConvertToSuccess();
            }
            return valueToCompare.ConvertToFail();
        }
    }
}
