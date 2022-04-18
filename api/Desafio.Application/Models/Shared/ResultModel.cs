using System.Collections.Generic;

namespace Desafio.Application.Models.Shared
{
    public class ResultModel<T>
    {
        public ResultModel(T data)
        {
            Data = data;
        }

        public ResultModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResultModel(string error)
        {
            Errors.Add(error);
        }

        public ResultModel(List<string> errors)
        {
            Errors = errors;
        }

        public T Data { get; set; }
        public List<string> Errors { get; private set; }
    }
}