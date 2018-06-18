namespace Strona.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usunieciePolaTest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skarpetki", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skarpetki", "Test", c => c.String());
        }
    }
}
