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

namespace Condominium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DwellerController : ControllerBase
    {
        [HttpPost]
        public ICommandResult Create(CreateDwellerCommand command)
        {
            var mockRepo = new MockRepository();
            var handler = new DwellerHandler(mockRepo);

            return handler.Handle(command);
        }

        [HttpGet]
        public ICommandResult GetById()
        {
            var dwellerId = Convert.ToInt32(Request.Headers["id"]);
            var mockRepo = new MockRepository();
            var handler = new DwellerHandler(mockRepo);

            return handler.Handle(new GetDwellerByIdCommand(dwellerId));
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
