using ConsoleTools;
using System.Text;

namespace Teendok
{
    internal class Program
    {
        //Ebben tároljuk el az összes teendőt
        static List<Teendo> Teendok = new List<Teendo>();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.OutputEncoding = Encoding.UTF8; //Ez kell ahhoz, hogy tudjunk emojikat kiírni

            ConsoleMenu teendomenu = new ConsoleMenu();



            Teendo tesztadat = new Teendo();

            tesztadat.Feladat = "Első tesztadat";

            tesztadat.Idopont = DateTime.Parse("2025.05.17. 12:20");

            tesztadat.Azonosito = 1;

            Teendok.Add(tesztadat);

            Teendo tesztadat2 = new Teendo();

            tesztadat2.Feladat = "Második tesztadat";

            tesztadat2.Idopont = DateTime.Parse("2025.05.17. 12:20");

            tesztadat2.Azonosito = 2;

            Teendok.Add(tesztadat2);

            teendomenu.Add("Teendő hozzáadása", Hozzaadas);

            teendomenu.Add("Teendő törlése", TeendoTorlese);

            teendomenu.Add("Összes teendő kiírása", Kiiras);

            teendomenu.Add("Teendő megcsinálása", Megcsinalas);

            teendomenu.Add("Megcsinálás visszavonása", MegcsinalasVisszavonasa);

            teendomenu.Add("Megcsinált teendők", MegcsinaltTeendok);

            teendomenu.Add("Nem megcsinált teendők", NemMegcsinaltTeendok);

            teendomenu.Add("Kilépés", teendomenu.CloseMenu);

            teendomenu.Show();
        }

        static void TeendoTorlese()
        {
            Console.WriteLine("Add meg az azonosítóját a teendőnek");

            try
            {
                int bekertszam = int.Parse(Console.ReadLine());

                for (int i = 0; i < Teendok.Count; i++) //Végigmegyünk az összes teendőn
                {
                    if (Teendok[i].Azonosito  == bekertszam) //Ha megtaláltuk a törlendő teendőt
                    {
                        Teendok.Remove(Teendok[i]);

                        Console.WriteLine("A teendő törölve.");
                    }
                }

                int ujazonosito = 1; //Újra állítjuk az azonosítókat

                foreach (var alma in Teendok)
                {
                    alma.Azonosito = ujazonosito;

                    ujazonosito++;
                }

            }
            catch
            {
                Console.WriteLine("HIBA: Nem jó számot adtál meg.");
            }

            Console.ReadLine();
        }

        static void MegcsinalasVisszavonasa()
        {
            Console.WriteLine("Add meg az azonosítóját a teendőnek!");

            try
            {
                int bekertszam = int.Parse(Console.ReadLine());

                foreach (var teendom in Teendok)
                {
                    //Ha az azonosító egyezik és nincs megcsinálva a teendő
                    if (teendom.Azonosito == bekertszam && teendom.Megcsinaltae == true )
                    {
                        teendom.Megcsinaltae = false;
                        Console.WriteLine("Megcsinálás visszavonva!");
                    }
                }
            }
            catch
            {
                Console.WriteLine("HIBA: Nem jó számot adtál meg.");
            }

            Console.ReadLine();
        }

        static void Megcsinalas()
        {
            Console.WriteLine("Add meg az azonosítóját a teendőnek!");

            try
            {
                int bekertszam = int.Parse(Console.ReadLine());

                foreach (var teendom in Teendok)
                {
                    if (teendom.Azonosito == bekertszam && teendom.Megcsinaltae == false)
                    {
                        teendom.Megcsinaltae = true;
                        Console.WriteLine("Teendő megcsinálva");
                    }
                }
            }
            catch
            {
                Console.WriteLine("HIBA: Nem jó számot adtál meg.");
            }

            Console.ReadLine();
        }

        static void NemMegcsinaltTeendok()
        {
            foreach (var teendom in Teendok)
            {
                if (teendom.Megcsinaltae == false)
                {
                    Console.WriteLine(teendom);
                }
            }

            Console.ReadLine();
        }

        static void MegcsinaltTeendok()
        {
            foreach (var teendom in Teendok)
            {
                if(teendom.Megcsinaltae == true)
                {
                    Console.WriteLine(teendom);
                }
            }

            Console.ReadLine();
        }

        static void Kiiras()
        {
            foreach (var teendom in Teendok)
            {
                Console.WriteLine(teendom);
            }

            Console.ReadLine();
        }

        static void Hozzaadas()
        {
            try
            {
                Console.WriteLine("Add meg a teendő szövegét!");

                string bekertSzoveg = Console.ReadLine();

                Console.WriteLine("Add meg a teendő időpontját! Pl: 2025.05.03. 14:30");

                DateTime idopont = DateTime.Parse(Console.ReadLine());

                Teendo teendo = new Teendo();

                teendo.Idopont = idopont;

                teendo.Feladat = bekertSzoveg;

                int osszesteendoszama = Teendok.Count; //Megszámoljuk, hogy mennyi teendonk van

                teendo.Azonosito = osszesteendoszama + 1;

                Teendok.Add(teendo);

                Console.WriteLine("A teendő sikeresen hozzáadva.");

                Console.ReadLine();
            }
            catch {
                Console.WriteLine("HIBA: Nem jól adtad meg a dátumot. Próbáld meg újra.");

                Console.ReadLine();
            }
        }
    }
}