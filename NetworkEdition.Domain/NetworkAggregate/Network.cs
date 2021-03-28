using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.DomainDrivenDesign;
using NetworkEdition.Domain.NetworkAggregate.DomainEvents;

namespace NetworkEdition.Domain.NetworkAggregate
{
    public class Network : AggregateRoot<NetworkIdentifier>
    {
        private readonly EntityCollection<Relay, RelayIdentifier> _relays = new();
        private string _name = "Unnamed network";

        public Network(NetworkIdentifier identity) : base(identity)
        {
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;

                Publish(new NameChanged(Identity, value));
            }
        }

        public IEnumerable<Relay> Relays => _relays.AsEnumerable();

        public RelayIdentifier CreateRelay(RelayIdentifier relayIdentity)
        {
            var relay = new Relay(relayIdentity);

            _relays.Add(relay);

            Publish(new RelayCreated(Identity, relayIdentity));

            return relayIdentity;
        }

        public void RemoveRelay(RelayIdentifier relayIdentity)
        {
            if (!_relays.Remove(relayIdentity))
                throw new ArgumentException("The given identity does not identify a relay in this network.",
                    nameof(relayIdentity));

            Publish(new RelayRemoved(Identity, relayIdentity));
        }

        public void UpdateRelayX(RelayIdentifier relayId, double x)
        {
            var relay = _relays.TryGet(relayId) ?? throw new Exception();

            relay.PointOnCanvas = relay.PointOnCanvas with {X = x};
        }

        public void UpdateRelayY(RelayIdentifier relayId, double y)
        {
            var relay = _relays.TryGet(relayId) ?? throw new Exception();

            relay.PointOnCanvas = relay.PointOnCanvas with {Y = y};
        }
    }
}