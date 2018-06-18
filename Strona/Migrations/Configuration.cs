namespace Strona.Migrations
{
    using Strona.DataAccessLayer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Strona.DataAccessLayer.SkarpetkiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Strona.DataAccessLayer.SkarpetkiContext";
        }

        protected override void Seed(Strona.DataAccessLayer.SkarpetkiContext context)
        {
            SkarpetkiInitializer.SeedSkarpetkiData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
