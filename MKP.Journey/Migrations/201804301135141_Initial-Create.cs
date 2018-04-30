namespace MKP.Journey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        KmStart = c.Int(nullable: false),
                        KmStop = c.Int(nullable: false),
                        StartAddress = c.String(),
                        StopDestination = c.String(),
                        Arrend = c.String(),
                        Notes = c.String(),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNumber = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        StandardVehicle = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trip", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.Trip", new[] { "VehicleId" });
            DropTable("dbo.Vehicle");
            DropTable("dbo.Trip");
        }
    }
}
