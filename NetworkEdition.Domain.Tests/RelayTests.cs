using System;
using System.Linq;
using NetworkEdition.Domain.NetworkAggregate;
using Xunit;

namespace NetworkEdition.Domain.Tests
{
    public class RelayTests
    {
        [Fact]
        public void Test()
        {
            var network = new Network(Guid.NewGuid());

            var relayId1 = Guid.NewGuid();
            var relayId2 = Guid.NewGuid();

            network.CreateRelay(relayId1);
            network.CreateRelay(relayId2);
            
            network.UpdateRelayX(relayId1, 5);
            network.UpdateRelayX(relayId2, 10);

            var relay1 = network.Relays.Single(x => x.Id == relayId1);
            var relay2 = network.Relays.Single(x => x.Id == relayId2);
            
            Assert.Equal(5, relay1.PointOnCanvas.X);
            Assert.Equal(10, relay2.PointOnCanvas.X);
        }
    }
}