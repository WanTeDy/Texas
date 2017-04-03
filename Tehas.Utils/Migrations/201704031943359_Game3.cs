namespace Tehas.Utils.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Game3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "DayOfWeek", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "DayOfWeek");
        }
    }
}
