using MKP.Journey.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MKP.Journey.DataAccess
{
    public class DefaultDataContext : DbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultDataContext, Configuration>());
        }
    }
}