using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib
{
    public class Title
    {
        public string titleid { get; set; }

        public string primarytitle { get; set; }

        public string titletype  { get; set; }
        

        public override string ToString()
        {
            return $"titleid = {titleid}, ´primarytitle = {primarytitle}, titletype = {titletype}";

        }
    }
}