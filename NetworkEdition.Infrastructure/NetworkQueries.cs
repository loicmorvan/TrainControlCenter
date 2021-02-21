using System;
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
            new Network(
                new Guid("590F19C8-A2CC-4909-8102-CD87FCDC4890"),
                "Pouet",
                new[]
                {
                    new Relay(
                        new Guid("DD06A8A6-C142-43D8-8E77-7CCD144AE7D6"),
                        "Relay 1",
                        100, 100),
                    new Relay(
                        new Guid("78FAD7F4-84D4-43FE-BC55-FF195FC4AD2D"),
                        "Relay 2",
                        250, 100),
                    new Relay(
                        new Guid("B71411BB-98D3-448C-9E8D-D38B1A8752AA"),
                        "Relay 3",
                        100, 250),
                    new Relay(
                        new Guid("627E0D8C-7E24-4DEC-987D-6DFBD91F5CBB"),
                        "Relay 4",
                        250, 250)
                }),
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