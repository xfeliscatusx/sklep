using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Strona.Models
{
    public class Skarpetki
    {
            public int SkarpetkiId { get; set; } //primary key
            public int KategoriaId { get; set; }
            [Required(ErrorMessage ="Wprowadź nazwę skarpetek")]
            [StringLength(100)]
            public string NazwaSkarpetek { get; set; }
            public DateTime DataDodania { get; set; }
            [StringLength(100)]
            public string NazwaPlikuObrazka { get; set; }
            public string OpisSkarpetek { get; set; } 
            public decimal Cena { get; set; }
            public bool Bestseller { get; set; }
            public bool Ukryty { get; set; }
            public string OpisSkrocony { get; set; }
           


        public virtual Kategoria Kategoria { get; set; } //włąściwość nawigacyjna do tabeli Kategoria
    }   
}