using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class KorisnikDto : BaseDto
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
