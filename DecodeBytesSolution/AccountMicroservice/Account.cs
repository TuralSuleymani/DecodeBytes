namespace AccountMicroservice
{
    public class Account
    {
        public DateOnly CreatedDate { get; set; }

        public int Number { get; set; }

        public string? Summary { get; set; }
    }
}
