using LearningAspNETCOREWebAPI.Models;

namespace LearningAspNETCOREWebAPI.Data
{
    public class AccountDbContext
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        private AccountDbContext()
        {
            Accounts = new List<Account>()
            {
                new Account{ AccounType = AccounType.Main, Id = 1, Name = "Acc1", Number ="AC1",
                 Cards = new List<Card>() {
                   new Card{ Id = 1, Number = "3434-4455-4455-3444", ExpireDate = "06/28", HolderName = "Mr.Card1 holder"},
                   new Card{ Id = 2, Number = "1434-3355-4455-3444", ExpireDate = "06/28", HolderName = "Mr.Card2 holder"}
                 }
                },
                new Account{ AccounType = AccounType.Sub, Id = 2, Name = "Acc2", Number ="AC2",
                Cards = new List<Card>() {
                   new Card{ Id = 4, Number = "3434-0001-4455-8777", ExpireDate = "09/27", HolderName = "Mr.Card3 holder"},
                   new Card{ Id = 5, Number = "1434-0101-4455-8888", ExpireDate = "11/26", HolderName = "Mr.Card4 holder"}
                 }},

            };
        }

        public static AccountDbContext Current = new AccountDbContext();
    }
}
