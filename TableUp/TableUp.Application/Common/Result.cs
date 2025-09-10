using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableUp.Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; }
        public object? Value { get; }

        protected Result(bool isSuccess, string error, object? value = null)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Result Success(object? value = null) => new Result(true, string.Empty, value);
        public static Result Failure(string error) => new Result(false, error);
    }

}
