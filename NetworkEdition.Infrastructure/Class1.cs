using System.Collections.Generic;
using System.Linq;
using NetworkEdition.Application.Models;
using NetworkEdition.Application.Queries;

namespace NetworkEdition.Infrastructure
{
    public class NetworkQueries : INetworkQueries
    {
        public IEnumerable<Network> GetAll()
        {
            return Enumerable.Empty<Network>();
        }
    }
}