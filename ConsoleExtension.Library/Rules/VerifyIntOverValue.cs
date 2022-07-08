using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public static class VerifyIntOverValue
    {
        public static IResult<int> VerifyOver(this IResult<int> valueToCompare, int compareAgainst)
        {
            bool IsOverValue = valueToCompare.Value > compareAgainst;
            if (IsOverValue == false)
            {
                valueToCompare.AddResultMessage($"Rule violation: {valueToCompare.Value} is not over {compareAgainst}.");
            }
            if (valueToCompare is IResultSuccess<int> && IsOverValue)
            {
                return valueToCompare.ConvertToSuccess();
            }
            return valueToCompare.ConvertToFail();
        }
    }
}
