using ConsoleExtension.Library.Rules;

namespace ConsoleExtension.Library.Result
{
    public class ResultFactory<T>
    {
        public enum ResultType
        {
            ResultSuccess,
            ResultFailed,
        }

        private readonly Dictionary<ResultType, Type> ResultIsAList = new();

        public ResultFactory()
        {
            ResultIsAList.Add(ResultType.ResultSuccess, typeof(IResultSuccess<T>));
            ResultIsAList.Add(ResultType.ResultFailed, typeof(IResultFailed<T>));
        }

        public IResult<T> Create(ResultType resultType, T defaultValue)
        {
            List<string> resultMessages = new();
            return Create(resultType, defaultValue, resultMessages);
        }
        private IResult<T> Create(ResultType resultType, T defaultValue, IReadOnlyList<string> resultMessages)
        {
            switch (resultType)
            {
                case ResultType.ResultSuccess:
                    return new ResultSuccess<T>(defaultValue)
                    {
                        ResultMessages = resultMessages
                    };
                case ResultType.ResultFailed:
                    return new ResultFailed<T>(defaultValue)
                    {
                        ResultMessages = resultMessages
                    };
                default: 
                    throw new ArgumentOutOfRangeException(nameof(resultType));
            }
        }

        public IResult<T> ConvertTo(IResult<T> currentResult, ResultType convertTo)
        {
            if (currentResult.GetType() == ResultIsAList[convertTo])
            {
                return currentResult;
            }

            return Create(convertTo,currentResult.Value, currentResult.ResultMessages);
        }
    }
}