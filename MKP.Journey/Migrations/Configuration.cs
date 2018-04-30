namespace MKP.Journey.Migrations
{
    using MKP.Journey.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MKP.Journey.DataAccess.DefaultDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MKP.Journey.DataAccess.DefaultDataContext";
        }

        protected override void Seed(MKP.Journey.DataAccess.DefaultDataContext context)
        {
            context.Vehicles.AddOrUpdate(x => x.Id,
                new Vehicle() { Id = 1, RegNumber = "ABC123" },
                new Vehicle() { Id = 2, RegNumber = "DEF456" },
                new Vehicle() { Id = 3, RegNumber = "GHI789" }
            );

            context.Trips.AddOrUpdate(x => x.Id,
                new Trip()
                {
                    Id = 1,
                    Date = "2018-04-30",
                    KmStart = 10,
                    KmStop = 50,
                    StartAddress = "Testvägen 1, 341 30 Ljungby",
                    StopDestination = "Testvägen 69, 341 30 Ljungby",
                    Arrend = "test...",
                    Notes = "test...",
                    VehicleId = 1
                },
                new Trip()
                {
                    Id = 2,
                    Date = "2018-04-30",
                    KmStart = 10,
                    KmStop = 50,
                    StartAddress = "Testvägen 1, 341 30 Ljungby",
                    StopDestination = "Testvägen 69, 341 30 Ljungby",
                    Arrend = "test...",
                    Notes = "test...",
                    VehicleId = 2
                }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
