namespace HotToConcurrencyEp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The how to of Concurrency in C#. Ep1");
            //captured variables
            //string str = "Tural";

            //Action act=()=>Console.WriteLine(str);

            //str = "Change name";

            //act();

            for(int i = 0; i < 10; i++)
            {
                int temp = i;
                new Thread(() =>
                {
                    Console.Write(temp + " ");
                }).Start();
            }
            
            Console.ReadLine();

        }
    }
}
