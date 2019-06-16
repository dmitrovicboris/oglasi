using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Slike : BaseEntity
    {
        public string Putanja { get; set; }
        public int AutomobilId { get; set; }

        public Automobil Automobil { get; set; }
    }
}
