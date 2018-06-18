namespace Strona.Models
{
    public class PozycjaZamowienia
    {
        public int PozycjaZamowieniaId { get; set; }
        public int ZamowienieId { get; set; }
        public int SkarpetkiId { get; set; }
        public int Ilosc { get; set; }
        public decimal CenaZakupu { get; set; }

        public virtual Skarpetki Skarpetki { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}