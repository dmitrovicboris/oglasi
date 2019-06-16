using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Tip:BaseEntity
    {
        public Tip()
        {
            Automobils = new HashSet<Automobil>();
        }
        public string Type { get; set; }

        public ICollection<Automobil> Automobils { get; set; }
    }
}
