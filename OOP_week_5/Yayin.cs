using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_week_5
{
    public abstract class Yayin
    {
        public string Ad;
        public int YayinYili;

        public void YayinBilgileriniGoster()
        {
            Console.WriteLine("Yayın Adı: " + Ad);
            Console.WriteLine("Yayın Yılı: " + YayinYili);
        }
        public abstract void BilgileriGoster();
    }
}
