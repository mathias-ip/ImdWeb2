using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataServiceLib
{
    public class SearchHistory
    {
        public int? Userid { get; set; }
        public string SearchEntry { get; set; }
        public DateTime SearchDate { get; set; }

    }
}
