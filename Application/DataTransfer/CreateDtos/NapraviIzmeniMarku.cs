using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer.CreateDtos
{
    public class NapraviIzmeniMarku
    {
        public int MarkaId { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(30, ErrorMessage = "Marka moze sadrazati maksimalno 30 karaktera")]
        public string Marka { get; set; }
    }
}
