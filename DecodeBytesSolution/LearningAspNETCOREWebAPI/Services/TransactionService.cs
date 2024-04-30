namespace LearningAspNETCOREWebAPI.Services
{
    public class TransactionService
    {
        private readonly string _url;
        private readonly string _key;
        public TransactionService(IConfiguration configuration)
        {
            _url = configuration.GetSection("transactionservice")["url"];
            _key = configuration.GetSection("transactionservice").GetSection("key").Value;
        }
    }
}
