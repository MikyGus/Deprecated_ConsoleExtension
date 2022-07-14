using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public static class VerifyIntOverValue
    {
        public static IResult<int> ValueIsOver(this IResult<int> valueToCompare, int compareAgainst)
        {
            bool IsOverValue = valueToCompare.Value > compareAgainst;
            string errorMessage = $"{valueToCompare.Value} is not over {compareAgainst}.";
            return BaseVerify.VerifyValue(valueToCompare, IsOverValue, errorMessage);
        }

        //public static IResult<int> VerifyOver(int valueToCompare, int compareAgainst)
        //{
        //    return VerifyOver(new ResultSuccess<int>(valueToCompare), compareAgainst);
        //}
    }
}
