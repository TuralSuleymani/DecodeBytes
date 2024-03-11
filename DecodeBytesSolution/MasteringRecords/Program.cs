using System.Runtime.CompilerServices;
using System.Text;

namespace MasteringRecords
{
    record  Account(string AccountNumber, string AccountName)
    {
        public string AccountNumber { get; set; } = AccountNumber;
        public int AccountId { get; init; }
    }

    record struct Id(Guid Value)
    {
        public Guid Value { get; init; } =
            Value == Guid.Empty ? throw new ArgumentException("Dont call default construct") : Value;
        public Id() : this(Guid.Empty) { }
    }

    class CAccount(string AccountNumber, string AccountName):IEquatable<CAccount>
    {
        public string AccountNumber { get; init; } = AccountNumber;
        public string AccountName { get; init; } = AccountName;

        public void Deconstruct(out string AccountNumber, out string AccountName)
        {
            AccountNumber = this.AccountNumber;
            AccountName = this.AccountName;
        }

        public bool Equals(CAccount? other)
        {
            return other is not null 
                && other.AccountName == this.AccountName 
                && other.AccountNumber == this.AccountNumber;
        }
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as CAccount);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.AccountNumber, this.AccountName);
        }
        public static bool operator ==(CAccount first, CAccount second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(CAccount first, CAccount second)
        {
            return !first.Equals(second);
        }
        [CompilerGenerated]
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("CAccount");
            builder.Append(" { ");
            if (this.PrintMembers(builder))
                builder.Append(' ');
            builder.Append('}');
            return builder.ToString();
        }

        [CompilerGenerated]
        protected virtual bool PrintMembers(StringBuilder builder)
        {
            RuntimeHelpers.EnsureSufficientExecutionStack();
            builder.Append("AccountNumber = ");
            builder.Append((object)this.AccountNumber);
            builder.Append(", AccountName = ");
            builder.Append((object)this.AccountName);
            return true;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new ("345666", "Mr.Name");
            Account account2 = new("345666", "Mr.Name");

            account.AccountNumber = "sddsfdfsd";

            CAccount caccount = new("345666", "Mr.Name");
            CAccount caccount2 = new("345666", "Mr.Name");

            Id id = new Id();
            
            Console.WriteLine(caccount);
            Console.WriteLine(account);

            Console.WriteLine("Hello, World!");
        }
    }
}
