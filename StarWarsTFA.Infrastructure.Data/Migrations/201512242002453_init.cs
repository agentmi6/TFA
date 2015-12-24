namespace StarWarsTFA.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.String(),
                        isForceSensitive = c.Boolean(nullable: false),
                        SideID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sides", t => t.SideID, cascadeDelete: true)
                .Index(t => t.SideID);
            
            CreateTable(
                "dbo.Sides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TheForce = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "SideID", "dbo.Sides");
            DropIndex("dbo.Characters", new[] { "SideID" });
            DropTable("dbo.Sides");
            DropTable("dbo.Characters");
        }
    }
}
