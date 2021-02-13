using System;
using Foundation.DomainDrivenDesign;

namespace NetworkEdition.Domain.NetworkAggregate
{
    public class RelayIdentifier : ValueObject<RelayIdentifier>
    {
        private readonly Guid _value;

        public RelayIdentifier(Guid value)
        {
            _value = value;
        }

        public static implicit operator Guid(RelayIdentifier toCast)
        {
            return toCast._value;
        }

        public static implicit operator RelayIdentifier(Guid value)
        {
            return new(value);
        }
    }
}