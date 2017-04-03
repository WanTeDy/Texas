namespace Tehas.Utils.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Game2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "ParrentId", c => c.Int());
            CreateIndex("dbo.Games", "ParrentId");
            AddForeignKey("dbo.Games", "ParrentId", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "ParrentId", "dbo.Games");
            DropIndex("dbo.Games", new[] { "ParrentId" });
            DropColumn("dbo.Games", "ParrentId");
        }
    }
}
