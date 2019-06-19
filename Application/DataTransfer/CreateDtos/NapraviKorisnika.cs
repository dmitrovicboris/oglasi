using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer.CreateDtos
{
    public class NapraviKorisnika
    {
        public int KorisnikId { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(30, ErrorMessage = "Marka moze sadrazati maksimalno 30 karaktera")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(30, ErrorMessage = "Marka moze sadrazati maksimalno 30 karaktera")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
