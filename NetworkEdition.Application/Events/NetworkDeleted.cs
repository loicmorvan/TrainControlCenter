using Foundation.Application;
using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.Events
{
    public record NetworkDeleted(NetworkIdentifier NetworkIdentity) : ApplicationEvent;
}