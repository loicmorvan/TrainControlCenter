using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetworkEdition.Application.Queries;
using NetworkEdition.ViewModels;

namespace NetworkEdition.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetworkEditionController : ControllerBase
    {
        private readonly INetworkQueries _queries;

        public NetworkEditionController(INetworkQueries queries)
        {
            _queries = queries;
        }

        [HttpGet]
        public IEnumerable<Network> Get()
        {
            return _queries.GetAll();
        }

        [HttpPost]
        [Route("Create")]
        public void Create(string name)
        {
            // var command = new CreateNetwork("New network");
            //_commandDispatcher.Dispatch(command);
        }

        [HttpGet]
        [Route("Single")]
        public Network GetNetwork(Guid identity)
        {
            return _queries.Get(identity);
        }
    }
}