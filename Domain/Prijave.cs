using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Prijave 
    {
        public int AutomobilId { get; set; }
        public int KorisnikId { get; set; }

        public Automobil Automobil { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
