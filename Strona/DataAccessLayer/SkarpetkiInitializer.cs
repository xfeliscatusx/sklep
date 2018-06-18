using Strona.Migrations;
using Strona.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Strona.DataAccessLayer
{
    public class SkarpetkiInitializer : MigrateDatabaseToLatestVersion<SkarpetkiContext, Configuration>
    {
                
        public static void SeedSkarpetkiData(SkarpetkiContext context)
        {
            var kategorie = new List<Kategoria>
            {
                new Kategoria() {KategoriaId = 1, NazwaKategorii="Ona", NazwaPlikuIkony = "Ona.png", OpisKategorii = "Opis ona"},
                new Kategoria() {KategoriaId = 2, NazwaKategorii="On", NazwaPlikuIkony = "On.png", OpisKategorii = "Opis on"},
                new Kategoria() {KategoriaId = 3, NazwaKategorii="Kids", NazwaPlikuIkony = "Kids.png", OpisKategorii = "Opis kids"}
            };

            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));
            context.SaveChanges();

            var skarpetki = new List<Skarpetki>
            {
                new Skarpetki() {SkarpetkiId=1, NazwaSkarpetek="stopki damskie", KategoriaId=1, Cena = 15, Bestseller = false, NazwaPlikuObrazka = "stopkidamskie.png", DataDodania = DateTime.Now, OpisSkarpetek ="Skarpety z miłej w dotyku bawełny czesanej zapewniają komfort przez cały dzień. Odpowiednia rozciągliwość i struktura ściągacza gwarantują dopasowanie do kształtu nogi, jednocześnie nie pozwalając skarpetom nieelegancko opadać. Wyprodukowane w Polsce.", Ukryty = false},
                new Skarpetki() {SkarpetkiId=2, NazwaSkarpetek="skarpety damskie", KategoriaId=1, Cena = 20, Bestseller = true, NazwaPlikuObrazka = "skarpetydamskie.png", DataDodania = DateTime.Now, OpisSkarpetek = "Skarpety z miłej w dotyku bawełny czesanej zapewniają komfort przez cały dzień. Odpowiednia rozciągliwość i struktura ściągacza gwarantują dopasowanie do kształtu nogi, jednocześnie nie pozwalając skarpetom nieelegancko opadać. Wyprodukowane w Polsce.", Ukryty = false},
                new Skarpetki() {SkarpetkiId=3, NazwaSkarpetek="skarpety damskie sportowe", KategoriaId=1, Cena = 20, Bestseller = false, NazwaPlikuObrazka = "skarpetydamskiesportowe.png", DataDodania = DateTime.Now, OpisSkarpetek = "Skarpety do zadań specjalnych. Dzięki zastosowaniu specjalistycznych przędz są termoaktywne i wyjątkowo odporne na przetarcia.", Ukryty = false},
                new Skarpetki() {SkarpetkiId=4, NazwaSkarpetek="stopki męskie", KategoriaId=2, Cena = 15, Bestseller = true, NazwaPlikuObrazka = "stopkimęskie.png", DataDodania = DateTime.Now, OpisSkarpetek = "Skarpety z miłej w dotyku bawełny czesanej zapewniają komfort przez cały dzień. Odpowiednia rozciągliwość i struktura ściągacza gwarantują dopasowanie do kształtu nogi, jednocześnie nie pozwalając skarpetom nieelegancko opadać. Wyprodukowane w Polsce.", Ukryty = false},
                new Skarpetki() {SkarpetkiId=5, NazwaSkarpetek="skarpety męskie", KategoriaId=2, Cena = 20, Bestseller = true, NazwaPlikuObrazka = "skarpetymęskie.png", DataDodania = DateTime.Now, OpisSkarpetek = "Skarpety z miłej w dotyku bawełny czesanej zapewniają komfort przez cały dzień. Odpowiednia rozciągliwość i struktura ściągacza gwarantują dopasowanie do kształtu nogi, jednocześnie nie pozwalając skarpetom nieelegancko opadać. Wyprodukowane w Polsce.", Ukryty = false},
                new Skarpetki() {SkarpetkiId=6, NazwaSkarpetek="skarpety męskie sportowe", KategoriaId=2, Cena = 20, Bestseller = false, NazwaPlikuObrazka = "skarpetymęskiesportowe.png", DataDodania = DateTime.Now, OpisSkarpetek = "Skarpety do zadań specjalnych. Dzięki zastosowaniu specjalistycznych przędz są termoaktywne i wyjątkowo odporne na przetarcia.", Ukryty = false},
               // new Skarpetki() {NazwaSkarpetek="0-2 lata", KategoriaId=7, Cena = 15, Bestseller = true, NazwaPlikuObrazka = "02lata.png", DataDodania = DateTime.Now, OpisSkarpetek = "opis", Ukryty = false},
                //new Skarpetki() {NazwaSkarpetek="2-8 lata", KategoriaId=7, Cena = 15, Bestseller = true, NazwaPlikuObrazka = "28lata.png", DataDodania = DateTime.Now, OpisSkarpetek = "opis", Ukryty = false},
                new Skarpetki() {SkarpetkiId=7, NazwaSkarpetek="junior", KategoriaId=3, Cena = 15, Bestseller = true, NazwaPlikuObrazka = "junior.png", DataDodania = DateTime.Now, OpisSkarpetek = "Skarpety z miłej w dotyku bawełny czesanej zapewniają komfort przez cały dzień. Odpowiednia rozciągliwość i struktura ściągacza gwarantują dopasowanie do kształtu nogi, jednocześnie nie pozwalając skarpetom nieelegancko opadać. Wyprodukowane w Polsce.", Ukryty = false},
                new Skarpetki() {SkarpetkiId=9, NazwaSkarpetek="dziecięce sportowe", KategoriaId=3, Cena = 12, Bestseller = false, NazwaPlikuObrazka = "dzieciecesport.png", DataDodania = DateTime.Now, OpisSkarpetek = "Skarpety do zadań specjalnych. Dzięki zastosowaniu specjalistycznych przędz są termoaktywne i wyjątkowo odporne na przetarcia.", Ukryty = false}
                               
            };

            skarpetki.ForEach(k => context.Skarpetki.AddOrUpdate(k));
            context.SaveChanges();

        }
        }
    }
