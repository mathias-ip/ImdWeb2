using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace DataServiceLib
{

   
    public class DataService //: IDataService
    {
        public IList<Title> Gettitle()

        {
            var ctx = new Databasecontext();
            ctx.SaveChanges();
            return ctx.title.ToList();
        }
    }
}
