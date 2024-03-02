namespace FunctionProgrammingIntro
{
    public class Point
    {
        public  int X { get; } // Read-only property with init accessor
        public  int Y { get; } // Read-only property with init accessor

        public Point(int x, int y) // Constructor to initialize the readonly fields
        {
            X = x;
            Y = y;
        }

        // No setter methods defined for X and Y to prevent modifications

        // Optional methods for creating new instances with modifications:
        public Point MoveX(int deltaX) => new Point(X + deltaX, Y);
        public Point MoveY(int deltaY) => new Point(X, Y + deltaY);
    }
}
