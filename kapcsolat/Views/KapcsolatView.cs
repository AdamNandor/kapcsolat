using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}

