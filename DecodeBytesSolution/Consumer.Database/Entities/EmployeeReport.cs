namespace Consumer.Database.Entities
{
    public record EmployeeReport
    {
        public Guid Id { get; init; }
        public Guid EmployeeId { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public EmployeeReport(Guid id, Guid employeeId, string name, string surname)
        {
            Id = id;
            EmployeeId = employeeId;
            Name = name;
            Surname = surname;
        }
    }
}
