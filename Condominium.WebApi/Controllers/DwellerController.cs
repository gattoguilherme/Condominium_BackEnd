using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominiumContext.Domain.Commands;
using CondominiumContext.Domain.Entities;
using CondominiumContext.Domain.Handlers;
using CondominiumContext.Domain.Repositories;
using CondominiumContext.Shared.Commands;
using Microsoft.AspNetCore.Authorization;

namespace Condominium.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DwellerController : ControllerBase
    {
        [Route("create")]
        [HttpPost]
        public ICommandResult Create([FromBody] DwellerCreateCommand command)
        {
            var mockRepo = new MockRepository();
            var handler = new DwellerHandler(mockRepo);

            return handler.Handle(command);
        }

        [HttpGet]
        [Authorize(Roles = "role2")]
        [Route("getById")]
        public ICommandResult GetById()
        {
            var dwellerId = Convert.ToInt32(Request.Headers["id"]);
            var mockRepo = new MockRepository();
            var handler = new DwellerHandler(mockRepo);

            return handler.Handle(new DwellerGetByIdCommand(dwellerId));
        }

        public class MockRepository : IDwellerRepository
        {
            public bool CreateDweller(Dweller dweller)
            {
                return true;
            }

            public Dweller GetDwellerByID(int dwellerId)
            {
                return new Dweller();
            }

            public IList<Dweller> GetDwellers()
            {
                var list = new List<Dweller>();
                return list;
            }

            public bool DeleteDwellerById(int dwellerId)
            {
                return true;
            }
        }
    }
}
