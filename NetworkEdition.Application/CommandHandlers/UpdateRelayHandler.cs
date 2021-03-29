using System;
using Foundation.Application;
using NetworkEdition.Application.Commands;
using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.CommandHandlers
{
    public class UpdateRelayHandler : ICommandHandler<UpdateRelay>
    {
        private readonly INetworkRepository _repository;

        public UpdateRelayHandler(INetworkRepository repository)
        {
            _repository = repository;
        }

        public ApplicationEvent[] Handle(UpdateRelay command)
        {
            var (networkId, relayId, x, y) = command;

            var network = _repository.Read(networkId);

            if (x != null) network.UpdateRelayX(relayId, x.Value);

            if (y != null) network.UpdateRelayY(relayId, y.Value);

            _repository.Update(network);

            return Array.Empty<ApplicationEvent>();
        }
    }
}