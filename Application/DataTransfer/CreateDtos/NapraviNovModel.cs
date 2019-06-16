using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer.CreateDtos
{
    public class NapraviNovModel
    {
        public int ModelId { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(30, ErrorMessage = "Model moze sadrazati maksimalno 30 karaktera")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        public int MarkaId { get; set; }
    }
}
