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
        
      /*  public string orginaltitle { get; set; }

        public string type { get; set; }

        public string isadult { get; set; }

        public string startyear { get; set; }

        public string endyear { get; set; }

        public string runtime { get; set; }

        public string awards { get; set; }

        public string poster { get; set; }

        public string plot { get; set; }
        /*
        public override string ToString()
        {
            return $"titleid = {titleid}, primarytitle = {primarytitle}, titletype = {titletype}" +
                $"orginaltitle = {orginaltitle}, type = {type}, isadult = {isadult}, startyear = {startyear}," +
                $"endyear = {endyear}, runtime = {runtime}, awards = {awards}, poster = {poster}, plot = {plot} ";

        } */
    }
}