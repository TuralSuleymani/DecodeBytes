using System.Diagnostics.CodeAnalysis;

namespace SingletonDesignPattern
{
    public sealed class DCheckFileResource
    {
        private static volatile DCheckFileResource _instance;
        private static readonly object _lock = new object();
        private DCheckFileResource() { }
        public static DCheckFileResource Instance
        {
            get
            {
                if (_instance == null)//first check
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DCheckFileResource();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    //concurrency
    //lazy loading
    public sealed class LazyFileResource
    {
        private LazyFileResource() { }
        private static readonly Lazy<LazyFileResource> lazy 
            = new Lazy<LazyFileResource>(() => new LazyFileResource());

        public static LazyFileResource Instance { get { return lazy.Value; } }
    }

    public sealed class FileResource
    {
        private FileResource() { }
        private static FileResource _instance = null;
        public static FileResource GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FileResource();
            }
            return _instance;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //FileResource fileResource = FileResource.GetInstance();
            LazyFileResource lazyFileResource =  LazyFileResource.Instance;
            Console.WriteLine("Hello, World!");
        }
    }
}
