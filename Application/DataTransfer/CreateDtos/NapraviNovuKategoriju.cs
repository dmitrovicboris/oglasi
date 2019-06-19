using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer.CreateDtos
{
    public class NapraviNovuKategoriju
    {
        public int KategorijaId { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(30, ErrorMessage = "Kategorija moze sadrazati maksimalno 30 karaktera")]
        public string Naziv { get; set; }
    }
}
