namespace BehindTheScenesOfDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> multipleDelegate = (d) => d * 5;
            Func<decimal, decimal> multiple2Delegate = (d) => d * 7;
            Console.WriteLine(multipleDelegate(6));
            Console.WriteLine(multiple2Delegate(6));
        }
    }
}
