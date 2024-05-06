namespace ExpApp.Common.Exceptions
{
    internal class ValidationException: ApplicationException
    {
        public ValidationException(string message) : base(message) { }
    }
}
