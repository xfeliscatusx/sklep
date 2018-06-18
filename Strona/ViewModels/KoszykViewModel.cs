using Strona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strona.ViewModels
{
    public class KoszykViewModel
    {
        public List<PozycjaKoszyka> PozycjeKoszyka { get; set; }
        public decimal CenaCalkowita { get; set; }
    }
}