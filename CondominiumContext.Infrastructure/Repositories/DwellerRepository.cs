using CondominiumContext.Domain.Entities;
using CondominiumContext.Domain.Repositories;
using CondominiumContext.Domain.ValueObjects;
using CondominiumContext.Infrastructure.DbConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominiumContext.Infrastructure.Repositories
{
    public class DwellerRepository : IDwellerRepository
    {
        private readonly ApplicationContext _context;

        public DwellerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool CreateDweller(Dweller dweller)
        {
            try
            {
                _context.Add(dweller);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteDwellerById(int dwellerId)
        {
            throw new NotImplementedException();
        }

        public Dweller GetDwellerByID(Guid dwellerId)
        {
            var ret = _context.Dweller
            .Join(_context.Address,
            dweller => dweller.Address.Id,
            address => address.Id,
            (joinAddress, address) => new { joinAddress, address })

            .Join(_context.Date,
            o => o.joinAddress.BornDate.Id,
            date => date.Id,
            (joinDate, date) => new { joinDate, date })

            .Join(_context.Document,
            o => o.joinDate.joinAddress.Document.Id,
            document => document.Id,
            (joinDocument, document) => new { joinDocument, document })

            .Join(_context.Email,
            o => o.joinDocument.joinDate.joinAddress.Email.Id,
            email => email.Id,
            (joinEmail, email) => new { joinEmail, email })

            .Join(_context.Name,
            o => o.joinEmail.joinDocument.joinDate.joinAddress.Name.Id,
            name => name.Id,
            (joinName, name) => new { joinName, name })

            .Where(o => o.joinName.joinEmail.joinDocument.joinDate.joinAddress.Id == dwellerId)

            .Select(o => new Dweller(
                new Address(
                    o.joinName.joinEmail.joinDocument.joinDate.joinAddress.Address.BuildName,
                    o.joinName.joinEmail.joinDocument.joinDate.joinAddress.Address.Number,
                    o.joinName.joinEmail.joinDocument.joinDate.joinAddress.Address.Floor,
                    o.joinName.joinEmail.joinDocument.joinDate.joinAddress.Address.Id
                    ),
                new Date(
                    o.joinName.joinEmail.joinDocument.date.Day,
                    o.joinName.joinEmail.joinDocument.date.Month,
                    o.joinName.joinEmail.joinDocument.date.Year,
                    o.joinName.joinEmail.joinDocument.date.Id
                    ),
                new Document(
                    o.joinName.joinEmail.document.Number,
                    o.joinName.joinEmail.document.Type,
                    o.joinName.joinEmail.document.Id
                    ),
                new Email(
                    o.joinName.email.Address,
                    o.joinName.email.Id
                    ),
                new Name(
                    o.name.FirstName,
                    o.name.LastName,
                    o.name.Id
                    ),
                o.joinName.joinEmail.joinDocument.joinDate.joinAddress.Id
                )
            ).ToList();

            return ret.FirstOrDefault();
        }

        public IList<Dweller> GetDwellers()
        {
            throw new NotImplementedException();
        }
    }
}
