using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Marka : BaseEntity
    {
        public Marka()
        {
            Automobils = new HashSet<Automobil>();
            Modeli = new HashSet<ModelAutomobila>();
        }
        public string MarkaAutomobila { get; set; }

        public ICollection<Automobil> Automobils { get; set; }
        public ICollection<ModelAutomobila> Modeli { get; set; }
    }
}
