using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer.CreateDtos
{
    public class NapraviNoviTip
    {
        public int TipId { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(30, ErrorMessage = "Tip moze sadrazati maksimalno 30 karaktera")]
        public string Tip { get; set; }
    }
}
