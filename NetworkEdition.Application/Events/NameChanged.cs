using Foundation.Application;
using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.Events
{
    public record NameChanged(NetworkIdentifier Id, string Name) : ApplicationEvent;
}