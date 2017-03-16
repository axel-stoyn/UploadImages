namespace UploadImages.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGeo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "GeoLong", c => c.Double(nullable: false));
            AddColumn("dbo.Pictures", "GeoLat", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pictures", "GeoLat");
            DropColumn("dbo.Pictures", "GeoLong");
        }
    }
}
