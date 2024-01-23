
namespace TasksInPractice
{

    internal class Program
    {
        static async Task Main(string[] args)
        {
            //images, videos,text
            //effective
            //2 steps vs 1 step
            //sync/con

            //inherit from the Task
            //race condition

            //Task myTask = null;
            //myTask = new Task(() =>
            //{
            //    myTask.ContinueWith(myNextOperation);

            //});

            //myTask.Start();
            //buggy

            Task.Factory.StartNew(() => { }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);

            var processBitmap = Task.Run(async () =>
            {
               await Task.Delay(1000);
                return 300;
            });

            //var processBitmap = Task.Factory.StartNew(() =>
            //{
            //   return Task.Factory.StartNew<decimal>(() =>
            //    {
            //        Task.Delay(1000);
            //        return 300;
            //    });
            //});

            await processBitmap;
            Console.WriteLine("Hello, World!");

            //Task<Bitmap> processBitmap = Task.Run<Bitmap>(() =>
            //{
            //    string imagePath = "myimage.png";
            //    return Applyfilters(imagePath);
            //});

            //await processBitmap;
            //Console.WriteLine("Hello, World!");

            Console.ReadLine();
        }

        private static void myNextOperation(Task task)
        {
            throw new NotImplementedException();
        }

        private static Bitmap Applyfilters(string imagePath)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Processing is done");
            return new Bitmap() { Name = "randomgeneratedName" };
        }
    }
}
