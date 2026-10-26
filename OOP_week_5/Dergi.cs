using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_week_5
{
    public class Dergi : Yayin, IOdunc
    {
        public string Ad;

        public override void BilgileriGoster()
        {
           Console.WriteLine("Dergi Adı: " + Ad);
        }

        public void OduncVer()
        {
            Console.WriteLine(Ad + "Dergisi ödünç verildi.");
        }
    }
}
