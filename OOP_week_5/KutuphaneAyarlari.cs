using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_week_5
{
    public sealed class KutuphaneAyarlari
    {
        public string KutuphaneAdi = "Merkez Kütüphane";
        public void BilgiGoster()
        {
             Console.WriteLine("Kütüphane Adı: " + KutuphaneAdi);
        }
    }
}
