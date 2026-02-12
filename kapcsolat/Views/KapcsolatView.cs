using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kapcsolat.Controller;
using kapcsolat.Models;

namespace kapcsolat.Views
{
    internal class KapcsolatView
    {
        public void ShowKapcsolatList(List<Kapcsolat> kapcsolatLista)
        {
            Console.WriteLine("|--------┬------------------------------┬------------------------------┬------------------------------┬------------------|");
            Console.WriteLine("|   ID   | Név                          | Cím                          | Email                        | Telefon          |");
            Console.WriteLine("|--------┼------------------------------┼------------------------------┼------------------------------┼------------------|");

            foreach (Kapcsolat kapcsolat in kapcsolatLista)
            {
                Console.WriteLine(KapcsolatToRow(kapcsolat));
            }

            Console.WriteLine("|--------┴------------------------------┴------------------------------┴------------------------------┴------------------|");
        }

        private static string KapcsolatToRow(Kapcsolat kapcsolat)
        {
            string row = "| ";

            string id = kapcsolat.Id.ToString();
            row += id + new string(' ', 6 - id.Length) + " |";

            string nev = Levag(kapcsolat.Nev, 28);
            row += nev + new string(' ', 28 - nev.Length) + " |";

            string cim = Levag(kapcsolat.Cim, 28);
            row += cim + new string(' ', 28 - cim.Length) + " |";

            string email = Levag(kapcsolat.Email, 28);
            row += email + new string(' ', 28 - email.Length) + " |";

            string tel = Levag(kapcsolat.Tel, 16);
            row += tel + new string(' ', 16 - tel.Length) + "| ";

            return row;
        }

        private static string Levag(string szoveg, int hossz)
        {
            if (string.IsNullOrEmpty(szoveg))
                return "";

            if (szoveg.Length > hossz)
                return szoveg.Substring(0, hossz - 3) + "...";

            return szoveg;
        }

        public void CreateKapcsolatView()
        {
            List<int> kapcsolatIds = new KapcsolatController().GetKapcsolatIdList();
            List<string> kapcsolatAzonos = new KapcsolatController().GetSzolgaltatoRovidList();

            int szolgazon = -1;
            do
            {
                Console.Write("SzolgaltatasAzon");
                szolgazon = int.Parse(Console.ReadLine());
                if (!szolgaltatasIds.Contains(szolgazon))
                {
                    Console.WriteLine("Nincs ilyen szolgáltatás azonosító. A következőket használhatja:");
                    Console.WriteLine(string.Join(" ", szolgaltatasIds));
                    Console.WriteLine("Kérem, adja meg újra: ");
                }
            }
            while (!szolgaltatasIds.Contains(szolgazon));

            string szolgRov = "";
            do
            {
                Console.Write("SzolgaltatoRovidn");
                szolgRov = Console.ReadLine();
                if (!szolgaltatoAzons.Contains(szolgRov))
                {
                    Console.WriteLine("Nincs ilyen szolgáltató azonosító. A következőket használhatja:");
                    Console.WriteLine(string.Join(" ", szolgaltatoAzons));
                    Console.WriteLine("Kérem, adja meg újra: ");
                }
            }
            while (!szolgaltatoAzons.Contains(szolgRov));

            Console.WriteLine("Mettől: ");
            DateTime tol = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Meddig: ");
            DateTime ig = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Összeg: ");
            int osszeg = int.Parse(Console.ReadLine());

            Console.WriteLine("Határidő: ");
            DateTime hatarido = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Befizetve: ");
            string befizetString = Console.ReadLine();
            DateTime befizetve = befizetString == "" ? DateTime.MinValue : DateTime.Parse(befizetString);

            Console.WriteLine("Megjegyzés: ");
            string megjegyzes = Console.ReadLine();

            Szamla ujSzamla = new Szamla()
            {
                Id = -1,
                SzolgaltatasAzon = szolgazon,
                SzolgaltatoRovid = szolgRov,
                Tol = tol,
                Ig = ig,
                Osszeg = osszeg,
                Hatarido = hatarido,
                Befizetve = befizetve,
                Megjegyzes = megjegyzes
            };
            Console.WriteLine(new SzamlaController().CreateSzamla(ujSzamla));
        }
    }
}

