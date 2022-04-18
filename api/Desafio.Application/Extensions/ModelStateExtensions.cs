using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Application.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrors(this ModelStateDictionary modelState)
        {
            var errors = new List<string>();
            foreach (var item in modelState.Values)
            {
                errors.AddRange(item.Errors.Select(error => error.ErrorMessage));
            }
            return errors;
        }
    }
}