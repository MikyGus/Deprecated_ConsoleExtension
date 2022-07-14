using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public static class VerifyIntBelowValue
    {

        public static IVerify<int> ValueIsBelow(this IVerify<int> valueToCompare, int compareAgainst)
        {
            bool IsBelowValue = valueToCompare.Value < compareAgainst;
            string errorMessage = $"{valueToCompare.Value} is not below {compareAgainst}.";
            return BaseVerify.VerifyValue(valueToCompare, IsBelowValue, errorMessage);
        }

        //public static IResult<int> VerifyBelow(int valueToCompare, int compareAgainst)
        //{
        //    return VerifyBelow(new ResultSuccess<int>(valueToCompare), compareAgainst);
        //}
    }
}
