namespace UploadImages.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rebuildDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UploadImage = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Pictures");
        }
    }
}
