namespace WebServiceInfinity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hjsio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AristaSistemas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        origenFK = c.Int(nullable: false),
                        destinoFK = c.Int(nullable: false),
                        nebulosaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.SistemaPlanetarios", t => t.destinoFK, cascadeDelete: false)
                .ForeignKey("dbo.Nebulosas", t => t.nebulosaFK, cascadeDelete: true)
                .ForeignKey("dbo.SistemaPlanetarios", t => t.origenFK, cascadeDelete: false)
                .Index(t => t.origenFK)
                .Index(t => t.destinoFK)
                .Index(t => t.nebulosaFK);
            
            AddColumn("dbo.SistemaPlanetarios", "arista_id", c => c.Int());
            CreateIndex("dbo.SistemaPlanetarios", "arista_id");
            AddForeignKey("dbo.SistemaPlanetarios", "arista_id", "dbo.AristaSistemas", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SistemaPlanetarios", "arista_id", "dbo.AristaSistemas");
            DropForeignKey("dbo.AristaSistemas", "origenFK", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.AristaSistemas", "nebulosaFK", "dbo.Nebulosas");
            DropForeignKey("dbo.AristaSistemas", "destinoFK", "dbo.SistemaPlanetarios");
            DropIndex("dbo.AristaSistemas", new[] { "nebulosaFK" });
            DropIndex("dbo.AristaSistemas", new[] { "destinoFK" });
            DropIndex("dbo.AristaSistemas", new[] { "origenFK" });
            DropIndex("dbo.SistemaPlanetarios", new[] { "arista_id" });
            DropColumn("dbo.SistemaPlanetarios", "arista_id");
            DropTable("dbo.AristaSistemas");
        }
    }
}
