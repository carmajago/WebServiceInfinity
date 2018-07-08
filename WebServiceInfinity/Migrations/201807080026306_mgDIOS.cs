namespace WebServiceInfinity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgDIOS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Planetas", "arista_id", "dbo.AristaNodoes");
            DropIndex("dbo.Planetas", new[] { "arista_id" });
            AddColumn("dbo.AristaNodoes", "Planeta_id", c => c.Int());
            CreateIndex("dbo.AristaNodoes", "Planeta_id");
            AddForeignKey("dbo.AristaNodoes", "Planeta_id", "dbo.Planetas", "id");
            DropColumn("dbo.Planetas", "arista_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Planetas", "arista_id", c => c.Int());
            DropForeignKey("dbo.AristaNodoes", "Planeta_id", "dbo.Planetas");
            DropIndex("dbo.AristaNodoes", new[] { "Planeta_id" });
            DropColumn("dbo.AristaNodoes", "Planeta_id");
            CreateIndex("dbo.Planetas", "arista_id");
            AddForeignKey("dbo.Planetas", "arista_id", "dbo.AristaNodoes", "id");
        }
    }
}
