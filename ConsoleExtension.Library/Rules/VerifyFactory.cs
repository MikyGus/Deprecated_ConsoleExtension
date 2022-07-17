//using ConsoleExtension.Library.Exceptions;
//using ConsoleExtension.Library.Result;

//namespace ConsoleExtension.Library.Rules
//{
//    public class VerifyFactory<T>
//    {
//        public enum ResultType
//        {
//            Verify,
//            VerifySuccess,
//            VerifyFailed,
//        }

//        private readonly Dictionary<ResultType, Type> ResultTypes = new();

//        public VerifyFactory()
//        {
//            ResultTypes.Add(ResultType.Verify, typeof(IResultSuccess<T>));
//            ResultTypes.Add(ResultType.VerifySuccess, typeof(IResultSuccess<T>));
//            ResultTypes.Add(ResultType.VerifyFailed, typeof(IResultFailed<T>));
//        }

//        public IResult<T> Create(ResultType resultType, T defaultValue)
//        {
//            List<string> resultMessages = new();
//            return Create(resultType, defaultValue, resultMessages);
//        }

//        private IResult<T> Create(ResultType resultType, T defaultValue, IReadOnlyList<string> resultMessages)
//        {
//            switch (resultType)
//            {
//                case VerifyFactory<T>.ResultType.Verify:
//                    return new ResultSuccess<T>(defaultValue)
//                    {
//                        ResultMessages = resultMessages
//                    };
//                case VerifyFactory<T>.ResultType.VerifySuccess:
//                    return new ResultSuccess<T>(defaultValue)
//                    {
//                        ResultMessages = resultMessages
//                    };
//                case VerifyFactory<T>.ResultType.VerifyFailed:
//                    return new ResultFailed<T>(defaultValue)
//                    {
//                        ResultMessages = resultMessages
//                    };
//                default:
//                    throw new InvalidResultProvided(resultType.ToString());
//            }
//        }

//        public IResult<T> ConvertTo(IResult<T> currentResult, ResultType convertTo)
//        {
//            if (currentResult.GetType() == ResultTypes[convertTo])
//            {
//                return currentResult;
//            }
//            return Create(convertTo, currentResult.Value, currentResult.ResultMessages);
//        }
//    }
//}
