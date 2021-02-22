using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetworkEdition.Application.Queries;
using NetworkEdition.ViewModels;

namespace NetworkEdition.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetworkController : ControllerBase
    {
        private readonly INetworkQueries _queries;

        public NetworkController(INetworkQueries queries)
        {
            _queries = queries;
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
            return Guid.Empty;
        }

        [HttpGet]
        public Network Get(Guid identity)
        {
            return _queries.Get(identity);
        }
    }
}