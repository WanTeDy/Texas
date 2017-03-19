namespace Tehas.Utils.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        RussianName = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                        ShortDescription = c.String(),
                        ImageId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Url = c.String(),
                        Description = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        PageDescription_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PageDescriptions", t => t.PageDescription_Id)
                .Index(t => t.PageDescription_Id);
            
            CreateTable(
                "dbo.UserEmailMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                        Date = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PageDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        VideoURL = c.String(),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        TokenHash = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "PageDescription_Id", "dbo.PageDescriptions");
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropForeignKey("dbo.Products", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Images", new[] { "PageDescription_Id" });
            DropIndex("dbo.Products", new[] { "ImageId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropTable("dbo.Users");
            DropTable("dbo.PageDescriptions");
            DropTable("dbo.UserEmailMessages");
            DropTable("dbo.Images");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
