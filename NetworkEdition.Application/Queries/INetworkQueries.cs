using System.Collections.Generic;
using NetworkEdition.Application.Models;

namespace NetworkEdition.Application.Queries
{
    public interface INetworkQueries
    {
        IEnumerable<Network> GetAll();
    }
}