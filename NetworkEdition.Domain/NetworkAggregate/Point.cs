using Foundation.DomainDrivenDesign;

namespace NetworkEdition.Domain.NetworkAggregate
{
    public class Point : ValueObject<Point>
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Point Zero => new(0, 0);

        public double X { get; }

        public double Y { get; }
    }
}