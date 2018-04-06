namespace WebServiceInfinity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class msch3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ViaLacteas", "nombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ViaLacteas", "nombre");
        }
    }
}
