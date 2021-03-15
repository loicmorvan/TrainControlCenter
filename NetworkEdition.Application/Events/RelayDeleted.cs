using Foundation.Application;
using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.Events
{
    public record RelayDeleted(NetworkIdentifier NetworkId, RelayIdentifier RelayId) : ApplicationEvent;
}