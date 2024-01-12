namespace FuncProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> filteredNumbers = numbers.Filter(x => x % 2 == 0);
            IEnumerable<string> transformedNumbers = filteredNumbers.Map(x => $"Number {x}");

            foreach (string number in transformedNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
