﻿using System;
using System.Collections.Generic;
using System.Linq;
using NetworkEdition.Application.Queries;
using NetworkEdition.ViewModels;

namespace NetworkEdition.Infrastructure
{
    public class NetworkQueries : INetworkQueries
    {
        private readonly IDictionary<Guid, Network> _networks = new[]
        {
            new Network(new Guid("590F19C8-A2CC-4909-8102-CD87FCDC4890"), "Pouet", Enumerable.Empty<Relay>()),
            new Network(new Guid("77CDB7D7-5CD4-4A02-8CCB-F08B65DF3790"), "Salut", Enumerable.Empty<Relay>()),
            new Network(new Guid("EEDD30EC-60A6-4FC5-A55D-7C493339C2A9"), "Hello", Enumerable.Empty<Relay>()),
            new Network(new Guid("85D8859E-D21E-417C-B2F5-C0B158C00B4B"), "Pass", Enumerable.Empty<Relay>())
        }.ToDictionary(x => x.Identity);

        public IEnumerable<Network> GetAll()
        {
            return _networks.Values;
        }

        public Network Get(Guid identity)
        {
            return _networks[identity];
        }
    }
}