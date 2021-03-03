using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetworkEdition.Application.Queries;
using NetworkEdition.Domain.NetworkAggregate;
using Network = NetworkEdition.ViewModels.Network;

namespace NetworkEdition.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetworksController : ControllerBase
    {
        private readonly INetworkQueries _queries;
        private readonly INetworkRepository _repository;

        public NetworksController(INetworkQueries queries, INetworkRepository repository)
        {
            _queries = queries;
            _repository = repository;
        }

        [HttpGet]
        [Route("List")]
        public IEnumerable<Network> GetList()
        {
            return _queries.GetAll();
        }

        [HttpGet]
        [Route("Create")]
        public Guid Create()
        {
            return _repository.Create().Identity;
        }

        [HttpGet]
        [Route("{identity}/Edit")]
        public Network Get(Guid identity)
        {
            return _queries.Get(identity);
        }

        [HttpDelete]
        [Route("{identity}")]
        public void Delete(Guid identity)
        {
            _repository.Delete(identity);
        }
    }
}