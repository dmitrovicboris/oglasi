using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer.CreateDtos
{
    public class NapraviVrstuGoriva
    {
        public int GorivoId { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(30, ErrorMessage = "Gorivo moze sadrazati maksimalno 30 karaktera")]
        public string VrstaGoriva { get; set; }
    }
}
