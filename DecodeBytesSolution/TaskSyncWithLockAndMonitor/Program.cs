namespace TaskSyncWithLockAndMonitor
{
    public class Transaction
    {
        public bool IsDone { get; private set; } = false;//shared resource
        private static readonly object _locker = new object();
        public void Transfer(decimal amount)
        {
            lock (_locker)
            {
                if (!IsDone)//false
                {
                    Console.WriteLine($"Transfer process started {Environment.CurrentManagedThreadId}");
                    TransferMoney(amount);
                    Console.WriteLine($"Transfer process ended {Environment.CurrentManagedThreadId}");
                    IsDone = true;
                }
            }
           
        }

        private void TransferMoney(decimal amount)
        {
            Console.WriteLine($"Transfering {amount}....");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Transaction t = new Transaction();


            Task.Run(() =>
            {
                lock("Tural")///lock (this)
                {

                }
            });

            for (int i = 0; i < 3; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    t.Transfer(4000);
                });
            }

            Console.ReadLine();
        }
    }
}
