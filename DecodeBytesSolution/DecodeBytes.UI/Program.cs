using DecodeBytes.Entity;
using DecodeBytes.Service;
using System.Runtime.CompilerServices;

namespace DecodeBytes.UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //CallService();
            await CallServiceAsync();
        }

        //version 1
        static void CallService()
        {
            Console.WriteLine($"Operation started on thread {Environment.CurrentManagedThreadId}");
            Customer customer = new(4, "Mike");
            Task<bool> task = CustomerService.Create().IsCustomerExistAsync(customer.Id);
            TaskAwaiter<bool> awaiter = task.GetAwaiter();

            void continuation() //the action
            {
                Console.WriteLine(awaiter.GetResult() == true ? "Customer exists" : "Customer doesn't exist");
                Console.WriteLine($"Operation finished on thread {Environment.CurrentManagedThreadId}");
            }
            awaiter.OnCompleted(continuation);

        }

        //version 2
        static async Task CallServiceAsync()
        {
            Console.WriteLine($"Operation started on thread {Environment.CurrentManagedThreadId}");
            Customer customer = new(4, "Mike");
            var isCustomerExists = await CustomerService.Create().IsCustomerExistAsync(customer.Id);
            if (isCustomerExists)
            {
                Console.WriteLine("Customer exists");
            }
            else
                Console.WriteLine("Customer doesn't exist");
            Console.WriteLine($"Operation finished on thread {Environment.CurrentManagedThreadId}");
        }
    }
}
