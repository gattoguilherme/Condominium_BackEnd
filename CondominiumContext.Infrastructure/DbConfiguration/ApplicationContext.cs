using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondominiumContext.Domain.Entities;
using CondominiumContext.Domain.ValueObjects;
using CondominiumContext.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondominiumContext.Infrastructure.DbConfiguration
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                //dbContextOptionsBuilder.UseSqlServer(AppSettings.GetInstace().ConnectionStrings.DefaultConnection);
                dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-QE4HOQ0\\SQLEXPRESS;Database=CONDOMINIUM;Trusted_Connection=True;");
            }
        }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Dweller> (entity =>)
        //}

        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contact { get; internal set; }
        public DbSet<Date> Date { get; internal set; }
        public DbSet<Document> Document { get; internal set; }
        public DbSet<Dweller> Dweller { get; set; }
        public DbSet<Email> Email { get; internal set; }
        public DbSet<Name> Name { get; internal set; }
    }
}
