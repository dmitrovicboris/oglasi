using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer.CreateDtos
{
    public class NapraviNovAutomobil
    {
        public int AutomobilId { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(100, ErrorMessage = "Naziv moze sadrazati maksimalno 100 karaktera")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Opis polje je obavezno")]
        public string Opis { get; set; }
        public decimal Price { get; set; }
        public DateTime Godiste { get; set; }
        public bool Vlasnik { get; set; }
        [Required(ErrorMessage = "Izaberite marku automobila")]
        public int MarkaId { get; set; }
        [Required(ErrorMessage = "Izaberite kategoriju automobila")]
        public int KategorijaId { get; set; }
        public int? TipId { get; set; }
        [Required(ErrorMessage = "Izaberite vrstu goriva")]
        public int GorivoId { get; set; }
        public int? ModelId { get; set; }
        public int KorisnikId { get; set; }
    }
}
