namespace DataServiceLib
{
    public class MovieSearchResult //Henter titler og bedømmelser
    {


        public string primarytitle { get; set; }
        public string originaltitle { get; set; }
        public float averagerating { get; set; }
    }

    public class NameSearchResult //Henter navn og roller
    {


        public string primaryname { get; set; }
        public string category { get; set; }
    }

}