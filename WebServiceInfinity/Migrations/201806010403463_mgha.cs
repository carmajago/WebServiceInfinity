namespace WebServiceInfinity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nebulosas", "danger", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nebulosas", "danger");
        }
    }
}
