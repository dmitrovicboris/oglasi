using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ModelAutomobila : BaseEntity
    {
        public ModelAutomobila()
        {
            Automobils = new HashSet<Automobil>();
        }
        public string Model { get; set; }
        public int MarkaId { get; set; }

        public Marka Marka { get; set; }
        public ICollection<Automobil> Automobils { get; set; }
    }
}
