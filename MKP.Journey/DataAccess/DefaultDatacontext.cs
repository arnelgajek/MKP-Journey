using MKP.Journey.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MKP.Journey.DataAccess
{
    public class DefaultDataContext : DbContext
    {
        public DefaultDataContext() : base("Journey") { }

        public DbSet<Vehicle> Vehicles { get; set; }

        // Händelsehanterare för hur Entity Framework ska fungera:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}