using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkEdition.Application.Commands;
using NetworkEdition.Application.Events;
using NetworkEdition.Application.Queries;
using NetworkEdition.ViewModels;

namespace NetworkEdition.API.Controllers
{
    [ApiController]
    [Route("api/Networks/{networkId}/[controller]")]
    public class RelaysController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IRelayQueries _relayQueries;

        public RelaysController(ICommandDispatcher commandDispatcher, IRelayQueries relayQueries)
        {
            _commandDispatcher = commandDispatcher;
            _relayQueries = relayQueries;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create(Guid networkId)
        {
            var events = _commandDispatcher.Dispatch(new CreateRelay(networkId));

            var relayCreated = events.OfType<RelayCreated>()
                .Single();

            var relay = _relayQueries.Read(networkId, relayCreated.RelayId);

            return CreatedAtAction(nameof(Read), new {networkId, relayCreated.RelayId}, relay);
        }

        [HttpPatch("{relayId}")]
        public void Update(Guid networkId, Guid relayId, RelayParams parameters)
        {
            _commandDispatcher.Dispatch(new UpdateRelay(networkId, relayId, parameters.X, parameters.Y));
        }

        [HttpGet("{relayId}")]
        public Relay Read(Guid networkId, Guid relayId)
        {
            return _relayQueries.Read(networkId, relayId);
        }

        [HttpGet]
        public IEnumerable<Relay> ReadAll(Guid networkId)
        {
            return _relayQueries.ReadAll(networkId);
        }

        [HttpDelete("{relayId}")]
        public void Delete(Guid networkId, Guid relayId)
        {
            _commandDispatcher.Dispatch(new DeleteRelay(networkId, relayId));
        }
    }
}