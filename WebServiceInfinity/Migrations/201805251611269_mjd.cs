namespace WebServiceInfinity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mjd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nodoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        x = c.Single(nullable: false),
                        y = c.Single(nullable: false),
                        z = c.Single(nullable: false),
                        idModelo = c.String(),
                        sistemaPlanetarioFK = c.Int(nullable: false),
                        iridio = c.Double(),
                        platino = c.Double(),
                        paladio = c.Double(),
                        elementoZero = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        arista_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AristaNodoes", t => t.arista_id)
                .ForeignKey("dbo.SistemaPlanetarios", t => t.sistemaPlanetarioFK, cascadeDelete: true)
                .Index(t => t.sistemaPlanetarioFK)
                .Index(t => t.arista_id);
            
            CreateTable(
                "dbo.AristaNodoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        origenFK = c.Int(nullable: false),
                        destinoFK = c.Int(nullable: false),
                        sistemaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.SistemaPlanetarios", t => t.sistemaFK, cascadeDelete: true)
                .ForeignKey("dbo.Nodoes", t => t.destinoFK, cascadeDelete: false)
                .ForeignKey("dbo.Nodoes", t => t.origenFK, cascadeDelete: false)
                .Index(t => t.origenFK)
                .Index(t => t.destinoFK)
                .Index(t => t.sistemaFK);
            
            CreateTable(
                "dbo.SistemaPlanetarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        x = c.Single(nullable: false),
                        y = c.Single(nullable: false),
                        z = c.Single(nullable: false),
                        nebulosaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Nebulosas", t => t.nebulosaFK, cascadeDelete: true)
                .Index(t => t.nebulosaFK);
            
            CreateTable(
                "dbo.Nebulosas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        x = c.Single(nullable: false),
                        y = c.Single(nullable: false),
                        z = c.Single(nullable: false),
                        ViaLacteaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ViaLacteas", t => t.ViaLacteaFK, cascadeDelete: true)
                .Index(t => t.ViaLacteaFK);
            
            CreateTable(
                "dbo.ViaLacteas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AristaNodoes", "origenFK", "dbo.Nodoes");
            DropForeignKey("dbo.AristaNodoes", "destinoFK", "dbo.Nodoes");
            DropForeignKey("dbo.Nodoes", "sistemaPlanetarioFK", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.SistemaPlanetarios", "nebulosaFK", "dbo.Nebulosas");
            DropForeignKey("dbo.Nebulosas", "ViaLacteaFK", "dbo.ViaLacteas");
            DropForeignKey("dbo.AristaNodoes", "sistemaFK", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.Nodoes", "arista_id", "dbo.AristaNodoes");
            DropIndex("dbo.Nebulosas", new[] { "ViaLacteaFK" });
            DropIndex("dbo.SistemaPlanetarios", new[] { "nebulosaFK" });
            DropIndex("dbo.AristaNodoes", new[] { "sistemaFK" });
            DropIndex("dbo.AristaNodoes", new[] { "destinoFK" });
            DropIndex("dbo.AristaNodoes", new[] { "origenFK" });
            DropIndex("dbo.Nodoes", new[] { "arista_id" });
            DropIndex("dbo.Nodoes", new[] { "sistemaPlanetarioFK" });
            DropTable("dbo.ViaLacteas");
            DropTable("dbo.Nebulosas");
            DropTable("dbo.SistemaPlanetarios");
            DropTable("dbo.AristaNodoes");
            DropTable("dbo.Nodoes");
        }
    }
}
