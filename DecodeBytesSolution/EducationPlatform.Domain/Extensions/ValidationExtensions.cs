using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Domain.Extensions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }

    public static class ValidationExtensions
    {
        private static ValidationException CreateException(string message)
        {
            return new ValidationException(message);
        }
        public static T IsGreaterThan<T>(this T value, T other, [CallerArgumentExpression("value")] string name = "", [CallerArgumentExpression("other")] string othername = "") where T :struct, IComparable
        {
            if (value.CompareTo(other) <= 0)
            {
                string message = $"{name} with value {value} should be greater than {othername} with value {other}";
                throw CreateException(message);
            }

            return value;
        }
    }
}
