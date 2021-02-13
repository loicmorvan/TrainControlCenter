using System;
using Foundation.DomainDrivenDesign;

namespace NetworkEdition.Domain.NetworkAggregate
{
    public class NetworkIdentifier : ValueObject<NetworkIdentifier>
    {
        private readonly Guid _value;

        public NetworkIdentifier(Guid value)
        {
            _value = value;
        }

        public static implicit operator Guid(NetworkIdentifier toCast)
        {
            return toCast._value;
        }

        public static implicit operator NetworkIdentifier(Guid value)
        {
            return new (value);
        }
    }
}