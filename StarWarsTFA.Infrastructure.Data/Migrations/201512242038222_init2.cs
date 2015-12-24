namespace StarWarsTFA.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "imgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "imgUrl");
        }
    }
}
