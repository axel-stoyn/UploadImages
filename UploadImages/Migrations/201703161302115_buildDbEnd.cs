namespace UploadImages.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buildDbEnd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "Description", c => c.String());
            AddColumn("dbo.Pictures", "Manufactures", c => c.String());
            AddColumn("dbo.Pictures", "Model", c => c.String());
            AddColumn("dbo.Pictures", "Compression", c => c.String());
            AddColumn("dbo.Pictures", "Exposure", c => c.Int(nullable: false));
            AddColumn("dbo.Pictures", "ExifVersion", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pictures", "ExifVersion");
            DropColumn("dbo.Pictures", "Exposure");
            DropColumn("dbo.Pictures", "Compression");
            DropColumn("dbo.Pictures", "Model");
            DropColumn("dbo.Pictures", "Manufactures");
            DropColumn("dbo.Pictures", "Description");
        }
    }
}
