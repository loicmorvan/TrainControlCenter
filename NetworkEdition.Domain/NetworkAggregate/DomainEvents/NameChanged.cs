using Foundation.DomainDrivenDesign;

namespace NetworkEdition.Domain.NetworkAggregate.DomainEvents
{
    public record NameChanged(NetworkIdentifier Identifier, string Value) : DomainEvent;
}