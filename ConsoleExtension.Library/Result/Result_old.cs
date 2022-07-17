//namespace ConsoleExtension.Library.Result
//{
//    public abstract class Result_old<T> : IResult<T>
//    {
//        private readonly List<string> _resultMessages = new();
//        public bool IsSuccessful { get; protected set; } = false;

//        public abstract T Value { get; }

//        public IReadOnlyList<string> ResultMessages
//        {
//            get { return _resultMessages; }
//            init { _resultMessages = (List<string>)value; }
//        }

//        public void AddResultMessage(string message)
//        {
//            _resultMessages.Add(message);
//        }

//        //public IResult<T> ConvertToFail()
//        //{
//        //    if (GetType() != typeof(ResultFailed<T>))
//        //    {
//        //        IResultFailed<T> resultFailed = new ResultFailed<T>(Value)
//        //        {
//        //            ResultMessages = this.ResultMessages
//        //        };
//        //        return resultFailed;
//        //    }

//        //    return this;
//        //}

//        //public IResult<T> ConvertToSuccess()
//        //{
//        //    if (GetType() != typeof(ResultSuccess<T>))
//        //    {
//        //        IResultSuccess<T> resultSuccess = new ResultSuccess<T>(this.Value)
//        //        {
//        //            ResultMessages = this.ResultMessages
//        //        };
//        //        return resultSuccess;
//        //    }

//        //    return this;
//        //}
//    }
//}
