using Foundation.Application;
using NetworkEdition.Application.Commands;
using NetworkEdition.Application.Events;
using NetworkEdition.Domain.NetworkAggregate;

namespace NetworkEdition.Application.CommandHandlers
{
    public class ChangeNameHandler : ICommandHandler<ChangeName>
    {
        private readonly INetworkRepository _repository;

        public ChangeNameHandler(INetworkRepository repository)
        {
            _repository = repository;
        }

        public ApplicationEvent[] Handle(ChangeName command)
        {
            var (networkIdentifier, name) = command;

            var network = _repository.Read(networkIdentifier);

            network.Name = name;

            _repository.Update(network);

            return new ApplicationEvent[]
            {
                new NameChanged(networkIdentifier, name)
            };
        }
    }
}