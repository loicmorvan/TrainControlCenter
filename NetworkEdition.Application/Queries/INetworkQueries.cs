using System;
using System.Collections.Generic;
using NetworkEdition.ViewModels;

namespace NetworkEdition.Application.Queries
{
    public interface INetworkQueries
    {
        IEnumerable<Network> GetAll();

        Network Get(Guid identity);
    }
}