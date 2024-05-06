using ExpApp.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpApp.Common.Extensions
{
    public static class ValidationExtensions
    {
        private static ValidationException throwValidation(string validationMessage)
        {
            throw new ValidationException(validationMessage);
        }

        public static string IsNotNullOrEmpty(this string model)
        {
            if (string.IsNullOrEmpty(model))
                throw throwValidation("Data is null or empty");
            return model;
        }

        public static string IsInValidRange(this string model,int min, int max)
        {
            if (model.Length>=4 && model.Length<=10)
                return model;
            throw throwValidation("Data is null or empty");
            
        }
    }
}
