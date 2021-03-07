using System.Collections.Generic;
using Foundation.Application;
using NetworkEdition.Application.Commands;
using NetworkEdition.Application.Events;
using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.CommandHandlers
{
    public class DeleteNetworkHandler: ICommandHandler<DeleteNetwork>
    {
        private readonly INetworkRepository _repository;

        public DeleteNetworkHandler(INetworkRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<ApplicationEvent> Handle(DeleteNetwork command)
        {
            _repository.Delete(command.NetworkIdentity);

            yield return new NetworkDeleted(command.NetworkIdentity);
        }
    }
}