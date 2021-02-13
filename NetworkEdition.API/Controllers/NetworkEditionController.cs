using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetworkEdition.Application.Commands;
using NetworkEdition.Application.Models;
using NetworkEdition.Application.Queries;

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
            var command = new CreateNetwork("New network");
            //_commandDispatcher.Dispatch(command);
        }
    }
}