using System.Collections.Generic;
using NetworkEdition.Domain.NetworkAggregate;
using Relay = NetworkEdition.ViewModels.Relay;

namespace NetworkEdition.Application.Queries
{
    public interface IRelayQueries
    {
        IEnumerable<Relay> ReadAll(NetworkIdentifier networkId);

        Relay Read(NetworkIdentifier networkId, RelayIdentifier relayId);
    }
}