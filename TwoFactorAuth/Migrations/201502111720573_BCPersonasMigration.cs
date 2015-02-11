namespace EBCardsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BCPersonasMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BusinessCards", "PersonaOwner_ID", "dbo.Personas");
            DropForeignKey("dbo.BusinessCards", "ShareWith_ID", "dbo.Personas");
            DropIndex("dbo.BusinessCards", new[] { "PersonaOwner_ID" });
            DropIndex("dbo.BusinessCards", new[] { "ShareWith_ID" });
            DropColumn("dbo.BusinessCards", "PersonaOwner_ID");
            DropColumn("dbo.BusinessCards", "ShareWith_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BusinessCards", "ShareWith_ID", c => c.Int());
            AddColumn("dbo.BusinessCards", "PersonaOwner_ID", c => c.Int());
            CreateIndex("dbo.BusinessCards", "ShareWith_ID");
            CreateIndex("dbo.BusinessCards", "PersonaOwner_ID");
            AddForeignKey("dbo.BusinessCards", "ShareWith_ID", "dbo.Personas", "ID");
            AddForeignKey("dbo.BusinessCards", "PersonaOwner_ID", "dbo.Personas", "ID");
        }
    }
}
