using ExpApp.Common.Exceptions;

namespace ExpApp.Common.Extensions
{
    public static class ValidationExtensions
    {
        private static ValidationException throwValidation(string validationMessage)
        {
            return new ValidationException(validationMessage);
        }

        public static string IsNotNullOrEmpty(this string model)
        {
            if (string.IsNullOrEmpty(model))
                throw throwValidation("Data is null or empty");
            return model;
        }

        public static string IsInValidRange(this string model,int min, int max)
        {
            if (model.Length>=min && model.Length<=max)
                return model;
            throw throwValidation("Data is null or empty");
            
        }
    }
}
