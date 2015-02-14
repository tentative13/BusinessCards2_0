namespace EBCardsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonaAndPersonaOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessCards", "PersonaOwner_ID", c => c.Int());
            AddColumn("dbo.BusinessCards", "ShareWith_ID", c => c.Int());
            CreateIndex("dbo.BusinessCards", "PersonaOwner_ID");
            CreateIndex("dbo.BusinessCards", "ShareWith_ID");
            AddForeignKey("dbo.BusinessCards", "PersonaOwner_ID", "dbo.Personas", "ID");
            AddForeignKey("dbo.BusinessCards", "ShareWith_ID", "dbo.Personas", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessCards", "ShareWith_ID", "dbo.Personas");
            DropForeignKey("dbo.BusinessCards", "PersonaOwner_ID", "dbo.Personas");
            DropIndex("dbo.BusinessCards", new[] { "ShareWith_ID" });
            DropIndex("dbo.BusinessCards", new[] { "PersonaOwner_ID" });
            DropColumn("dbo.BusinessCards", "ShareWith_ID");
            DropColumn("dbo.BusinessCards", "PersonaOwner_ID");
        }
    }
}
