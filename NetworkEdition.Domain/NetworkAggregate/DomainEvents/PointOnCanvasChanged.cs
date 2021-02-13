using Foundation.DomainDrivenDesign;

namespace NetworkEdition.Domain.NetworkAggregate.DomainEvents
{
    public record PointOnCanvasChanged(RelayIdentifier RelayIdentity, Point Value) : DomainEvent;
}