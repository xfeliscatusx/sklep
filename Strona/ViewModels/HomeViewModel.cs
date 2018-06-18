using Strona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strona.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Kategoria> Kategorie { get; set; }
        public IEnumerable<Skarpetki> Nowosci { get; set; }
        public IEnumerable<Skarpetki> Bestsellery { get; set; }
    }
}