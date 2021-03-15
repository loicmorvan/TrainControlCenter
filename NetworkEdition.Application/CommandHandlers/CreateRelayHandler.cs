using System;
using Foundation.Application;
using NetworkEdition.Application.Commands;
using NetworkEdition.Domain.NetworkAggregate;
using NetworkEdition.Domain.NetworkAggregate.DomainEvents;
using RelayCreated = NetworkEdition.Application.Events.RelayCreated;

namespace NetworkEdition.Application.CommandHandlers
{
    public class CreateRelayHandler: ICommandHandler<CreateRelay>
    {
        private readonly INetworkRepository _networkRepository;

        public CreateRelayHandler(INetworkRepository networkRepository)
        {
            _networkRepository = networkRepository;
        }
        
        public ApplicationEvent[] Handle(CreateRelay command)
        {
            var network = _networkRepository.Read(command.NetworkId);

            var relayId = Guid.NewGuid();
            network.CreateRelay(relayId);

            _networkRepository.Update(network);

            return new ApplicationEvent[]
            {
                new RelayCreated(command.NetworkId, relayId)
            };
        }
    }
}