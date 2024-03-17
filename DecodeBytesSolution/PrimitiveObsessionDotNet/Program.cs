﻿using CSharpFunctionalExtensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrimitiveObsessionDotNet
{
    public record AccountNumber
    {
        private readonly string _value;
        private AccountNumber(string number)
        {
            _value = number;
        }
        public static Result<AccountNumber> Create(string number)
        {
            if (number == null)
                return Result.Failure<AccountNumber>("Number can't be null");
            number = number.Trim();
            if (number.Length is not (>= 6 and <= 10))
            {
                return Result.Failure<AccountNumber>("Number should be between 6 and 10 character");
            }

            return Result.Success(new AccountNumber(number));
        }
    }

    public record AccountName
    {
        private readonly string _value;
        private AccountName(string name)
        {
            _value = name;
        }
        public static Result<AccountName> Create(string name)
        {
            if (name == null)
                return Result.Failure<AccountName>("Name can't be null");
            name = name.Trim();
            if (name.Length is not (>= 6 and <= 12))
            {
                return Result.Failure<AccountName>("Name should be between 6 and 12 character");
            }
            return Result.Success(new AccountName(name));
        }
    }

    class AccountService
    {
        public void ChangeNumber(AccountNumber accountNumber)
        {

        }

        public void CreateNumber(AccountNumber accountNumber)
        {

        }
    }

    public class AccountFactory
    {
        //create, throw
        public static Account CreateAccount(AccountName Name, AccountNumber Number)
        {
            return new Account(Name, Number);
        }
    }

    public record Account(AccountName Name, AccountNumber Number) { }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
