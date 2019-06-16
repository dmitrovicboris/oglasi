using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Korisnik : BaseEntity
    {
        public Korisnik()
        {
            Automobils = new HashSet<Automobil>();
            Prijave = new HashSet<Prijave>();
        }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Automobil> Automobils { get; set; }
        public ICollection<Prijave> Prijave { get; set; }
    }
}
