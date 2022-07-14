//using ConsoleExtension.Library.Result;

//namespace ConsoleExtension.Library.Converters
//{
//    public static class ConvertIResultToIResultSuccess
//    {
//        public static IResult<T> ConvertToResult<T,convertTo>(this IResult<T> inputResult)
//        {
//            if (inputResult.GetType() != typeof(convertTo))
//            {
//                IResultSuccess<T> resultSuccess = new ResultSuccess<T>(inputResult.Value)
//                {
//                    ResultMessages = inputResult.ResultMessages
//                };
//                return resultSuccess;
//            }

//            return inputResult;
//        }

//    }
//}
