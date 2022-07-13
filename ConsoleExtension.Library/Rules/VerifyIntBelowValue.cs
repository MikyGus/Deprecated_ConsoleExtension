using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public static class VerifyIntBelowValue
    {

        public static IResult<int> VerifyBelow(this IResult<int> valueToCompare, int compareAgainst)
        {
            bool IsBelowValue = valueToCompare.Value < compareAgainst;
            string errorMessage = $"{valueToCompare.Value} is not below {compareAgainst}.";
            return BaseVerify.VerifyValue(valueToCompare, IsBelowValue, errorMessage);
        }
    }
}
