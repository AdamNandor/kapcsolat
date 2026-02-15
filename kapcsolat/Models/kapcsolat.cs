    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kapcsolat.Models
{
    internal class Kapcsolat
    {
        public Kapcsolat(int Id, string Nev, string Cim, string Email, string Tel)
        {
            id = Id;
            nev = Nev;
            cim = Cim;
            email = Email;
            tel = Tel;
        }
        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Cim { get => cim; set => cim = value; }
        public string Email { get => email; set => email = value; }
        public string Tel { get => tel; set => tel = value; }

        public Kapcsolat() { }

        int id {  get; set; }
        string nev { get; set; }
        string cim { get; set; }
        string email { get; set; }
        string tel { get; set; }
    }
}
