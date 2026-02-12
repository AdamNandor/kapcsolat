using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kapcsolat.Models
{
    internal class kapcsolat
    {
        public kapcsolat(int id, string nev, string cim, string email, string tel)
        {
            this.id = id;
            this.nev = nev;
            this.cim = cim;
            this.email = email;
            this.tel = tel;
        }
        public kapcsolat() { }

        int id {  get; set; }
        string nev { get; set; }
        string cim { get; set; }
        string email { get; set; }
        string tel { get; set; }
    }
}
