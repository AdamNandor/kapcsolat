using kapcsolat.Controller;
using kapcsolat.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Kapcsolat CreateKapcsolatView()
        {
            Console.Clear();
            Console.WriteLine("Új kapcsolat felvitele");

            Console.Write("Név: ");
            string nev = Console.ReadLine();

            Console.Write("Cím: ");
            string cim = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Telefon: ");
            string tel = Console.ReadLine();

            return new Kapcsolat()
            {
                Nev = nev,
                Cim = cim,
                Email = email,
                Tel = tel
            };
        }
        public void UpdateKapcsolatView()
        {
            Console.Clear();
            Console.WriteLine("Kapcsolat módosítása");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Új név: ");
            string nev = Console.ReadLine();

            Console.Write("Új cím: ");
            string cim = Console.ReadLine();

            Console.Write("Új email: ");
            string email = Console.ReadLine();

            Console.Write("Új telefon: ");
            string tel = Console.ReadLine();

            Kapcsolat kapcsolat = new Kapcsolat()
            {
                Id = id,
                Nev = nev,
                Cim = cim,
                Email = email,
                Tel = tel
            };

            KapcsolatController controller = new KapcsolatController();
            string eredmeny = controller.UpdateKapcsolat(kapcsolat);

            Console.WriteLine(eredmeny);
            Console.ReadKey();
        }
    }
}

