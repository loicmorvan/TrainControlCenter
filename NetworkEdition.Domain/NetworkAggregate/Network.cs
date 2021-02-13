using System;
using Foundation.DomainDrivenDesign;
using NetworkEdition.Domain.NetworkAggregate.DomainEvents;

namespace NetworkEdition.Domain.NetworkAggregate
{
    public class Network : AggregateRoot<NetworkIdentifier>
    {
        private readonly EntityCollection<Relay, RelayIdentifier> _relays = new();

        public Network(NetworkIdentifier identity) : base(identity)
        {
        }

        public void CreateRelay()
        {
            RelayIdentifier relayIdentity = Guid.NewGuid();
            var relay = new Relay(relayIdentity);

            _relays.Add(relay);

            Publish(new RelayCreated(Identity, relayIdentity));
        }

        public void RemoveRelay(RelayIdentifier relayIdentity)
        {
            if (!_relays.Remove(relayIdentity))
            {
                throw new ArgumentException("The given identity does not identify a relay in this network.",
                                            nameof(relayIdentity));
            }

            Publish(new RelayRemoved(Identity, relayIdentity));
        }
    }
}