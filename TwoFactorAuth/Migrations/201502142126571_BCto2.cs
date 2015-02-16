namespace EBCardsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BCto2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessCardsToes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BusinessCard_ID = c.Int(),
                        PersonaOwner_ID = c.Int(),
                        ShareWith_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BusinessCards", t => t.BusinessCard_ID)
                .ForeignKey("dbo.Personas", t => t.PersonaOwner_ID)
                .ForeignKey("dbo.Personas", t => t.ShareWith_ID)
                .Index(t => t.BusinessCard_ID)
                .Index(t => t.PersonaOwner_ID)
                .Index(t => t.ShareWith_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessCardsToes", "ShareWith_ID", "dbo.Personas");
            DropForeignKey("dbo.BusinessCardsToes", "PersonaOwner_ID", "dbo.Personas");
            DropForeignKey("dbo.BusinessCardsToes", "BusinessCard_ID", "dbo.BusinessCards");
            DropIndex("dbo.BusinessCardsToes", new[] { "ShareWith_ID" });
            DropIndex("dbo.BusinessCardsToes", new[] { "PersonaOwner_ID" });
            DropIndex("dbo.BusinessCardsToes", new[] { "BusinessCard_ID" });
            DropTable("dbo.BusinessCardsToes");
        }
    }
}
