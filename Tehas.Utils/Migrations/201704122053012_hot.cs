namespace Tehas.Utils.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsHot", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsHot");
        }
    }
}
