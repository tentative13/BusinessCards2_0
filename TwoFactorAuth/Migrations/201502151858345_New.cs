namespace EBCardsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BusinessCardsToes", "BusinessCard_ID", "dbo.BusinessCards");
            DropForeignKey("dbo.BusinessCardsToes", "PersonaOwner_ID", "dbo.Personas");
            DropForeignKey("dbo.BusinessCardsToes", "ShareWith_ID", "dbo.Personas");
            DropIndex("dbo.BusinessCardsToes", new[] { "BusinessCard_ID" });
            DropIndex("dbo.BusinessCardsToes", new[] { "PersonaOwner_ID" });
            DropIndex("dbo.BusinessCardsToes", new[] { "ShareWith_ID" });
            DropTable("dbo.BusinessCardsToes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.BusinessCardsToes", "ShareWith_ID");
            CreateIndex("dbo.BusinessCardsToes", "PersonaOwner_ID");
            CreateIndex("dbo.BusinessCardsToes", "BusinessCard_ID");
            AddForeignKey("dbo.BusinessCardsToes", "ShareWith_ID", "dbo.Personas", "ID");
            AddForeignKey("dbo.BusinessCardsToes", "PersonaOwner_ID", "dbo.Personas", "ID");
            AddForeignKey("dbo.BusinessCardsToes", "BusinessCard_ID", "dbo.BusinessCards", "ID");
        }
    }
}
