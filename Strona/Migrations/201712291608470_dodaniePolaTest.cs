namespace Strona.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniePolaTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skarpetki", "Test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skarpetki", "Test");
        }
    }
}
