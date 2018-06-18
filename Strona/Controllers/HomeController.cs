using MvcSiteMapProvider.Caching;
using Strona.DataAccessLayer;
using Strona.Infrastructure;
using Strona.Models;
using Strona.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strona.Controllers
{
    public class HomeController : Controller
    {
        private SkarpetkiContext db = new SkarpetkiContext();

        public ActionResult Index()
        {            
            ICacheProvider cache = new DefaultCacheProvider();
            List<Skarpetki> nowosci;
            
            if(cache.IsSet(Consts.NowosciCacheKey))
            {
                nowosci = cache.Get(Consts.NowosciCacheKey) as List<Skarpetki>;
            }
            else
            {
                nowosci = db.Skarpetki.Where(a => !a.Ukryty).OrderByDescending(a => a.DataDodania).Take(3).ToList();
                cache.Set(Consts.NowosciCacheKey, nowosci, 60);
            }

            List<Skarpetki> bestseller;

            if (cache.IsSet(Consts.BestsellerCacheKey))
            {
                bestseller = cache.Get(Consts.BestsellerCacheKey) as List<Skarpetki>;
            }
            else
            {
                bestseller = db.Skarpetki.Where(a => !a.Ukryty && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList(); //sortujemy po indywidualnym indentyfikatorze
                cache.Set(Consts.NowosciCacheKey, bestseller, 60);
            }

            List<Kategoria> kategorie;
            
            if (cache.IsSet(Consts.KategorieCacheKey))
            {
                kategorie = cache.Get(Consts.KategorieCacheKey) as List<Kategoria>;
            }
            else
            {
                kategorie = db.Kategorie.ToList();
                cache.Set(Consts.KategorieCacheKey, kategorie, 60);
            }

            var ViewModel = new HomeViewModel()
            {
                Kategorie = kategorie,
                Nowosci = nowosci,
                Bestsellery = bestseller
            };

            return View(ViewModel);
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
    }
}