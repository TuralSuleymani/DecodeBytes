namespace DelegatesVSEvents
{
    public class Account(string name, string number)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Number { get; private set; } = number;
        public string Name { get; private set; } = name;

        #region event section
        public event Action<Guid,string, string>? AccountChanged;

        #endregion
        public void ChangeNumber(string number)
        {
            string oldNumber = Number;
            Number = number;
            AccountChanged?.Invoke(Id,oldNumber, Number);
        }
        
    }
}
