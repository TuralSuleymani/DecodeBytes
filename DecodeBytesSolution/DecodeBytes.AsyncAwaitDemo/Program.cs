using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace DecodeBytes.AsyncAwaitDemo
{
    internal class Program
    {
        #region Sync version
        static void Calculate(decimal firstNumber, decimal secondNumber)
        {
            Console.WriteLine($"Operation started in Thread {Environment.CurrentManagedThreadId}");
            Console.WriteLine($"The result is {Sum(firstNumber, secondNumber)}");
            Console.WriteLine($"Operation finished in Thread {Environment.CurrentManagedThreadId}");
        }
        static decimal Sum(decimal firstNumber, decimal secondNumber)
        {
            Console.WriteLine($"Sum is running in Thread {Environment.CurrentManagedThreadId}");
            return firstNumber + secondNumber;
        }
        #endregion

        #region V2
        static void CalculateV2(decimal firstNumber, decimal secondNumber)
        {
            Console.WriteLine($"Operation started in Thread {Environment.CurrentManagedThreadId}");
            Task sumTask = Task.Factory.StartNew(() =>
            {
                Sum(firstNumber, secondNumber);
            });
            //...any addition operation...
            TaskAwaiter sumAwaiter = sumTask.GetAwaiter();
            sumAwaiter.OnCompleted(() => Console.WriteLine($"Operation finished in Thread {Environment.CurrentManagedThreadId}"));
            Console.WriteLine($"Operation continues in Thread {Environment.CurrentManagedThreadId}");

        }
        #endregion

        #region V3
        static async Task CalculateV3(decimal firstNumber, decimal secondNumber)
        {
            Console.WriteLine($"Operation started in Thread {Environment.CurrentManagedThreadId}");
            Console.WriteLine($"The result is {await SumAsync(firstNumber, secondNumber)}");
            Console.WriteLine($"Operation finished in Thread {Environment.CurrentManagedThreadId}");
        }

        static async Task<decimal> SumAsync(decimal firstNumber, decimal secondNumber)
        {
            //await Task.Delay(TimeSpan.FromMilliseconds(10));
            Console.WriteLine($"Sum is running in Thread {Environment.CurrentManagedThreadId}");
            return await Task.FromResult( firstNumber + secondNumber);
        }
        #endregion

        static async Task Main(string[] args)
        {
           await CalculateV3(45, 67);
        }

        #region one more example
        static async Task<string> GetContentAsync(string requestUri)
        {
            return await new HttpClient().GetStringAsync(requestUri);
        }
        #endregion
    }
}
