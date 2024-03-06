using Domain.Models.Exceptions;
using System.Runtime.CompilerServices;

namespace Domain.Models.Extensions
{
    public static class DomainValidators
    {
        private static ValidationException InvalidOp(string message)
        {
            return new ValidationException(message);
        }

        public static T? IsNull<T>(this T? model, [CallerArgumentExpression("model")] string name = "")
        {
            if (model == null)
            {
                return model;
            }

            throw InvalidOp(name + " must be null.");
        }

        public static T IsNotNull<T>(this T? model, [CallerArgumentExpression("model")] string name = "")
        {
            if (model != null)
            {
                return model;
            }

            throw InvalidOp(name + " cannot be null.");
        }

        public static string IsNotBlank(this string? model, [CallerArgumentExpression("model")] string name = "")
        {
            if (!string.IsNullOrWhiteSpace(model))
            {
                return model;
            }

            throw InvalidOp(name + " cannot be blank.");
        }
    }
}
