using System;
using System.Collections.Generic;
using System.Linq;
using NetworkEdition.Application.Queries;
using NetworkEdition.Domain.NetworkAggregate;
using Network = NetworkEdition.Infrastructure.PersistenceModels.Network;
using Relay = NetworkEdition.ViewModels.Relay;

namespace NetworkEdition.Infrastructure
{
    public class NetworkQueries : INetworkQueries
    {
        private readonly IDictionary<NetworkIdentifier, Network> _networks;

        public NetworkQueries(IDictionary<NetworkIdentifier, Network> networks)
        {
            _networks = networks;
        }

        public IEnumerable<ViewModels.Network> ReadAll()
        {
            return _networks.Values
                            .Select(Convert);
        }

        public ViewModels.Network Read(Guid identity)
        {
            return Convert(_networks[identity]);
        }

        private static ViewModels.Network Convert(Network persistenceModel)
        {
            var (identity, name, relays) = persistenceModel;
            return new ViewModels.Network(identity,
                                          name,
                                          relays.Select(Convert)
                                                .ToArray());
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