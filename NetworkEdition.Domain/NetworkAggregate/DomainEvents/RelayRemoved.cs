using Foundation.DomainDrivenDesign;

namespace NetworkEdition.Domain.NetworkAggregate.DomainEvents
{
    public record RelayRemoved(NetworkIdentifier NetworkIdentifier, RelayIdentifier RelayIdentity) : DomainEvent;
}