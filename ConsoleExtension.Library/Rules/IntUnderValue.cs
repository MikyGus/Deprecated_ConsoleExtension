namespace ConsoleExtension.Library.Rules
{
    public static class IntUnderValue
    {
        public static IVerifyResult<int> IsUnderValue(this IVerifyResult<int> verifyThisValue, int isUnderThisValue)
        {
            verifyThisValue.ConvertTo(verifyThisValue.Value < isUnderThisValue);


            //if (verifyThisValue.Value < isUnderThisValue)
            //{
            //    verifyThisValue.ConvertToSuccess();
            //}
            //else
            //{
            //    verifyThisValue.ConvertToFail();
            //}
            return verifyThisValue;
        }
    }
}
