namespace Exceptions.Exceptions
{
    public class CustomerNotFoundException : ApplicationException
    {
        public DateTime ExceptionTime { get; init; }
        public CustomerNotFoundException(string message,int id) : base(message)
        {
            ExceptionTime = DateTime.Now;
            Data["customerId"] = id;
        }
        public CustomerNotFoundException(int id) : base("We couldn't find a customer for the given criteria")
        {
            ExceptionTime = DateTime.Now;
            Data["customerId"] = id;
        }

    }
}
