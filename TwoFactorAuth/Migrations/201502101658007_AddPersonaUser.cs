namespace EBCardsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonaUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Personas", "User_Id");
            AddForeignKey("dbo.Personas", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personas", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Personas", new[] { "User_Id" });
            DropColumn("dbo.Personas", "User_Id");
        }
    }
}
