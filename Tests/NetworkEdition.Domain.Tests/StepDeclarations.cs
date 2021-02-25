using System;
using FluentAssertions;
using NetworkEdition.Domain.NetworkAggregate;
using TechTalk.SpecFlow;

namespace NetworkEdition.Domain.Tests
{
    [Binding]
    public class StepDeclarations
    {
        private readonly ScenarioContext _context;

        public StepDeclarations(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"a Guid")]
        public void GivenAGuid()
        {
            _context.Add("identity", Guid.NewGuid());
        }

        [When(@"creating a network")]
        public void WhenCreatingANetwork()
        {
            var identity = _context.Get<Guid>("identity");

            var network = new Network(identity);

            _context.Add("network", network);
        }

        [Then(@"should work")]
        public void ThenShouldWork()
        {
            var network = _context.Get<Network>("network");

            network.Should().NotBeNull();
        }

        [Given(@"a network")]
        public void GivenANetwork()
        {
            _context.Add("network", new Network(Guid.NewGuid()));
            _context.Add("relayIdentity", Guid.NewGuid());
        }

        [When(@"adding a relay")]
        public void WhenAddingARelay()
        {
            var network = _context.Get<Network>("network");
            var relayIdentity = _context.Get<Guid>("relayIdentity");

            network.CreateRelay(relayIdentity);
        }

        [Then(@"should contain the relay")]
        public void ThenShouldContainTheRelay()
        {
            var network = _context.Get<Network>("network");
            var relayIdentity = _context.Get<Guid>("relayIdentity");

            network.Relays.Should().Contain(x => x.Identity == relayIdentity);
        }
    }
}