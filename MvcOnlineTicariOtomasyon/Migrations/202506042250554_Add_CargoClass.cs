namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CargoClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        TrackNumber = c.String(maxLength: 10, unicode: false),
                        Employee = c.String(maxLength: 25, unicode: false),
                        Receiver = c.String(maxLength: 25, unicode: false),
                        CargoDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailId);
            
            CreateTable(
                "dbo.CargoTracks",
                c => new
                    {
                        CargoTrackId = c.Int(nullable: false, identity: true),
                        TrackCode = c.String(maxLength: 10, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                        TrackDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTracks");
            DropTable("dbo.CargoDetails");
        }
    }
}
