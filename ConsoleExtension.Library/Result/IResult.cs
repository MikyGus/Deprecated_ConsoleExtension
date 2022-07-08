﻿namespace ConsoleExtension.Library.Result
{
    public interface IResult<T>
    {
        bool IsSuccessful { get; }
        T Value { get; }
        IReadOnlyList<string> ResultMessages { get; init; }
        void AddResultMessage(string message);
        IResult<T> ConvertToFail();
        IResult<T> ConvertToSuccess();
    }
}
