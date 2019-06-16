using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Kategorija: BaseEntity
    {
        public Kategorija()
        {
            Automobils = new HashSet<Automobil>();
        }
        public string Naziv { get; set; }

        public ICollection<Automobil> Automobils { get; set; }
    }
}
