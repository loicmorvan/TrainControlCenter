using System.Collections.Generic;
using NetworkEdition.Application.Models;
using NetworkEdition.Application.Queries;

namespace NetworkEdition.Infrastructure
{
    public class NetworkQueries : INetworkQueries
    {
        public IEnumerable<Network> GetAll()
        {
            return new[]
            {
                new Network
                {
                    Name = "Pouet"
                },
                new Network
                {
                    Name = "Salut"
                },
                new Network
                {
                    Name = "Hello"
                },
                new Network
                {
                    Name = "Pass"
                }
            };
        }
    }
}