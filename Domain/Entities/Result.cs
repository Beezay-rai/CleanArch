//using System.Net;

//namespace Domain.Common
//{
//    public class Result<TValue>
//    {
//        private readonly bool _isSuccess;
//        private readonly TValue _value;
//        private readonly Error _error;
//        public Result(bool success, TValue value)
//        {
//            _isSuccess = success;
//            _value = value;
//            _error = null;
//        }

//        public Result(Error error)
//        {
//            _error = error;
//            _value = default;
//        }

//        public static Result<TValue> Success(TValue value) => new Result<TValue>(true, value);
//        public static Result<TValue> Failure(Error error) => new Result<TValue>(error);
//        public static implicit operator Result<TValue>(TValue obj) => new Result<TValue>(true, obj);

//        public static implicit operator Result<TValue>(Error obj) => new Result<TValue>(obj);

//        public  TResult Match<TResult>(Func<TValue,TResult> success, Func<Error,TResult> failure)
//        {
//            return _isSuccess ? success(_value) : failure(_error);
//        }

//    }



//    public record Error(string status_code, string description)
//    {

//    }
//}