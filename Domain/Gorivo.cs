using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Gorivo : BaseEntity
    {
        public Gorivo()
        {
            Automobils = new HashSet<Automobil>();
        }
        public string Naziv { get; set; }

        public ICollection<Automobil> Automobils { get; set; }
    }
}
