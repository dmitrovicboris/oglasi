using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class AutomobilDto : BaseDto
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Price { get; set; }
        public DateTime Godiste { get; set; }
        public bool Vlasnik { get; set; }
        public string MarkaAutomobila { get; set; }
        public string Tip { get; set; }
        public string Model { get; set; }
        public string Kategorija { get; set; }
        public string VrstaGoriva { get; set; }
        public List<SlikeDto> Slike { get; set; }
    }
}
