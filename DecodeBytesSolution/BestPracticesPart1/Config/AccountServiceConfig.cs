using System.ComponentModel.DataAnnotations;

namespace BestPracticesPart1.Config
{
    public class AccountServiceConfig
    {
        public static string AccountService = "AccountService";
        public string Url { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        [StringLength(maximumLength:25,MinimumLength =20)]
        public string Password { get; set; } = string.Empty;
    }
}
