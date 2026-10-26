# 📚 OOP_week_5 – Interface, Abstract Class, Override, Sealed ve Encapsulation

Bu proje, **Nesne Tabanlı Programlama (Object-Oriented Programming – OOP)** dersi kapsamında C# programlama dili kullanılarak hazırlanmıştır.

Bu haftada, önceki derslerde öğrenilen sınıf oluşturma, nesne tanımlama, constructor, kalıtım ve polimorfizm konularının üzerine **Interface (Arayüz), Abstract Class (Soyut Sınıf), Override (Metot Ezme), Sealed (Mühürlü Sınıf) ve Encapsulation (Kapsülleme)** kavramları eklenmiştir.

Uygulamalar, bir **kütüphane sistemi** üzerinden hazırlanmıştır. `Kitap`, `Dergi`, `Yayin`, `IOdunc` ve `KutuphaneAyarlari` yapıları kullanılarak nesne tabanlı programlamanın temel prensipleri uygulamalı olarak gösterilmiştir.

## 🎯 Bu Haftanın Konuları

- Encapsulation (Kapsülleme) nedir?
- `private` ve `public` erişim belirleyicileri
- Property (Özellik) kavramı
- `get` ve `set` kullanımı
- Read-only property (`get;`)
- Abstract Class (Soyut Sınıf) nedir?
- `abstract` anahtar kelimesi
- Abstract metotlar
- `override` ile metotların yeniden tanımlanması
- Interface (Arayüz) nedir?
- `interface` tanımlama ve uygulama
- Bir sınıfın hem abstract class'tan kalıtım alması hem de interface uygulaması
- Interface kullanarak polimorfizm
- `sealed` anahtar kelimesi
- Abstract Class ve Interface arasındaki farklar

---

## 🧠 Projenin Amacı

Bu proje ile öğrencilerin:

- Sınıf içerisindeki verilere kontrollü erişim sağlayabilmesi,
- `private` değişkenleri `get` ve `set` üzerinden kullanabilmesi,
- Hatalı veri girişlerini kontrol edebilmesi,
- Soyut sınıflar oluşturabilmesi,
- Abstract metotları türetilmiş sınıflarda uygulayabilmesi,
- Interface tanımlayarak sınıflara ortak davranışlar kazandırabilmesi,
- Polimorfizmi interface üzerinden kullanabilmesi,
- `sealed` kullanarak kalıtımı sınırlandırabilmesi

hedeflenmiştir.

---

# 📂 1. Proje Yapısı

```text
OOP_week_5/
│
├── OOP_week_5.sln
│
└── OOP_week_5/
    │
    ├── Program.cs
    ├── Kitap.cs
    ├── Dergi.cs
    ├── Yayin.cs
    ├── IOdunc.cs
    ├── KutuphaneAyarlari.cs
    ├── OzelAyarlar.cs
    ├── OOP_week_5.csproj
    ├── App.config
    └── Properties/
        └── AssemblyInfo.cs
```

| Dosya | Açıklama |
|---|---|
| `Program.cs` | Uygulamanın başlangıç noktası ve örneklerin çalıştırılması |
| `Kitap.cs` | Encapsulation, property, interface ve override örnekleri |
| `Dergi.cs` | Abstract class kalıtımı, interface ve override |
| `Yayin.cs` | Abstract class ve abstract metot tanımlaması |
| `IOdunc.cs` | Interface tanımlaması |
| `KutuphaneAyarlari.cs` | Sealed class kullanımı |
| `OzelAyarlar.cs` | Boş sınıf örneği |
| `OOP_week_5.csproj` | Proje yapılandırması |

**Kullanılan teknoloji:** C# Console Application – .NET Framework 4.7.2

---

# 🔐 2. Encapsulation (Kapsülleme) Nedir?

Encapsulation, nesne tabanlı programlamanın temel prensiplerinden biridir.

Bir sınıf içerisindeki verilere doğrudan erişimi sınırlandırarak bu verilere kontrollü erişim sağlanmasını amaçlar.

Örneğin bir kitap sınıfında `SayfaSayisi` değişkeni bulunduğunu düşünelim.

Bu değişken `public` olarak tanımlanırsa sınıf dışından doğrudan değiştirilebilir.

```csharp
public int SayfaSayisi;
```

Program.cs içerisinde:

```csharp
kitap1.SayfaSayisi = -19;
```

Bu durumda negatif bir sayfa sayısı atanabilir.

Ancak gerçek bir kitap için negatif sayfa sayısı anlamlı değildir.

Bu nedenle ilgili değişkeni `private` olarak tanımlayıp değer atama işlemini kontrol edebiliriz.

## 🔹 Private Anahtar Kelimesi

`private`, bir sınıf içerisindeki üyeye erişimi tanımlandığı sınıfla sınırlandırır.

Projede `Kitap.cs` içerisinde:

```csharp
private int SayfaSayisi;
```

tanımlaması bulunmaktadır.

Bu nedenle aşağıdaki kullanım geçerli değildir:

```csharp
kitap1.SayfaSayisi = 200;
```

Çünkü `SayfaSayisi` değişkeni `private` olarak tanımlanmıştır.

Bunun yerine bir property kullanılır.

---

# 📘 3. Property – Get ve Set Kullanımı

Property, bir sınıf içerisindeki verilere kontrollü erişim sağlamak için kullanılan yapıdır.

C# dilinde property içerisinde `get` ve `set` erişimcileri kullanılabilir.

- `get` → Değeri okumak için kullanılır.
- `set` → Değer atamak için kullanılır.
- `value` → `set` bloğuna gönderilen yeni değeri temsil eder.

## 🔹 Kitap.cs İçerisindeki Örnek

```csharp
private int SayfaSayisi;

public int sayfaSayisi
{
    get
    {
        return SayfaSayisi;
    }

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
```

### Kodun Açıklaması

```csharp
private int SayfaSayisi;
```

Sayfa sayısının saklandığı özel değişkendir.

```csharp
get
{
    return SayfaSayisi;
}
```

Sayfa sayısını dışarıya döndürür.

```csharp
set
{
    if (value > 0)
    {
        SayfaSayisi = value;
    }
}
```

Yeni değer yalnızca sıfırdan büyük olduğunda kabul edilir.

## 🔹 Program.cs İçerisinde Kullanımı

```csharp
Kitap kitap1 = new Kitap();

kitap1.Ad = "Sefiller";
kitap1.Yazar = "Victor Hugo";

kitap1.sayfaSayisi = -19;
```

Bu işlem sonucunda:

```text
Kitap sayfa sayısı negatif olamaz.
```

mesajı görüntülenir.

Çünkü girilen değer sıfırdan küçüktür.

Negatif değer kabul edilmediği için `SayfaSayisi` alanının başlangıç değeri olan `0` değişmeden kalır.

Geçerli bir sayfa sayısı girildiğinde:

```csharp
kitap1.sayfaSayisi = 500;
```

yeni değer başarıyla atanır.

### Önemli Nokta

Encapsulation sayesinde sınıf içerisindeki değişkenlere kontrolsüz değer atanması engellenebilir.

Ancak yalnızca `private` kullanmak tek başına bütün doğrulama işlemlerinin yapıldığı anlamına gelmez. Veri kontrolü property veya metot içerisinde açıkça tanımlanmalıdır.

---

# 📗 4. Sadece Get Kullanımı – Read-Only Property

Bazı özelliklerin dışarıdan okunabilmesini ancak dışarıdan değiştirilememesini isteyebiliriz.

Bu durumda yalnızca `get` erişimcisi tanımlanabilir.

Projede `Kitap.cs` içerisinde:

```csharp
public string Tur { get; } = "Roman";
```

tanımlaması bulunmaktadır.

Bu property, oluşturulan kitap için tür bilgisini `"Roman"` olarak belirler.

### Program.cs

```csharp
Console.WriteLine(kitap1.Tur);
```

Ekran çıktısı:

```text
Roman
```

Ancak:

```csharp
kitap1.Tur = "Hikaye";
```

ifadesi kullanılamaz.

Çünkü property üzerinde dışarıdan değer atamaya izin veren bir `set` erişimcisi bulunmamaktadır.

## 🔹 Property Türleri

| Tanımlama | Açıklama |
|---|---|
| `get; set;` | Okuma ve yazma yapılabilir |
| `get; private set;` | Dışarıdan okunabilir, sınıf içerisinden değiştirilebilir |
| `get;` | Dışarıdan okunabilir, dışarıdan doğrudan değiştirilemez |

### Örnek: Otomatik Property

```csharp
public string Ad { get; set; }
```

Bu kullanımda C# derleyicisi, değeri saklamak için arka planda bir alan oluşturur.

---

# 📘 5. Abstract Class (Soyut Sınıf) Nedir?

Abstract Class, kendisinden doğrudan nesne oluşturulamayan, diğer sınıflar için ortak bir yapı sunan sınıftır.

`abstract` anahtar kelimesi kullanılarak tanımlanır.

Soyut sınıflar içerisinde:

- Değişkenler
- Property'ler
- Constructor'lar
- Normal metotlar
- Abstract metotlar

bulunabilir.

## 🔹 Yayin.cs

Projede `Yayin` sınıfı abstract class olarak tanımlanmıştır.

```csharp
using System;

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
```

### Kodun Açıklaması

```csharp
public abstract class Yayin
```

Bu ifade `Yayin` sınıfını soyut sınıf olarak tanımlar.

Aşağıdaki kullanım geçerli değildir:

```csharp
Yayin yayin1 = new Yayin();
```

Çünkü abstract class'tan doğrudan nesne oluşturulamaz.

Ancak `Yayin` sınıfından kalıtım alan somut sınıflardan nesne oluşturulabilir.

Örneğin:

```csharp
Kitap kitap1 = new Kitap();
Dergi dergi1 = new Dergi();
```

---

# 📘 6. Abstract Metot Nedir?

Abstract metot, soyut sınıfta bildirilen ancak gövdesi bu noktada tanımlanmayan metottur.

Projede:

```csharp
public abstract void BilgileriGoster();
```

ifadesi bulunmaktadır.

Bu metodun gövdesi `Yayin` sınıfında yazılmamıştır.

Metodun nasıl çalışacağı, bu sınıftan türetilen somut sınıflarda belirlenir.

## 🔹 Kitap Sınıfında Override

```csharp
public override void BilgileriGoster()
{
    Console.WriteLine("Kitap Adı: " + Ad);
}
```

## 🔹 Dergi Sınıfında Override

```csharp
public override void BilgileriGoster()
{
    Console.WriteLine("Dergi Adı: " + Ad);
}
```

Her iki sınıf da `Yayin` sınıfından kalıtım aldığı için abstract metodu kendi içerisinde uygulamıştır.

Bu örnekte `BilgileriGoster()` metodunun davranışı nesnenin gerçek türüne göre değişmektedir.

---

# 🔄 7. Override Anahtar Kelimesi

`override`, temel sınıfta `virtual`, `abstract` veya `override` olarak tanımlanmış uygun bir metodun türetilmiş sınıfta yeniden tanımlanmasını sağlar.

Önceki haftada `virtual` metotların yeniden tanımlanmasını görmüştük.

Bu hafta ise abstract metotların `override` ile uygulanmasını gördük.

### Abstract Sınıf

```csharp
public abstract void BilgileriGoster();
```

### Kitap Sınıfı

```csharp
public override void BilgileriGoster()
{
    Console.WriteLine("Kitap Adı: " + Ad);
}
```

### Dergi Sınıfı

```csharp
public override void BilgileriGoster()
{
    Console.WriteLine("Dergi Adı: " + Ad);
}
```

## Virtual ve Abstract Arasındaki Fark

| Özellik | Virtual | Abstract |
|---|---|---|
| Metot gövdesi bulunur mu? | Evet | Hayır |
| Alt sınıfta override zorunlu mu? | Hayır | Somut alt sınıfta evet |
| Hangi sınıfta tanımlanabilir? | Soyut olmayan veya soyut sınıfta | Abstract class içerisinde |
| Temel amacı | Mevcut davranışın değiştirilebilmesini sağlamak | Alt sınıfların uygulaması gereken davranışı tanımlamak |

---

# 🔌 8. Interface (Arayüz) Nedir?

Interface, sınıfların uygulaması gereken ortak davranışları tanımlamak için kullanılır.

Bir interface, kendisini uygulayan sınıfların hangi metotları sağlaması gerektiğini belirtir.

Örneğin kütüphanede:

- Kitap ödünç verilebilir.
- Dergi ödünç verilebilir.

Bu iki yayın türü için ortak bir `OduncVer()` davranışı tanımlayabiliriz.

## 🔹 IOdunc.cs

```csharp
namespace OOP_week_5
{
    public interface IOdunc
    {
        void OduncVer();
    }
}
```

Burada:

```csharp
public interface IOdunc
```

ifadesi bir interface tanımlar.

```csharp
void OduncVer();
```

ise bu interface'i uygulayan sınıfların sağlaması gereken metodu bildirir.

Interface içerisinde bu metot için gövde tanımlanmamıştır.

## 🔹 Interface İsimlendirme

C# dilinde interface isimleri genellikle `I` harfi ile başlar.

Örneğin:

- `IOdunc`
- `IYazdirilabilir`
- `IHesaplanabilir`

Bu zorunlu bir sözdizimi kuralı değil, yaygın bir isimlendirme geleneğidir.

---

# 📚 9. Kitap Sınıfında Interface Kullanımı

Projede `Kitap` sınıfı aşağıdaki şekilde tanımlanmıştır:

```csharp
public class Kitap : Yayin, IOdunc
```

Bu ifade iki farklı ilişkiyi belirtir:

1. `Kitap`, `Yayin` abstract sınıfından kalıtım alır.
2. `Kitap`, `IOdunc` interface'ini uygular.

## 🔹 OduncVer Metodu

```csharp
public void OduncVer()
{
    Console.WriteLine(Ad + "kitabı ödünç verildi.");
}
```

Bu metot, `IOdunc` interface'inde belirtilen davranışı gerçekleştirir.

### Program.cs

```csharp
Kitap kitap1 = new Kitap();

kitap1.Ad = "Sefiller";
kitap1.Yazar = "Victor Hugo";

kitap1.OduncVer();
```

Ekran çıktısı:

```text
Sefillerkitabı ödünç verildi.
```

> Not: Depodaki mevcut kodda `Ad` değişkeni ile `"kitabı ödünç verildi."` metni arasında boşluk bulunmadığı için çıktı bitişik oluşmaktadır. Daha okunabilir bir çıktı için `Ad + " kitabı ödünç verildi."` kullanılabilir.

---

# 📰 10. Dergi Sınıfında Interface Kullanımı

`Dergi` sınıfı da hem `Yayin` sınıfından kalıtım almakta hem de `IOdunc` interface'ini uygulamaktadır.

## 🔹 Dergi.cs

```csharp
using System;

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
```

### Program.cs

```csharp
Dergi dergi1 = new Dergi();

dergi1.Ad = "Bilim ve Teknik";

dergi1.OduncVer();

dergi1.BilgileriGoster();
```

Beklenen çıktı:

```text
Bilim ve TeknikDergisi ödünç verildi.
Dergi Adı: Bilim ve Teknik
```

Burada da ödünç verme mesajının başına bir boşluk eklenerek çıktı düzenlenebilir.

### Önemli Nokta

`Kitap` ve `Dergi` sınıflarının her ikisi de `IOdunc` interface'ini uyguladığı için ikisinde de `OduncVer()` metodu bulunmaktadır.

Ancak bu metodun içeriği her sınıfta farklı olabilir.

---

# 🔄 11. Interface ile Polimorfizm

Interface kullanılarak farklı sınıflardan oluşturulan nesneler ortak bir tür üzerinden yönetilebilir.

Projede `Program.cs` içerisinde aşağıdaki örnek bulunmaktadır:

```csharp
IOdunc[] yayinlar =
{
    new Kitap
    {
        Ad = "Suç ve Ceza",
        Yazar = "Fyodor Dostoyevski",
        SayfaSayisi = 430
    },

    new Dergi
    {
        Ad = "National Geographic"
    }
};
```

Burada `IOdunc` türünde bir dizi oluşturulmuştur.

Bu dizinin içerisinde hem `Kitap` hem de `Dergi` nesnesi bulunmaktadır.

Çünkü her iki sınıf da `IOdunc` interface'ini uygulamaktadır.

## 🔹 Foreach ile Kullanımı

```csharp
foreach (IOdunc yayin in yayinlar)
{
    yayin.OduncVer();
}
```

Bu döngüde:

- Nesne `Kitap` ise `Kitap.OduncVer()` çalışır.
- Nesne `Dergi` ise `Dergi.OduncVer()` çalışır.

**Aynı metot çağrısının farklı nesnelerde farklı şekilde çalışması polimorfizmin bir örneğidir.**

Bu yapı sayesinde farklı sınıflardan oluşturulmuş nesneler ortak bir interface üzerinden kullanılabilir.

---

# ⚖️ 12. Abstract Class ve Interface Arasındaki Fark

Abstract Class ve Interface benzer amaçlara hizmet edebilse de aralarında önemli farklılıklar bulunmaktadır.

| Özellik | Abstract Class | Interface |
|---|---|---|
| Tanımlama | `abstract class` | `interface` |
| Nesne oluşturulabilir mi? | Hayır | Hayır |
| Değişken (instance field) içerebilir mi? | Evet | Hayır |
| Constructor içerebilir mi? | Evet | Hayır |
| Normal metot içerebilir mi? | Evet | Modern C# sürümlerinde koşullu olarak evet |
| Soyut davranış tanımlayabilir mi? | Evet | Evet |
| Bir sınıf birden fazla sınıftan kalıtım alabilir mi? | Hayır | Uygulanamaz |
| Bir sınıf birden fazla interface uygulayabilir mi? | — | Evet |

## Abstract Class Ne Zaman Kullanılır?

Sınıflar arasında ortak bir temel yapı bulunduğunda kullanılabilir.

Örneğin:

```csharp
public abstract class Yayin
```

`Kitap` ve `Dergi`, bir yayın türü olarak ortak özelliklere sahiptir.

Bu nedenle soyut bir `Yayin` sınıfı kullanılabilir.

## Interface Ne Zaman Kullanılır?

Birbirinden farklı sınıfların ortak bir davranışı gerçekleştirmesi gerektiğinde kullanılabilir.

Örneğin:

```csharp
public interface IOdunc
```

Ödünç verilebilen bütün nesneler bu interface'i uygulayabilir.

**Not:** Bu proje .NET Framework 4.7.2 ve klasik C# interface kullanımını göstermektedir. Interface içerisindeki varsayılan metot gövdeleri gibi daha yeni C# özellikleri bu uygulamanın kapsamı dışındadır.

---

# 🔒 13. Sealed Anahtar Kelimesi

`sealed`, bir sınıftan başka sınıfların kalıtım almasını engellemek için kullanılır.

Bu tür sınıflara **mühürlü sınıf (sealed class)** denir.

## 🔹 KutuphaneAyarlari.cs

```csharp
using System;

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
```

Burada:

```csharp
public sealed class KutuphaneAyarlari
```

ifadesi `KutuphaneAyarlari` sınıfını mühürlü olarak tanımlar.

Bu sınıftan nesne oluşturulabilir.

```csharp
KutuphaneAyarlari kutuphane = new KutuphaneAyarlari();

kutuphane.BilgiGoster();
```

Ancak aşağıdaki gibi kalıtım alınamaz:

```csharp
public class YeniAyarlar : KutuphaneAyarlari
{
}
```

Bu kod derleme hatasına neden olur.

Çünkü `KutuphaneAyarlari` sınıfı `sealed` olarak tanımlanmıştır.

## Sealed Ne Zaman Kullanılır?

Bir sınıfın başka sınıflar tarafından genişletilmesini istemediğimiz durumlarda kullanılabilir.

Örneğin belirli bir yardımcı sınıfın kalıtımla değiştirilmesini sınırlamak için tercih edilebilir.

**Önemli:** `sealed` sınıfın üyelerini otomatik olarak değiştirilemez yapmaz. Yalnızca sınıftan kalıtım alınmasını engeller.

---

# 💻 14. Program.cs – Uygulamanın Tamamı

Projede bulunan `Program.cs` dosyası aşağıdaki gibidir:

```csharp
using System;

namespace OOP_week_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kitap kitap1 = new Kitap();

            kitap1.Ad = "Sefiller";
            kitap1.Yazar = "Victor Hugo";
            kitap1.sayfaSayisi = -19;

            kitap1.BilgileriGosterKitap();

            Console.WriteLine(kitap1.Tur);

            kitap1.OduncVer();

            kitap1.BilgileriGoster();


            Dergi dergi1 = new Dergi();

            dergi1.Ad = "Bilim ve Teknik";

            dergi1.OduncVer();

            dergi1.BilgileriGoster();


            IOdunc[] yayinlar =
            {
                new Kitap
                {
                    Ad = "Suç ve Ceza",
                    Yazar = "Fyodor Dostoyevski",
                    SayfaSayisi = 430
                },

                new Dergi
                {
                    Ad = "National Geographic"
                }
            };

            foreach (IOdunc yayin in yayinlar)
            {
                yayin.OduncVer();
            }


            KutuphaneAyarlari kutuphane =
                new KutuphaneAyarlari();

            kutuphane.KutuphaneAdi = "Merkez Kütüphane";

            kutuphane.BilgiGoster();

            Console.ReadLine();
        }
    }
}
```

## Bu Kodda Hangi Konular Kullanılıyor?

| Kod | Kavram |
|---|---|
| `new Kitap()` | Nesne oluşturma |
| `kitap1.sayfaSayisi = -19` | Encapsulation ve set doğrulaması |
| `kitap1.Tur` | Get-only property |
| `kitap1.BilgileriGoster()` | Override edilmiş metot |
| `kitap1.OduncVer()` | Interface uygulaması |
| `new Dergi()` | Abstract sınıftan türetilmiş somut sınıf |
| `IOdunc[] yayinlar` | Interface ile polimorfizm |
| `foreach (IOdunc yayin ...)` | Ortak interface üzerinden metot çağırma |
| `new KutuphaneAyarlari()` | Sealed sınıftan nesne oluşturma |

---

# ❓ Ders Sonu Tekrar Soruları

1. Encapsulation nedir, neden kullanılır?
2. `private` ile `public` arasındaki fark nedir?
3. Property nedir?
4. `get` ve `set` ne işe yarar?
5. `value` anahtar sözcüğü neyi temsil eder?
6. Sadece `get` tanımlanan property'ye dışarıdan değer atanabilir mi?
7. Abstract Class nedir?
8. Abstract Class'tan doğrudan nesne oluşturulabilir mi?
9. Abstract metot ile normal metot arasındaki fark nedir?
10. `override` neden kullanılır?
11. Interface nedir?
12. Bir sınıf birden fazla interface uygulayabilir mi?
13. Interface ile Abstract Class arasındaki fark nedir?
14. `IOdunc[]` dizisinde neden hem kitap hem de dergi nesnesi tutulabiliyor?
15. `sealed` anahtar kelimesi ne işe yarar?
16. Sealed sınıftan nesne oluşturulabilir mi?
17. Bir sınıf hem abstract class'tan kalıtım alıp hem de interface uygulayabilir mi?



# 📌 Sonuç

Bu haftaki uygulamalarda C# nesne tabanlı programlamanın önemli kavramlarından olan **Encapsulation, Abstract Class, Interface, Override ve Sealed** konuları ele alınmıştır.

- **Kitap sınıfı** ile encapsulation, property, `get`, `set`, interface ve override,
- **Yayin sınıfı** ile abstract class ve abstract metot,
- **Dergi sınıfı** ile kalıtım, interface uygulaması ve override,
- **IOdunc interface'i** ile ortak davranışların tanımlanması,
- **KutuphaneAyarlari sınıfı** ile sealed sınıf,
- **Program.cs** ile nesne oluşturma, veri doğrulama ve interface üzerinden polimorfizm

uygulamalı olarak gösterilmiştir.


