using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                        break;
                    case "2":

                        break;
                    case "3":

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
