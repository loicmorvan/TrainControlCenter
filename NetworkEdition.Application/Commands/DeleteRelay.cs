using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.Commands
{
    public record DeleteRelay(NetworkIdentifier NetworkId, RelayIdentifier RelayId);
}