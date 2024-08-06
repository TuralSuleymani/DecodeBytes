using System.Reactive.Subjects;

namespace RxImplementation
{
    public class Location
    {
        public float Long { get; set; }
        public float Lat { get; set; }
        public override string ToString()
        {
            return $"Long = {Long} & Lat = {Lat}";
        }
    }

    //Observer = subscriber
    public class LocationTracker : IObserver<Location>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Streaming is done");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.Message);
        }

        public void OnNext(Location value)
        {
            Console.WriteLine(value);
        }
    }

    public class LocationSubject : IObservable<Location>
    {
        private readonly List<IObserver<Location>> _locationTrackers;
        public LocationSubject()
        {
            _locationTrackers = new List<IObserver<Location>>();
        }
        public IDisposable Subscribe(IObserver<Location> observer)
        {
           if(!_locationTrackers.Contains(observer))
            {
                _locationTrackers.Add(observer);
            }

            return new Unsubscriber(this, observer);
        }
        internal class Unsubscriber(LocationSubject locationSubject, IObserver<Location> observer) : IDisposable
        {
            private readonly LocationSubject _locationSubject = locationSubject;
            private readonly IObserver<Location> _observer = observer;

            public void Dispose()
            {
                _locationSubject._locationTrackers.Remove(_observer);
            }
        }

        internal void OnNext()
        {
            Location location = new Location() { Lat = 67.5f, Long = 56.3f };
            foreach (var locationTracker in _locationTrackers)
            {
                locationTracker.OnNext(location);
            }
        }
    }

   

    internal class Program
    {
        static void Main(string[] args)
        {
            Subject<Location> locationSubject = new Subject<Location>();
            //LocationSubject locationSubject = new LocationSubject();
            LocationTracker locationTracker1 = new LocationTracker();
            LocationTracker locationTracker2 = new LocationTracker();
            LocationTracker locationTracker3 = new LocationTracker();

            locationSubject.Subscribe(locationTracker1);
            locationSubject.Subscribe(locationTracker2);
            locationSubject.Subscribe(locationTracker3);

            locationSubject.OnNext(new Location() { Long = 34.5f, Lat = 67.8f });

        }
    }
}
