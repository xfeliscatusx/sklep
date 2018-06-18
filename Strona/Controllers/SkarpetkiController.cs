using Strona.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strona.Controllers
{
    public class SkarpetkiController : Controller
    {
        private SkarpetkiContext db = new SkarpetkiContext();
        // GET: Skarpetki
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista(string nazwaKategorii)
        {
            var kategorie = db.Kategorie.Include("Skarpetki").Where(k => k.NazwaKategorii.ToUpper() == nazwaKategorii.ToUpper()).Single();
            var skarpetki = kategorie.Skarpetki.ToList();

            return View(skarpetki);
        }

        public ActionResult Szczegoly(int id)
        {
            var skarpetki = db.Skarpetki.Find(id);
            return View(skarpetki);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult KategorieMenu()
        {            
            var kategorie = db.Kategorie.ToList();

            return PartialView("_KategorieMenu", kategorie);
        }

        



    }
}