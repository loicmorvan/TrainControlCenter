using System.Collections.Generic;
using Foundation.Application;
using NetworkEdition.Application.Commands;
using NetworkEdition.Application.Events;
using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.CommandHandlers
{
    public class CreateNetworkHandler : ICommandHandler<CreateNetwork>
    {
        private readonly INetworkRepository _networkRepository;

        public CreateNetworkHandler(INetworkRepository networkRepository)
        {
            _networkRepository = networkRepository;
        }

        public IEnumerable<ApplicationEvent> Handle(CreateNetwork command)
        {
            var id = _networkRepository.Create();

            yield return new NetworkCreated(id);
        }
    }
}