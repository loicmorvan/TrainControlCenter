using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkEdition.Application.Commands;
using NetworkEdition.Application.Events;
using NetworkEdition.Application.Queries;
using NetworkEdition.Domain.NetworkAggregate;
using NetworkEdition.ViewModels;
using Network = NetworkEdition.ViewModels.Network;

namespace NetworkEdition.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworksController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly INetworkQueries _queries;
        private readonly INetworkRepository _repository;

        public NetworksController(ICommandDispatcher commandDispatcher, INetworkQueries queries,
                                  INetworkRepository repository)
        {
            _commandDispatcher = commandDispatcher;
            _queries = queries;
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Network))]
        public IActionResult Create()
        {
            var events = _commandDispatcher.Dispatch(new CreateNetwork());

            var networkCreated = events.OfType<NetworkCreated>()
                                       .Single();

            var id = networkCreated.Identity;
            var network = _queries.Read(id);

            return CreatedAtAction(nameof(Read), new {identity = (Guid) id}, network);
        }

        [HttpGet]
        public IEnumerable<Network> ReadAll()
        {
            return _queries.ReadAll();
        }

        [HttpGet("{identity}")]
        public Network Read(Guid identity)
        {
            return _queries.Read(identity);
        }

        [HttpPut("{identity}")]
        public void ChangeName(Guid identity, NetworkProps networkProps)
        {
            _commandDispatcher.Dispatch(new ChangeName(identity, networkProps.Name));
        }

        [HttpDelete("{identity}")]
        public void Delete(Guid identity)
        {
            _commandDispatcher.Dispatch(new DeleteNetwork(identity));
        }
    }
}