namespace FunctionProgrammingInPractice
{
    class Account
    {
        public int Number { get; set; } = 67;

        //not functional
        public int GetCalculatedData(int data, int data2)
        {
            int internalData = 44;
            if (data < 0 || data2 < 0)
            {
                throw new ArgumentException("Negative values are not allowed");
            }
            Number = data2 * data * internalData;
            return Number;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            Console.WriteLine(account.GetCalculatedData(56, 2));
            Console.WriteLine(account.GetCalculatedData(56, 2));
            Console.ReadLine();
        }
    }
}
