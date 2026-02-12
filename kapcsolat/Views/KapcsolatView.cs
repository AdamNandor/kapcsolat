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

        //public string CreateSzolgaltato(Kapcsolat kapcsolat)
        //{
        //    MySqlConnection connection = new MySqlConnection();
        //    string connectionString = "SERVER =localhost;DATABASE=kapcsolat;UID=root;PASSWORD=;";
        //    connection.ConnectionString = connectionString;
        //    try
        //    {
        //        connection.Open();
        //        string sql = "INSERT INTO `kapcsolat`(`Név`, `Cím`, `Email`, `Telefonszám`) VALUES (@Nev, @Cim, @Email, @Tel)";
        //        MySqlCommand command = new MySqlCommand(sql, connection);
        //        command.Parameters.AddWithValue("@Nev", kapcsolat.Nev);
        //        command.Parameters.AddWithValue("@Ugyfelszolgalat", kapcsolat.Cim);
        //        command.Parameters.AddWithValue("@Nev", kapcsolat.Email);
        //        command.Parameters.AddWithValue("@Ugyfelszolgalat", kapcsolat.Tel);
        //        int sorokSzama = command.ExecuteNonQuery();
        //        connection.Close();
        //        string valasz = sorokSzama > 0 ? "Sikeres rögzítés" : "Sikertelen rögzítés";
        //        return valasz;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Hiba történt: " + ex.Message;
        //    }
        //}
    }
}

