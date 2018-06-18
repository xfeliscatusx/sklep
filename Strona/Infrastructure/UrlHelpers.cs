using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strona.Infrastructure
{
    public static class UrlHelpers
    {
        public static string ObrazkiSciezka(this UrlHelper helper, string nazwaObrazka)
        {
            var ObrazkiFolder = AppConfig.ObrazkiFolderWzgledny;
            var sciezka = Path.Combine(ObrazkiFolder, nazwaObrazka);
            var sciezkaBezwzglendna = helper.Content(sciezka);

            return sciezkaBezwzglendna;
        }

    }
}