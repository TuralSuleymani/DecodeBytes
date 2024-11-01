namespace AccountMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
                {
                    "Standard Account", "Premium Account", "Gold Member"
                    , "Silver Member", "Bronze Member", "VIP Client", "Preferred Customer",
                        "Platinum", "Diamond", "Elite"
                };


            app.MapGet("/account", (HttpContext httpContext) =>
            {
                string name = "account2";
                var accounts = Enumerable.Range(1, 5).Select(index =>
                    new Account
                    {
                        CreatedDate = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Number = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return accounts;
            });

            app.Run();
        }
    }
}
