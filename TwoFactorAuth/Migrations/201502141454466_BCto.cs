namespace EBCardsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BCto : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.BusinessCardsTo",
    c => new
    {
        ID = c.Int(nullable: false, identity: true),
        BusinessCard = c.Int(),
        PersonaOwner = c.Int(),
        ShareWith = c.Int(),
    })
    .PrimaryKey(t => t.ID)
    .ForeignKey("dbo.Personas", t => t.PersonaOwner)
    .ForeignKey("dbo.BusinessCards", t => t.BusinessCard)
    .Index(t => t.BusinessCard);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Persona_ID", "dbo.Personas");
            DropIndex("dbo.Contacts", new[] { "Persona_ID" });
        }
    }
}
