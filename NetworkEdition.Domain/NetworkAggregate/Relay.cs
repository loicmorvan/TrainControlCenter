using Foundation.DomainDrivenDesign;
using NetworkEdition.Domain.NetworkAggregate.DomainEvents;

namespace NetworkEdition.Domain.NetworkAggregate
{
    public class Relay : Entity<RelayIdentifier>
    {
        private Point _pointOnCanvas;

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
    }
}