using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkEdition.Application.Queries;
using NetworkEdition.Domain.NetworkAggregate;
using Network = NetworkEdition.ViewModels.Network;

namespace NetworkEdition.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworksController : ControllerBase
    {
        private readonly INetworkQueries _queries;
        private readonly INetworkRepository _repository;

        public NetworksController(INetworkQueries queries, INetworkRepository repository)
        {
            _queries = queries;
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Network))]
        public IActionResult Create()
        {
            var id = _repository.Create();
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

        [HttpDelete("{identity}")]
        public void Delete(Guid identity)
        {
            _repository.Delete(identity);
        }
    }
}