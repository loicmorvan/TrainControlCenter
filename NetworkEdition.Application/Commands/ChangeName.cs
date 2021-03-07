using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.Commands
{
    public record ChangeName(NetworkIdentifier Id, string Name);
}