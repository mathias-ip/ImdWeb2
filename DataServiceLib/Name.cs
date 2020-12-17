
namespace DataServiceLib
{
    class Name
    {
        public string nameid { get; set; }

        public string primaryname { get; set; }

        public string nametype { get; set; }

        public string deathyear { get; set; }

        public string birthyear { get; set; }


        public override string ToString()
        {
            return $"nameid = {nameid}, ´primaryname = {primaryname}, nametype = {nametype}," +
                $" deathyear = {deathyear}, birthyear = {birthyear}";

        }

    }
}
