using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_week_5
{
    public class Kitap : Yayin, IOdunc
    {
        public string Ad;
        public string Yazar;
        private int SayfaSayisi;

        public string Tur { get; } = "Roman";

        public int sayfaSayisi
        {
            get { return SayfaSayisi; }
            set
            {
                if (value > 0)
                {
                    SayfaSayisi = value;

                }
                else
                {
                    Console.WriteLine("Kitap sayfa sayısı negatif olamaz.");
                }
            }
        }

        public void OduncVer()
        {
           Console.WriteLine(Ad+ "kitabı ödünç verildi.");
        }
        public void BilgileriGosterKitap() {             
            Console.WriteLine("Kitap Adı: " + Ad);
            Console.WriteLine("Yazar: " + Yazar);
            Console.WriteLine("Sayfa Sayısı: " + SayfaSayisi);
        }

        public override void BilgileriGoster()
        {
            Console.WriteLine("Kitap Adı: " + Ad);
        }
    }
}
