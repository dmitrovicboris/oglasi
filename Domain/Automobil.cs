using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Automobil : BaseEntity
    {
        public Automobil()
        {
            Slike = new HashSet<Slike>();
            Prijave = new HashSet<Prijave>();
        }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Price { get; set; }
        public DateTime Godiste { get; set; }
        public bool Vlasnik { get; set; }
        public int MarkaId { get; set; }
        public int KategorijaId { get; set; }
        public int? TipId { get; set; }
        public int GorivoId { get; set; }
        public int? ModelId { get; set; }
        public int KorisnikId { get; set; }

        public Marka Marka { get; set; }
        public Kategorija Kategorija { get; set; }
        public Tip Tip { get; set; }
        public Gorivo Gorivo { get; set; }
        public ModelAutomobila Model { get; set; }
        public Korisnik Korisnik { get; set; }
        public ICollection<Slike> Slike { get; set; }
        public ICollection<Prijave> Prijave { get; set; }
    }
}
