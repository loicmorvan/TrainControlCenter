using System;
using System.Collections.Generic;
using System.Linq;
using NetworkEdition.Domain.NetworkAggregate;
using Network = NetworkEdition.Infrastructure.PersistenceModels.Network;
using Relay = NetworkEdition.Infrastructure.PersistenceModels.Relay;

namespace NetworkEdition.Infrastructure
{
    public class NetworkRepository : INetworkRepository
    {
        private readonly IDictionary<NetworkIdentifier, Network> _networks;

        public NetworkRepository(IDictionary<NetworkIdentifier, Network> networks)
        {
            _networks = networks;
        }

        public Domain.NetworkAggregate.Network Create()
        {
            var identity = Guid.NewGuid();
            var network = new Network(identity,
                                      "Unnamed network",
                                      Enumerable.Empty<Relay>());

            _networks.Add(identity, network);

            return Convert(network);
        }

        public Domain.NetworkAggregate.Network Read(NetworkIdentifier id)
        {
            return Convert(_networks[id]);
        }

        public void Update(Domain.NetworkAggregate.Network network)
        {
            _networks[network.Identity] = Convert(network);
        }

        public void Delete(NetworkIdentifier id)
        {
            _networks.Remove(id);
        }

        private static Domain.NetworkAggregate.Network Convert(Network persistenceModel)
        {
            var domainModel = new Domain.NetworkAggregate.Network(persistenceModel.Identity);

            foreach (var relay in persistenceModel.Relays) domainModel.CreateRelay(relay.Identity);
            // TODO: relay parameters

            return domainModel;
        }

        private static Network Convert(Domain.NetworkAggregate.Network domainModel)
        {
            return new(domainModel.Identity,
                       domainModel.Name,
                       domainModel.Relays
                                  .Select(Convert));
        }

        private static Relay Convert(Domain.NetworkAggregate.Relay domainModel)
        {
            return new(domainModel.Identity,
                       domainModel.Name,
                       domainModel.IsClosed,
                       domainModel.PointOnCanvas.X,
                       domainModel.PointOnCanvas.Y);
        }
    }
}