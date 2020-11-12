using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebService.Models
{
    public class TitleDto
    {
        public string titleid { get; set; }

        public string primarytitle { get; set; }

        public string titletype { get; set; }

        public string orginaltitle { get; set; }

        public string type { get; set; }

        public string isadult { get; set; }

        public string startyear { get; set; }

        public string endyear { get; set; }

        public string runtime { get; set; }

        public string awards { get; set; }

        public string poster { get; set; }

        public string plot { get; set; }

    } 
}
    

