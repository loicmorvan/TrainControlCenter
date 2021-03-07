using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.Commands
{
    public record DeleteNetwork(NetworkIdentifier NetworkIdentity);
}