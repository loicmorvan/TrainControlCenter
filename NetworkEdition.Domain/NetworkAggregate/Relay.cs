using Foundation.DomainDrivenDesign;

namespace NetworkEdition.Domain.NetworkAggregate
{
    public class Relay : Entity<RelayIdentifier>
    {
        public Relay(RelayIdentifier identity) : base(identity)
        {
        }
    }
}