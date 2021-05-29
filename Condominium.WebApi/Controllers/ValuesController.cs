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
    public class DwallerController : ControllerBase
    {
        [HttpPost]
        public ICommandResult Create(CreateDwallerCommand command)
        {
            var mockRepo = new MockRepository();
            var handler = new DwellerHandler(mockRepo);

            return handler.Handle(command);
        }

        public class MockRepository : IDwallerRepository
        {
            public void CreateDwaller(Dweller dwaller)
            {

            }
        }
    }
}
