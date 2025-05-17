namespace Teendok
{
    public class Teendo
    {
        public int Azonosito;

        public string Feladat;

        public DateTime Idopont;

        public bool Megcsinaltae;

        public string NezzukMegHogyMegCsinaltaE() //Ez megnézi, hogy kész-e a feladat és visszaad egy emojit
        {
            if(Megcsinaltae == true)
            {
                return "✅";
            }
            else
            {
                return "❌";
            }
        }

        public override string ToString() //Így fog megjelenni a konzolon
        {
            return Azonosito +" - " + Feladat +" - " + Idopont +" - "+NezzukMegHogyMegCsinaltaE();
        }
    }
}
