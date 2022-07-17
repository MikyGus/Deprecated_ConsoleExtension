//using ConsoleExtension.Library.Result;

//namespace ConsoleExtension.Library.Rules
//{
//    public class BaseVerify
//    {
//        public static IResult<T> VerifyValue<T>(
//            IResult<T> valueToCompare,
//            bool isCompareValueSuccess,
//            string messageOnFailure)
//        {
//            if (isCompareValueSuccess == false)
//            {
//                valueToCompare.AddResultMessage($"Rule violation: {messageOnFailure}");
//            }
//            VerifyFactory<T> factory = new();
//            if (valueToCompare is IResultSuccess<int> && isCompareValueSuccess)
//            {
//                return factory.ConvertTo(valueToCompare,VerifyFactory<T>.ResultType.VerifySuccess);
//                //return valueToCompare.ConvertToSuccess();
//            }
//            return factory.ConvertTo(valueToCompare, VerifyFactory<T>.ResultType.VerifyFailed);
//            //return valueToCompare.ConvertToFail();
//        }
//    }
//}
