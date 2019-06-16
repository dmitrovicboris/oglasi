using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SearchObjects
{
    public class BaseSearch
    {
        public int PerPage { get; set; } = 4;
        public int PageNumber { get; set; } = 1;
    }
}
