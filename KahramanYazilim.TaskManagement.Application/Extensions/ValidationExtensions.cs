using FluentValidation.Results;
using KahramanYazilim.TaskManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static List<ValidationError> ToMap(this List<ValidationFailure> errors)
        {
            var errorList = new List<ValidationError>();
           
            foreach (var error in errors)
            {
                errorList.Add(new ValidationError
                (
                    error.PropertyName,
                    error.ErrorMessage
                ));
            }

            return errorList;
        }
    }
}
