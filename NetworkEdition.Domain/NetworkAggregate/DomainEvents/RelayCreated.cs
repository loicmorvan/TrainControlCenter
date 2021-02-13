using Foundation.DomainDrivenDesign;

namespace NetworkEdition.Domain.NetworkAggregate.DomainEvents
{
    public record RelayCreated(NetworkIdentifier NetworkIdentity, RelayIdentifier RelayIdentity) : DomainEvent;
}