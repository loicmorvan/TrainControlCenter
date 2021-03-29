using Foundation.Application;
using NetworkEdition.Application.Commands;
using NetworkEdition.Application.Events;
using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.CommandHandlers
{
    public class DeleteRelayHandler : ICommandHandler<DeleteRelay>
    {
        private readonly INetworkRepository _networkRepository;

        public DeleteRelayHandler(INetworkRepository networkRepository)
        {
            _networkRepository = networkRepository;
        }

        public ApplicationEvent[] Handle(DeleteRelay command)
        {
            var network = _networkRepository.Read(command.NetworkId);

            network.RemoveRelay(command.RelayId);

            _networkRepository.Update(network);

            return new ApplicationEvent[]
            {
                new RelayDeleted(command.NetworkId, command.RelayId)
            };
        }
    }
}