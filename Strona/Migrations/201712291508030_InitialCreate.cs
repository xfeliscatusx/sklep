namespace Strona.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoria",
                c => new
                    {
                        KategoriaId = c.Int(nullable: false, identity: true),
                        NazwaKategorii = c.String(nullable: false, maxLength: 100),
                        OpisKategorii = c.String(nullable: false),
                        NazwaPlikuIkony = c.String(),
                    })
                .PrimaryKey(t => t.KategoriaId);
            
            CreateTable(
                "dbo.Skarpetki",
                c => new
                    {
                        SkarpetkiId = c.Int(nullable: false, identity: true),
                        KategoriaId = c.Int(nullable: false),
                        NazwaSkarpetek = c.String(nullable: false, maxLength: 100),
                        DataDodania = c.DateTime(nullable: false),
                        NazwaPlikuObrazka = c.String(maxLength: 100),
                        OpisSkarpetek = c.String(),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bestseller = c.Boolean(nullable: false),
                        Ukryty = c.Boolean(nullable: false),
                        OpisSkrocony = c.String(),
                    })
                .PrimaryKey(t => t.SkarpetkiId)
                .ForeignKey("dbo.Kategoria", t => t.KategoriaId, cascadeDelete: true)
                .Index(t => t.KategoriaId);
            
            CreateTable(
                "dbo.PozycjaZamowienia",
                c => new
                    {
                        PozycjaZamowieniaId = c.Int(nullable: false, identity: true),
                        ZamowienieId = c.Int(nullable: false),
                        SkarpetkiId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        CenaZakupu = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PozycjaZamowieniaId)
                .ForeignKey("dbo.Skarpetki", t => t.SkarpetkiId, cascadeDelete: true)
                .ForeignKey("dbo.Zamowienie", t => t.ZamowienieId, cascadeDelete: true)
                .Index(t => t.ZamowienieId)
                .Index(t => t.SkarpetkiId);
            
            CreateTable(
                "dbo.Zamowienie",
                c => new
                    {
                        ZamowienieId = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false, maxLength: 50),
                        Nazwisko = c.String(nullable: false, maxLength: 50),
                        Ulica = c.String(nullable: false, maxLength: 50),
                        Miasto = c.String(nullable: false, maxLength: 100),
                        KodPocztowy = c.String(nullable: false, maxLength: 6),
                        Telefon = c.String(),
                        Email = c.String(),
                        Komentarz = c.String(),
                        DataDodania = c.DateTime(nullable: false),
                        StanZamowienia = c.Int(nullable: false),
                        WartoscZamowienia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ZamowienieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PozycjaZamowienia", "ZamowienieId", "dbo.Zamowienie");
            DropForeignKey("dbo.PozycjaZamowienia", "SkarpetkiId", "dbo.Skarpetki");
            DropForeignKey("dbo.Skarpetki", "KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.PozycjaZamowienia", new[] { "SkarpetkiId" });
            DropIndex("dbo.PozycjaZamowienia", new[] { "ZamowienieId" });
            DropIndex("dbo.Skarpetki", new[] { "KategoriaId" });
            DropTable("dbo.Zamowienie");
            DropTable("dbo.PozycjaZamowienia");
            DropTable("dbo.Skarpetki");
            DropTable("dbo.Kategoria");
        }
    }
}
