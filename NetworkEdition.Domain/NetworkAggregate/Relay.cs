using Foundation.DomainDrivenDesign;
using NetworkEdition.Domain.NetworkAggregate.DomainEvents;

namespace NetworkEdition.Domain.NetworkAggregate
{
    public class Relay : Entity<RelayIdentifier>
    {
        private Point _pointOnCanvas = Point.Zero;

        public Relay(RelayIdentifier identity) : base(identity)
        {
        }

        public Point PointOnCanvas
        {
            get => _pointOnCanvas;
            set
            {
                _pointOnCanvas = value;

                Publish(new PointOnCanvasChanged(Identity, value));
            }
        }

        public string Name { get; internal set; } = "Unnamed relay";

        public bool IsClosed { get; internal set; } = false;
    }
}