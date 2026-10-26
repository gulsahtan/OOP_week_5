using System;

namespace OOP_week_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kitap kitap1= new Kitap();
            kitap1.Ad = "Sefiller";
            kitap1.Yazar = "Victor Hugo";
            kitap1.sayfaSayisi = -19;
            kitap1.BilgileriGosterKitap();
            Console.WriteLine(kitap1.Tur);
            kitap1.OduncVer();
            kitap1.BilgileriGoster();

            Dergi dergi1= new Dergi();
            dergi1.Ad = "Bilim ve Teknik";
            dergi1.OduncVer();
            dergi1.BilgileriGoster();

            IOdunc[] yayinlar =
            {
                new Kitap { Ad = "Suç ve Ceza", Yazar = "Fyodor Dostoyevski", SayfaSayisi = 430 },
                new Dergi { Ad = "National Geographic" }

            };

            foreach (IOdunc yayin in yayinlar)
            {
                yayin.OduncVer();
            }

            KutuphaneAyarlari kutuphane = new KutuphaneAyarlari();
            kutuphane.KutuphaneAdi = "Merkez Kütüphane";
            kutuphane.BilgiGoster();
            Console.ReadLine();
        }
    }
}
