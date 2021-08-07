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
using CondominiumContext.Infrastructure.DbConfiguration;
using CondominiumContext.Infrastructure.Repositories;

namespace Condominium.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DwellerController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public DwellerController(ApplicationContext context)
        {
            this._context = context;
        }

        [Route("create")]
        [HttpPost]
        public ICommandResult Create([FromBody] DwellerCreateCommand command)
        {
            var repository = new DwellerRepository(_context);

            var handler = new DwellerHandler(repository);

            return handler.Handle(command);
        }

        [HttpGet]
        //[Authorize(Roles = "role2")]
        [Route("getById")]
        public ICommandResult GetById()
        {
            var dwellerId = Guid.Parse(Request.Headers["id"].ToString());
            var repository = new DwellerRepository(_context);
            var handler = new DwellerHandler(repository);

            return handler.Handle(new DwellerGetByIdCommand(dwellerId));
        }

        public class MockRepository : IDwellerRepository
        {
            public bool CreateDweller(Dweller dweller)
            {
                return true;
            }

            public Dweller GetDwellerByID(Guid dwellerId)
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
