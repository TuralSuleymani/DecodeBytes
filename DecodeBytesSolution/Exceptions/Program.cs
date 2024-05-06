using Exceptions.Exceptions;

namespace Exceptions
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
   public class Bank
    {
        private readonly List<Customer> _customers;
        public Bank()
        {
            _customers =
            [
                new Customer
                {
                    Id = 1,
                    Name = "Customer 1"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Customer 2"
                },
            ];
        }


        //catch
        //catch(Exception)
        //catch( instance)

        public Customer GetCustomer(int id)
        {
            return GetCustomerById(id);
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                return _customers.First(x => x.Id == id);
            }
            catch (InvalidOperationException exp)
            {
                throw new CustomerNotFoundException(id);
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            //file

            try
            {
                bank.GetCustomerById(100);
            }
            catch(CustomerNotFoundException e)
            {
                Console.WriteLine(e.Data["customerId"]);
            }
           
            Console.ReadLine();
        }
    }
}
