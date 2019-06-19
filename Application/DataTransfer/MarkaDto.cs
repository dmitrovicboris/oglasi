using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class MarkaDto:BaseDto
    {
        public MarkaDto()
        {
            Models = new List<ModelDto>();
        }
        public string Marka { get; set; }

        public List<ModelDto> Models { get; set; }
    }
}
