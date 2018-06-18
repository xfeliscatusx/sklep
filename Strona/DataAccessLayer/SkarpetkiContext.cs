using Strona.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Strona.DataAccessLayer
{
    public class SkarpetkiContext : DbContext
    {
        public SkarpetkiContext() : base("SkarpetkiContext")
        {

        }

        static SkarpetkiContext()
        {
            Database.SetInitializer(new SkarpetkiInitializer());
            //Database.SetInitializer<SkarpetkiContext>(null);

        }

        public DbSet<Skarpetki> Skarpetki { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjaZamowienia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}