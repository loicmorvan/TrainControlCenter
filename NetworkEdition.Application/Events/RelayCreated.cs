using Foundation.Application;
using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.Events
{
    public record RelayCreated(NetworkIdentifier NetworkId, RelayIdentifier RelayId) : ApplicationEvent;
}