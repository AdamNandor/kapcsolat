using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kapcsolat.Models;
using MySql.Data.MySqlClient;

namespace kapcsolat.Controller
{
    internal class KapcsolatController
    {
        public List<Kapcsolat> GetKapcsolatList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kapcsolat;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT * FROM kapcsolat";
                MySqlCommand command = new MySqlCommand(sql, connection);
                List<Kapcsolat> eredmeny = new List<Kapcsolat>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eredmeny.Add(new Kapcsolat()
                    {
                        Id = Convert.ToInt32(reader["Azonosító"]),
                        Nev = reader.GetString("Név"),
                        Cim = reader.GetString("Cím"),
                        Email = reader.GetString("Email"),
                        Tel = reader.GetString("Telefon")
                    });
                }
                connection.Close();
                return eredmeny;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
                Console.ReadKey();
                return new List<Kapcsolat>();
            }
        }

        public string CreateKapcsolat(Kapcsolat kapcsolat)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kapcsolat;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "INSERT INTO `kapcsolat`(`Név`, `Cím`, `Email`, `Telefon`) VALUES (@Nev, @Cim, @Email, @Tel)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Nev", kapcsolat.Nev);
                command.Parameters.AddWithValue("@Cim", kapcsolat.Cim);
                command.Parameters.AddWithValue("@Email", kapcsolat.Email);
                command.Parameters.AddWithValue("@Tel", kapcsolat.Tel);
                int sorokSzama = command.ExecuteNonQuery();
                connection.Close();
                string valasz = sorokSzama > 0 ? "Sikeres rögzítés" : "Sikertelen rögzítés";
                return valasz;
            }
            catch (Exception ex)
            {
                return "Hiba történt: " + ex.Message;
            }
        }

        public string UpdateKapcsolat(Kapcsolat kapcsolat)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kapcsolat;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "UPDATE kapcsolat SET Név=@Nev, Cím=@Cim, Email=@Email, Telefon=@Tel WHERE Azonosító=@Id";


                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", kapcsolat.Id);
                command.Parameters.AddWithValue("@Nev", kapcsolat.Nev);
                command.Parameters.AddWithValue("@Cim", kapcsolat.Cim);
                command.Parameters.AddWithValue("@Email", kapcsolat.Email);
                command.Parameters.AddWithValue("@Tel", kapcsolat.Tel);
                int sorokSzama = command.ExecuteNonQuery();
                connection.Close();
                string valasz = sorokSzama > 0 ? "Sikeres módosítás" : "Sikertelen módosítás";
                return valasz;
            }
            catch (Exception ex)
            {
                return "Hiba történt: " + ex.Message;
            }
        }

        public string DeleteKapcsolat(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kapcsolat;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "DELETE FROM `kapcsolat` WHERE `Azonosító` = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                int sorokSzama = command.ExecuteNonQuery();
                connection.Close();
                string valasz = sorokSzama > 0 ? "Sikeres törlés" : "Sikertelen törlés";
                return valasz;
            }
            catch (Exception ex)
            {
                return "Hiba történt: " + ex.Message;
            }
        }
    }
}
