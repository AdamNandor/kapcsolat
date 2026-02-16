using Spectre.Console;
using kapcsolat.Controller;
using kapcsolat.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table = Spectre.Console.Table;

namespace kapcsolat.Views
{
    internal class KapcsolatView
    {
        public Table Tablazat(List<Kapcsolat> kapcsolatokLista)
        {
            var tablazat = new Table();
            tablazat.Border = TableBorder.Rounded;

            tablazat.AddColumn("ID");
            tablazat.AddColumn("Név");
            tablazat.AddColumn("Cím");
            tablazat.AddColumn("Email");
            tablazat.AddColumn("Telefon");

            foreach (Kapcsolat k in kapcsolatokLista)
            {
                tablazat.AddRow(
                    k.Id.ToString(),
                    k.Nev,
                    k.Cim,
                    k.Email,
                    k.Tel
                );
            }

            return tablazat;
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

