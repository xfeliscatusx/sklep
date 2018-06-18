using Strona.DataAccessLayer;
using Strona.Infrastructure;
using Strona.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strona.Controllers
{
    public class KoszykController : Controller
    {
        private KoszykManager koszykManager;
        private SkarpetkiContext db;
        private ISessionManager sessionManager { get; set; }

        public KoszykController()
        {
            db = new SkarpetkiContext();
            sessionManager = new SessionManager();
            koszykManager = new KoszykManager(sessionManager, db);
        }


        public ActionResult Index()
        {

            var pozycjeKoszyka = koszykManager.PobierzKoszyk();
            var cenaCalkowita = koszykManager.PobierzWartoscKoszyka();
            KoszykViewModel koszykVM = new KoszykViewModel()
            {
                PozycjeKoszyka = pozycjeKoszyka,
                CenaCalkowita = cenaCalkowita
            };

            return View(koszykVM);
        }

        public ActionResult DodajDoKoszyka(int id)
        {
            koszykManager.DodajDoKoszyka(id);
            return RedirectToAction("Index");
        }

        public int PobierzIloscElementowKoszyka()
        {
            return koszykManager.PobierzIloscPozycjiKoszyka();
        }

        public ActionResult UsunZKoszyka(int skarpetkiId)
        {
            int iloscPozycji = koszykManager.UsunzKoszyka(skarpetkiId);
            int iloscPozycjiKoszyka = koszykManager.PobierzIloscPozycjiKoszyka();
            decimal wartoscKoszyka = koszykManager.PobierzWartoscKoszyka();

            var wynik = new KoszykUsuwanieViewModel
            {
                IdPozycjiUsuwanej = skarpetkiId,
                IloscPozycjiUsuwanej = iloscPozycji,
                KoszykCenaCalkowita = wartoscKoszyka,
                KoszykIloscPozycji = iloscPozycjiKoszyka,
            };

            return Json(wynik);

        }

    }


}