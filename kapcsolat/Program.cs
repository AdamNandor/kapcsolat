using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kapcsolat.Controller;
using kapcsolat.Models;
using kapcsolat.Views;

namespace kapcsolat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool kilep = false;
            while (!kilep)
            {
                Console.Clear();
                Console.WriteLine("1. Kapcsolatok megjelenítése");
                Console.WriteLine("2. Új kapcsolat felvitele");
                Console.WriteLine("3. Kapcsolat módosítása");
                Console.WriteLine("4. Kapcsolat törlése");
                Console.WriteLine("5. Kilépés");
                string valasz = Console.ReadLine();

                switch (valasz)
                {
                    case "1":
                        List<Kapcsolat> listaAdatbazisbol = new KapcsolatController().GetKapcsolatList();
                        new KapcsolatView().ShowKapcsolatList(listaAdatbazisbol);
                        Console.WriteLine("Nyomj meg egy gombot a visszatéréshez...");
                        Console.ReadKey();
                        break;
                    case "2":
                        KapcsolatView view = new KapcsolatView();
                        KapcsolatController controller = new KapcsolatController();

                        Kapcsolat ujKapcsolat = view.CreateKapcsolatView();
                        string eredmeny = controller.CreateKapcsolat(ujKapcsolat);

                        Console.WriteLine(eredmeny);
                        Console.WriteLine("Nyomj meg egy gombot a visszatéréshez...");
                        Console.ReadKey();
                        break;
                    case "3":
                        new KapcsolatView().UpdateKapcsolatView();
                        break;
                    case "4":

                        break;
                    case "5":
                        kilep = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
