namespace Tehas.Utils.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Order_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        UserEmailMessage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEmailMessages", t => t.UserEmailMessage_Id)
                .Index(t => t.UserEmailMessage_Id);
            
            CreateTable(
                "dbo.OrderGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Game_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.Order_Id);
            
            AddColumn("dbo.UserEmailMessages", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserEmailMessage_Id", "dbo.UserEmailMessages");
            DropForeignKey("dbo.OrderProducts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderGames", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderGames", "Game_Id", "dbo.Games");
            DropIndex("dbo.OrderGames", new[] { "Order_Id" });
            DropIndex("dbo.OrderGames", new[] { "Game_Id" });
            DropIndex("dbo.Orders", new[] { "UserEmailMessage_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Product_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Order_Id" });
            DropColumn("dbo.UserEmailMessages", "Type");
            DropTable("dbo.OrderGames");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
        }
    }
}
