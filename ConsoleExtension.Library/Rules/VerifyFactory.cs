using ConsoleExtension.Library.Result;

namespace ConsoleExtension.Library.Rules
{
    public class VerifyFactory<T>
    {
        public enum ResultType
        {
            Verify,
            VerifySuccess,
            VerifyFailed,
        }
        private Dictionary<ResultType, Type> ResultIsAList = new();
        public VerifyFactory()
        {
            ResultIsAList.Add(ResultType.Verify, typeof(IVerifySuccess<T>));
            ResultIsAList.Add(ResultType.VerifySuccess, typeof(IVerifySuccess<T>));
            ResultIsAList.Add(ResultType.VerifyFailed, typeof(IVerifyFailed<T>));
        }
        public IVerify<T> Create(ResultType resultType, T defaultValue)
        {
            List<string> resultMessages = new();
            return Create(resultType, defaultValue, resultMessages);
        }
        private IVerify<T> Create(ResultType resultType, T defaultValue, IReadOnlyList<string> resultMessages)
        {
            switch (resultType)
            {
                case ResultType.Verify:
                    return new VerifySuccess<T>(defaultValue)
                    {
                        ResultMessages = resultMessages
                    };
                case ResultType.VerifySuccess:
                    return new VerifySuccess<T>(defaultValue)
                    {
                        ResultMessages = resultMessages
                    };
                case ResultType.VerifyFailed:
                    return new VerifyFailed<T>(defaultValue)
                    {
                        ResultMessages = resultMessages
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(resultType));
            }
        }

        public IVerify<T> ConvertTo(IResult<T> currentResult, ResultType convertTo)
        {
            return Create(convertTo, currentResult.Value, currentResult.ResultMessages);
        }
        public IVerify<T> ConvertTo(IVerify<T> currentResult, ResultType convertTo)
        {
            if (currentResult.GetType() == ResultIsAList[convertTo])
            {
                return currentResult;
            }

            return Create(convertTo, currentResult.Value, currentResult.ResultMessages);
        }
    }
}
