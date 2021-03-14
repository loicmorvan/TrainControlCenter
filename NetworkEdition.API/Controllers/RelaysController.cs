using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetworkEdition.Application.Queries;
using NetworkEdition.Domain.NetworkAggregate;
using Relay = NetworkEdition.ViewModels.Relay;

namespace NetworkEdition.API.Controllers
{
    [ApiController]
    [Route("api/Networks/{networkId}/[controller]")]
    public class RelaysController : ControllerBase
    {
        private readonly IRelayQueries _relayQueries;

        public RelaysController(IRelayQueries relayQueries)
        {
            _relayQueries = relayQueries;
        }

        [HttpGet]
        public IEnumerable<Relay> ReadAll(Guid networkId)
        {
            return _relayQueries.ReadAll(networkId);
        }
    }
}