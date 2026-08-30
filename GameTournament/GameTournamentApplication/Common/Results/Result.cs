using GameTournamentApplication.Common.Errors;

namespace GameTournamentApplication.Common.Results
{
    public class Result
    {
        public bool IsSuccess { get; }
        public List<Error> Errors { get; }

        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, List<Error>? errors)
        {
            IsSuccess = isSuccess;
            Errors = errors ?? new List<Error>();
        }

        public static Result Success()
            => new(true, null);

        public static Result Failure(params Error[] errors)
            => new(false, errors.ToList());

        public TResult Match<TResult>(
            Func<TResult> onSuccess,
            Func<List<Error>, TResult> onFailure)
        {
            return IsSuccess
                ? onSuccess()
                : onFailure(Errors);
        }
    }
    public class Result<T> : Result
    {
        public T? Value { get; }

        private Result(T value)
            : base(true, null)
        {
            Value = value;
        }

        private Result(List<Error> errors)
            : base(false, errors)
        {
            Value = default;
        }

        public static Result<T> Success(T value)
            => new(value);

        public static new Result<T> Failure(params Error[] errors)
            => new(errors.ToList());

        public TResult Match<TResult>(
            Func<T, TResult> onSuccess,
            Func<List<Error>, TResult> onFailure)
        {
            return IsSuccess
                ? onSuccess(Value!)
                : onFailure(Errors);
        }
    }
}
