namespace WebServiceInfinity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mge1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Depositoes",
                c => new
                    {
                        sistemaFK = c.Int(nullable: false),
                        nombre = c.String(),
                        x = c.Single(nullable: false),
                        y = c.Single(nullable: false),
                        z = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.sistemaFK)
                .ForeignKey("dbo.SistemaPlanetarios", t => t.sistemaFK)
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
                        SistemaPlanetario_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Nebulosas", t => t.nebulosaFK, cascadeDelete: true)
                .ForeignKey("dbo.SistemaPlanetarios", t => t.SistemaPlanetario_id)
                .Index(t => t.nebulosaFK)
                .Index(t => t.SistemaPlanetario_id);
            
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
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Planetas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        idModelo = c.String(),
                        x = c.Single(nullable: false),
                        y = c.Single(nullable: false),
                        z = c.Single(nullable: false),
                        iridio = c.Double(nullable: false),
                        platino = c.Double(nullable: false),
                        paladio = c.Double(nullable: false),
                        elementoZero = c.Double(nullable: false),
                        sistemaPlanetarioFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.SistemaPlanetarios", t => t.sistemaPlanetarioFK, cascadeDelete: true)
                .Index(t => t.sistemaPlanetarioFK);
            
            CreateTable(
                "dbo.Teletransportadors",
                c => new
                    {
                        sistemaFK = c.Int(nullable: false),
                        nombre = c.String(),
                        x = c.Single(nullable: false),
                        y = c.Single(nullable: false),
                        z = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.sistemaFK)
                .ForeignKey("dbo.SistemaPlanetarios", t => t.sistemaFK)
                .Index(t => t.sistemaFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teletransportadors", "sistemaFK", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.Depositoes", "sistemaFK", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.SistemaPlanetarios", "SistemaPlanetario_id", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.Planetas", "sistemaPlanetarioFK", "dbo.SistemaPlanetarios");
            DropForeignKey("dbo.SistemaPlanetarios", "nebulosaFK", "dbo.Nebulosas");
            DropForeignKey("dbo.Nebulosas", "ViaLacteaFK", "dbo.ViaLacteas");
            DropIndex("dbo.Teletransportadors", new[] { "sistemaFK" });
            DropIndex("dbo.Planetas", new[] { "sistemaPlanetarioFK" });
            DropIndex("dbo.Nebulosas", new[] { "ViaLacteaFK" });
            DropIndex("dbo.SistemaPlanetarios", new[] { "SistemaPlanetario_id" });
            DropIndex("dbo.SistemaPlanetarios", new[] { "nebulosaFK" });
            DropIndex("dbo.Depositoes", new[] { "sistemaFK" });
            DropTable("dbo.Teletransportadors");
            DropTable("dbo.Planetas");
            DropTable("dbo.ViaLacteas");
            DropTable("dbo.Nebulosas");
            DropTable("dbo.SistemaPlanetarios");
            DropTable("dbo.Depositoes");
        }
    }
}
