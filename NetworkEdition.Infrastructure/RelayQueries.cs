using System.Collections.Generic;
using System.Linq;
using NetworkEdition.Application.Queries;
using NetworkEdition.Domain.NetworkAggregate;
using Network = NetworkEdition.Infrastructure.PersistenceModels.Network;
using Relay = NetworkEdition.ViewModels.Relay;

namespace NetworkEdition.Infrastructure
{
    public class RelayQueries : IRelayQueries
    {
        private readonly IDictionary<NetworkIdentifier, Network> _networks;

        public RelayQueries(IDictionary<NetworkIdentifier, Network> networks)
        {
            _networks = networks;
        }

        public IEnumerable<Relay> ReadAll(NetworkIdentifier networkId)
        {
            var network = _networks[networkId];

            return network.Relays.Select(Convert);
        }

        private static Relay Convert(PersistenceModels.Relay persistenceModel)
        {
            return new(persistenceModel.Identity,
                       persistenceModel.Name,
                       persistenceModel.X,
                       persistenceModel.Y);
        }
    }
}