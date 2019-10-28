using System;

namespace SolidTask.ConfigurationProvider.Models
{
    public class Result<T> : Result
    {
        protected internal Result(T value, bool success, string error) : base(success, error)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public class Result
    {
        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }

        public bool Success { get; }
        public bool Failure => !Success;
        public string Error { get; set; }

        public static Result Fail(string message) => new Result(false, message);

        public static Result Ok() => new Result(true, string.Empty);

        public static Result<T> Fail<T>(string message) => new Result<T>(default, false, message);

        public static Result<T> Ok<T>(T value) => new Result<T>(value, true, string.Empty);

    }


    public static class ResultExtensions
    {
        public static Result<T> OnSuccess<T>(this Result result, Func<Result<T>> func) => 
            result.Failure ? Result.Fail<T>(result.Error) : func();
        
        public static Result OnSuccess<T>(this Result<T> result, Func<T, Result> func) => 
            result.Failure ? Result.Fail(result.Error) : func(result.Value);
    }
}