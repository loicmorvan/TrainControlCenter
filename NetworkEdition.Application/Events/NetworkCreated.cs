using Foundation.Application;
using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.Events
{
    public record NetworkCreated(NetworkIdentifier Identity): ApplicationEvent;
}