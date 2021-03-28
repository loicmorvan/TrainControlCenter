namespace NetworkEdition.Domain.NetworkAggregate
{
    public record Point(double X, double Y)
    {
        public static Point Zero => new(0, 0);
    }
}