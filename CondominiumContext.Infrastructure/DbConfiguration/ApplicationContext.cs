using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Domain.Entities;
using CondominiumContext.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondominiumContext.Infrastructure.DbConfiguration
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                //dbContextOptionsBuilder.UseSqlServer(AppSettings.GetInstace().ConnectionStrings.DefaultConnection);
                dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-QE4HOQ0\\SQLEXPRESS;Database=CONDOMINIUM;Trusted_Connection=True;");
            }
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Dweller> Dweller { get; set; }
    }
}
