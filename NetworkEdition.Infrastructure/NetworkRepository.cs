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

        public NetworkIdentifier Create()
        {
            var identity = Guid.NewGuid();
            var network = new Network(identity,
                "Unnamed network",
                Array.Empty<Relay>());

            _networks.Add(identity, network);

            return identity;
        }

        public Domain.NetworkAggregate.Network Read(NetworkIdentifier id)
        {
            return Convert(_networks[id]);
        }

        public void Update(Domain.NetworkAggregate.Network network)
        {
            _networks[network.Id] = Convert(network);
        }

        public void Delete(NetworkIdentifier id)
        {
            _networks.Remove(id);
        }

        private static Domain.NetworkAggregate.Network Convert(Network persistenceModel)
        {
            var domainModel = new Domain.NetworkAggregate.Network(persistenceModel.Id);

            foreach (var relay in persistenceModel.Relays)
            {
                domainModel.CreateRelay(relay.Id);

                domainModel.UpdateRelayX(relay.Id, relay.X);
                domainModel.UpdateRelayY(relay.Id, relay.Y);
            }

            return domainModel;
        }

        private static Network Convert(Domain.NetworkAggregate.Network domainModel)
        {
            return new(
                domainModel.Id,
                domainModel.Name,
                domainModel.Relays
                    .Select(Convert)
                    .ToArray());
        }

        private static Relay Convert(Domain.NetworkAggregate.Relay domainModel)
        {
            return new(
                domainModel.Id,
                domainModel.Name,
                domainModel.IsClosed,
                domainModel.PointOnCanvas.X,
                domainModel.PointOnCanvas.Y);
        }
    }
}