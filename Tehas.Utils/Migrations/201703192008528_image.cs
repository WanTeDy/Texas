namespace Tehas.Utils.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "PageDescription_Id", "dbo.PageDescriptions");
            DropIndex("dbo.Images", new[] { "PageDescription_Id" });
            CreateTable(
                "dbo.PageDescriptionImages",
                c => new
                    {
                        PageDescription_Id = c.Int(nullable: false),
                        Image_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PageDescription_Id, t.Image_Id })
                .ForeignKey("dbo.PageDescriptions", t => t.PageDescription_Id, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.Image_Id, cascadeDelete: true)
                .Index(t => t.PageDescription_Id)
                .Index(t => t.Image_Id);
            
            DropColumn("dbo.Images", "PageDescription_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "PageDescription_Id", c => c.Int());
            DropForeignKey("dbo.PageDescriptionImages", "Image_Id", "dbo.Images");
            DropForeignKey("dbo.PageDescriptionImages", "PageDescription_Id", "dbo.PageDescriptions");
            DropIndex("dbo.PageDescriptionImages", new[] { "Image_Id" });
            DropIndex("dbo.PageDescriptionImages", new[] { "PageDescription_Id" });
            DropTable("dbo.PageDescriptionImages");
            CreateIndex("dbo.Images", "PageDescription_Id");
            AddForeignKey("dbo.Images", "PageDescription_Id", "dbo.PageDescriptions", "Id");
        }
    }
}
