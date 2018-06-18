using Strona.DataAccessLayer;
using Strona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strona.Infrastructure
{
    public class KoszykManager
    {

        private SkarpetkiContext db;
        private ISessionManager session;

        public KoszykManager(ISessionManager session, SkarpetkiContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;

            if (session.Get<List<PozycjaKoszyka>>(Consts.koszykSessionKey)==null)
            {
                koszyk = new List<PozycjaKoszyka>();
            
            }

            else
            {
               koszyk = session.Get<List<PozycjaKoszyka>>(Consts.koszykSessionKey) as List<PozycjaKoszyka>;
            }

            return koszyk;
        }

        public void DodajDoKoszyka(int SkarpetkiId)
        {
            var koszyk = PobierzKoszyk();
            //po Id sprawdzam czy taka pozycja w koszyku już istnieje
            var pozycjaKoszyka = koszyk.Find(k => k.Skarpetki.SkarpetkiId == SkarpetkiId);

            if (pozycjaKoszyka != null)
                pozycjaKoszyka.Ilosc++;
            else
            {
                var SkarpetkiDoDodania = db.Skarpetki.Where(k => k.SkarpetkiId ==SkarpetkiId).SingleOrDefault();

                if(SkarpetkiDoDodania !=null)
                {
                    var nowaPozycjaKoszyka = new PozycjaKoszyka()
                    {
                        Skarpetki = SkarpetkiDoDodania,
                        Ilosc = 1,
                        Wartosc = SkarpetkiDoDodania.Cena
                    };
                    koszyk.Add(nowaPozycjaKoszyka);
                }
            }

            session.Set(Consts.koszykSessionKey, koszyk);

        }

        public int UsunzKoszyka(int SkarpetkiId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Skarpetki.SkarpetkiId == SkarpetkiId);

            if (pozycjaKoszyka != null)
            {
                if (pozycjaKoszyka.Ilosc > 1)
                {
                    pozycjaKoszyka.Ilosc--;
                    return pozycjaKoszyka.Ilosc;
                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }

            return 0;
        }

        public decimal PobierzWartoscKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(k => (k.Ilosc * k.Skarpetki.Cena));
        }

        public int PobierzIloscPozycjiKoszyka()
        {
            var koszyk = PobierzKoszyk();
            int ilosc = koszyk.Sum(k => k.Ilosc);
            return ilosc;
        }

        public Zamowienie UtworzZamowienie(Zamowienie noweZamowienie, string userId)  //userId identyfikator użytkownika, którego dotyczy zamówienie
        {
            var koszyk = PobierzKoszyk();
            noweZamowienie.DataDodania = DateTime.Now;
           // noweZamowienie.UserId = userId;

            db.Zamowienia.Add(noweZamowienie);

            if (noweZamowienie.PozycjeZamowienia == null)
                noweZamowienie.PozycjeZamowienia = new List<PozycjaZamowienia>();

            decimal koszykWartosc = 0;

            foreach (var koszykElement in koszyk)
            {
                var nowaPozycjaZamowienia = new PozycjaZamowienia()
                {
                    SkarpetkiId = koszykElement.Skarpetki.SkarpetkiId,
                    Ilosc = koszykElement.Ilosc,
                    CenaZakupu = koszykElement.Skarpetki.Cena
                };

                koszykWartosc += (koszykElement.Ilosc * koszykElement.Skarpetki.Cena);
                noweZamowienie.PozycjeZamowienia.Add(nowaPozycjaZamowienia);
            }

            noweZamowienie.WartoscZamowienia = koszykWartosc;
            db.SaveChanges();

            return noweZamowienie;
        }

        public void PustyKoszyk()
        {
            session.Set<List<PozycjaKoszyka>>(Consts.koszykSessionKey, null);
        }
    }
}