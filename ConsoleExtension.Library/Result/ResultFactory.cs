using ConsoleExtension.Library.Exceptions;

namespace ConsoleExtension.Library.Result
{
    internal class ResultFactory<T> : IResultFactory<T>
    {
        //public IResult<T> Create(T defaultValue)
        //{
        //    return Create(defaultValue, true);
        //}

        //public IResult<T> Create(T defaultValue, T value)
        //{
        //    return Create(defaultValue, value, true);
        //}

        public IResult<T> Create(T defaultValue, T value, bool isSuccessful)
        {
            if (isSuccessful == false)
            {
                value = defaultValue;
            }
            IResult<T> newResult = new Result<T>(defaultValue, value, isSuccessful);
            return newResult;
        }


        //public enum ResultType
        //{
        //    ResultSuccess,
        //    ResultFailed,
        //}

        //private readonly Dictionary<ResultType, Type> ResultTypes = new();

        //public ResultFactory()
        //{
        //    ResultTypes.Add(ResultType.ResultSuccess, typeof(IResultSuccess<T>));
        //    ResultTypes.Add(ResultType.ResultFailed, typeof(IResultFailed<T>));
        //}

        //public IResult<T> Create(ResultType resultType, T defaultValue)
        //{
        //    List<string> resultMessages = new();
        //    return Create(resultType, defaultValue, resultMessages);
        //}

        //private IResult<T> Create(ResultType resultType, T defaultValue, IReadOnlyList<string> resultMessages)
        //{
        //    switch (resultType)
        //    {
        //        case ResultFactory<T>.ResultType.ResultSuccess:
        //            return new ResultSuccess<T>(defaultValue)
        //            {
        //                ResultMessages = resultMessages
        //            };
        //        case ResultFactory<T>.ResultType.ResultFailed:
        //            return new ResultFailed<T>(defaultValue)
        //            {
        //                ResultMessages = resultMessages
        //            };
        //        default:
        //            throw new InvalidResultProvided(resultType.ToString());
        //    }
        //}

        //public IResult<T> ConvertTo(IResult<T> currentResult, ResultType convertTo)
        //{
        //    if (currentResult.GetType() == ResultTypes[convertTo])
        //    {
        //        return currentResult;
        //    }
        //    return Create(convertTo,currentResult.Value, currentResult.ResultMessages);
        //}
    }
}
