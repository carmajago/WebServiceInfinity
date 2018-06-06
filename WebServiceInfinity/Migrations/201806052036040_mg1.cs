namespace WebServiceInfinity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Planetas", t => t.destinoFK, cascadeDelete: false)
                .ForeignKey("dbo.Planetas", t => t.origenFK, cascadeDelete: false)
                .Index(t => t.origenFK)
                .Index(t => t.destinoFK)
                .Index(t => t.sistemaFK);
            
            CreateTable(
                "dbo.Planetas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        x = c.Single(nullable: false),
                        y = c.Single(nullable: false),
                        z = c.Single(nullable: false),
                        idModelo = c.String(),
                        sistemaPlanetarioFK = c.Int(nullable: false),
                        iridio = c.Double(nullable: false),
                        platino = c.Double(nullable: false),
                        paladio = c.Double(nullable: false),
                        elementoZero = c.Double(nullable: false),
                        arista_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AristaNodoes", t => t.arista_id)
                .ForeignKey("dbo.SistemaPlanetarios", t => t.sistemaPlanetarioFK, cascadeDelete: true)
                .Index(t => t.sistemaPlanetarioFK)
                .Index(t => t.arista_id);
            
            CreateTable(
                "dbo.Depositoes",
                c => new
                    {
                        planetaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.planetaFK)
                .ForeignKey("dbo.Planetas", t => t.planetaFK)
                .Index(t => t.planetaFK);
            
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
                        arista_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AristaSistemas", t => t.arista_id)
                .ForeignKey("dbo.Nebulosas", t => t.nebulosaFK, cascadeDelete: true)
                .Index(t => t.nebulosaFK)
                .Index(t => t.arista_id);
            
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
                .ForeignKey("dbo.Nebulosas", t => t.nebulosaFK, cascadeDelete: false)
                .ForeignKey("dbo.SistemaPlanetarios", t => t.origenFK, cascadeDelete: true)
                .Index(t => t.origenFK)
                .Index(t => t.destinoFK)
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
                        danger = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.Teletransportadors",
                c => new
                    {
                        planetaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.planetaFK)
                .ForeignKey("dbo.Planetas", t => t.planetaFK)
                .Index(t => t.planetaFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AristaNodoes", "origenFK", "dbo.Planetas");
            DropForeignKey("dbo.AristaNodoes", "destinoFK", "dbo.Planetas");
            DropForeignKey("dbo.Teletransportadors", "planetaFK", "dbo.Planetas");
            DropForeignKey("dbo.Planetas", "sistemaPlanetarioFK", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.SistemaPlanetarios", "nebulosaFK", "dbo.Nebulosas");
            DropForeignKey("dbo.AristaNodoes", "sistemaFK", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.SistemaPlanetarios", "arista_id", "dbo.AristaSistemas");
            DropForeignKey("dbo.AristaSistemas", "origenFK", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.Nebulosas", "ViaLacteaFK", "dbo.ViaLacteas");
            DropForeignKey("dbo.AristaSistemas", "nebulosaFK", "dbo.Nebulosas");
            DropForeignKey("dbo.AristaSistemas", "destinoFK", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.Depositoes", "planetaFK", "dbo.Planetas");
            DropForeignKey("dbo.Planetas", "arista_id", "dbo.AristaNodoes");
            DropIndex("dbo.Teletransportadors", new[] { "planetaFK" });
            DropIndex("dbo.Nebulosas", new[] { "ViaLacteaFK" });
            DropIndex("dbo.AristaSistemas", new[] { "nebulosaFK" });
            DropIndex("dbo.AristaSistemas", new[] { "destinoFK" });
            DropIndex("dbo.AristaSistemas", new[] { "origenFK" });
            DropIndex("dbo.SistemaPlanetarios", new[] { "arista_id" });
            DropIndex("dbo.SistemaPlanetarios", new[] { "nebulosaFK" });
            DropIndex("dbo.Depositoes", new[] { "planetaFK" });
            DropIndex("dbo.Planetas", new[] { "arista_id" });
            DropIndex("dbo.Planetas", new[] { "sistemaPlanetarioFK" });
            DropIndex("dbo.AristaNodoes", new[] { "sistemaFK" });
            DropIndex("dbo.AristaNodoes", new[] { "destinoFK" });
            DropIndex("dbo.AristaNodoes", new[] { "origenFK" });
            DropTable("dbo.Teletransportadors");
            DropTable("dbo.ViaLacteas");
            DropTable("dbo.Nebulosas");
            DropTable("dbo.AristaSistemas");
            DropTable("dbo.SistemaPlanetarios");
            DropTable("dbo.Depositoes");
            DropTable("dbo.Planetas");
            DropTable("dbo.AristaNodoes");
        }
    }
}
