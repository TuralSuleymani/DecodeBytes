using System.Runtime.InteropServices;

namespace User32ConsoleApp
{
    internal class Program
    {

        [DllImport("file.dll")]
        private static extern int multiply(int a, int b);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr owner, string message, string caption, uint type);
        //MessageBox
        static void Main(string[] args)
        {
            const int MS_OK = 0;
            const int MS_OKCANCEL = 1;
            const int MS_STOP = 16;
            //MessageBox(IntPtr.Zero, "Hello from user32 dll", "Simple message", MS_STOP);

            Console.WriteLine(multiply(4, 5));

            Console.WriteLine("Hello, World!");
        }
    }
}
