﻿namespace BehindTheScenesOfDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> multipleDelegate = (d) => d * 4;
            Console.WriteLine(multipleDelegate(5));
        }
    }
}
