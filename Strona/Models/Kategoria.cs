using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Strona.Models
{
    public class Kategoria
    {
        public int KategoriaId { get; set; }
        [Required(ErrorMessage = "Wprowadź nazwę kategorii")]
        [StringLength(100)]
        public string NazwaKategorii { get; set; }
        [Required(ErrorMessage = "Wprowadź opis kategorii")]

        public string OpisKategorii { get; set; }
        public string NazwaPlikuIkony { get; set; }

        public virtual ICollection<Skarpetki> Skarpetki { get; set; }
    }
}