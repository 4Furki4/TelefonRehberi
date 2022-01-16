// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Generic;
void TaslakYazıcı() // Yapılacak işlemleri tekrar tekrar yazmaktan kurtaracak metot.
{
Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) \n*****************************************************");
Console.WriteLine("(1) Yeni Numara Kaydetmek");
Console.WriteLine("(2) Varolan Numarayı Silmek");
Console.WriteLine("(3) Varolan Numarayı Güncelleme");
Console.WriteLine("(4) Rehberi Listelemek");
Console.WriteLine("(5) Rehberde Arama Yapmak");
Console.WriteLine("(6) Konsolu Kapatmak");
}
KisiYonetimi Secenekler = new KisiYonetimi();

List<Kisi> Rehber= new List<Kisi>(); // Rehber içinde kullanacağım listeyi oluşturdum ve projede söylenildiği gibi varsayılan 5 kişi atadım.
           Rehber.Add(new Kisi("Furkan","Cengiz","5071707878"));
           Rehber.Add(new Kisi("Semiha","Kansız","5354441454"));
           Rehber.Add(new Kisi("Umut","Tavşan","5132313113"));
           Rehber.Add(new Kisi("Esat","Cengiz","0555553681"));
           Rehber.Add(new Kisi("Aybüke", "Akçelik","5052604416"));

           

void KonsolIslemcisi()  /* Konsoldan alınan girdilere göre işlemleri başlatan veya yanlış girdi alınırsa rehberdeki işlemlerin devam etmesini sağlayan metodum. 
                        Yanlış aralıkta veri girilince konsolun çökmemesini sağlıyor.*/
{
int islem =0;
int KonsolKapatıcı=0;
while(KonsolKapatıcı!=6)
{   //İşlemleri konsoldan girilen veriye bağlı olarak başlatan if-else yapısı. sonlarına break yazdım ve bu şekilde sonsuz döngüyü engelledim.
switch (islem)
    {
    case 1:
    Secenekler.KisiYarat(Rehber);
    //KonsolIslemcisi metodunu her birinde islemleri yaptıktan sonra çağırarak mezkur işlem yapıldıktan sonra yeni işlem yapabilmeyi veya rehberi kapatmayı sağladım.
    KonsolIslemcisi();
    break;
    case 2:
    Secenekler.KisiSil(Rehber);
    KonsolIslemcisi();
    break;
    case 3:
    Secenekler.KisiGuncelle(Rehber);
    KonsolIslemcisi();
    break;
    case 4:
    Secenekler.KisileriListele(Rehber);
    KonsolIslemcisi();
    break;
    case 5:
    Secenekler.KisiArama(Rehber);
    KonsolIslemcisi();
    break;   
    case 6:
    KonsolKapatıcı=6; 
    Console.WriteLine("Console'dan başarılı bir şekilde çıkış yapıldı, yine bekleriz :=)"); 
    break; 
    }
    
    
if(islem<1 || islem>6)
{
    Console.WriteLine("Lütfen 1-6 arası bir rakam girdiğinizden emin olunuz.\n");
    TaslakYazıcı();
    if(int.TryParse(Console.ReadLine(), out int TryParsedIslem)) /* Konsola girilen verinin istediğimiz tipte (integer) olup olmadığını kontrol ediyor. 
                        Söz gelimi bir metin girilirse hem hatayı algılıyor hem mesaj yazdırıyor hem de istenilen işlemi yapma sürecini devam ettiriyorum. */
    {
        islem =TryParsedIslem;
    }else
    {
        Console.WriteLine("Lütfen 1-6 arası rakam girdiğinizden emin olunuz.\n");
        TaslakYazıcı();
        KonsolIslemcisi(); // Tekrardan aynı işlemleri ekrana yazdırıp girdi almak için metodumuzu geri çağırdım.
    }
    
    continue; // sonsuz döngü olmaması için continue yazmak zorundayım.

}
}

}

KonsolIslemcisi(); // Yazdığım metodu buraya yazarak konsolda çalışmasını sağlayalım :=)




class Kisi{ // Rehberde kişileri nesne olarak tutmak icap ediyor, Kisi adlı sınıfla nesne oluşturabiliriz.
    public Kisi(string isimGirdisi, string soyIsimGirdisi, string numara)
    {
        isim=isimGirdisi;
        soyIsim=soyIsimGirdisi;
        telNo= numara;
    }
    string isim; // Kisi'den oluşan nesnenin isim property'si.
    string soyIsim; // Kisi'den oluşan nesnenin soyisim property'si.
    string telNo;  // Kisi'den oluşan nesnenin telefon property'si.
    public string Isim // burada encapsulation yaptım.
    {
        get
        {
            return isim;
        }
        set{
            isim=value;
        }
    }
    public string SoyIsim{
        get{
            return soyIsim;
        }
        set{
            soyIsim=value;
        }
    }
    public string TelNo
    {

        get
        {
            return telNo;
        }
        set
        {
            telNo=value;
        }
    }
}

class KisiYonetimi // Rehberdeki kişiler üzerinden yapılan işemleri yöneten sınıf, içerisinde TaslakYazıcı'da yazdığım işlemlerin metotlarını içeriyor.
{
    public void KisiYarat(List<Kisi> rehber) // Yeni kişi yaratan metot, yarattığı kişileri Rehber listesine ekler.
    {
        Console.Write("Lütfen isim giriniz              :");
        string isim=Console.ReadLine();
        Console.Write("Lütfen soyisim giriniz           :");
        string soyisim= Console.ReadLine();
        Console.Write("Lütfen telefon numarası giriniz  :");
        string numara=Console.ReadLine();
        Kisi yeniInsan = new Kisi(isim,soyisim,numara);
        rehber.Add(yeniInsan);
    }
        // Konsoldan alınan ismi veya soyismi Rehber listesinde arayıp silen veya bulamayıp mesaj verip tekrardan girdi isteyen kişi silme metodum.
        public void KisiSil(List<Kisi> list) 
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string input =Console.ReadLine();
            int durum=0; // bu değişken, girilen verinin isim veya soyisimle örtüşüp örtüşmediği durumu tutar.
            
                foreach (var item in list)
            {
                if(item.Isim ==input || item.SoyIsim== input)
                {
                   Console.Write($" {item.Isim} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n):");
                   string cevap=Console.ReadLine();
                   if(cevap=="y")
                   {
                       list.Remove(item);
                       durum++; // örtüşürse durum'un değeri artar ve alttaki if döngüsüne girmeyiz.
                       break;
                   }else if(cevap=="n")
                   {
                    break;
                   }
                }
                
            } // durum artmazsa-yani girilen veri örtüşmezse- durum değişkeni bu döngüyü çalıştırır.
            if (durum==0)
            {
                
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için      : (2)");
                    Console.Write("Yapmak istediğiniz işleme tekabül eden sayıyı giriniz:");
                    int cevap =int.Parse(Console.ReadLine());
                    if(cevap==1)
                    {
                        Console.WriteLine("Silme işlemi sonlandırıldı.");
                        
                    }else if(cevap==2)
                    {
                        KisiSil(list); // Tüm işlemleri yeniden başlatmak için metodumuzu çağırıyoruz.
                    }
                
            }
        
        }
        public void KisiGuncelle(List<Kisi> list) /* Rehber listesindeki kişileri, girilen numaraya göre güncelleyen metot. 
                                                  Numara bulunamazsa tekrar denemeyi veya işlemi sonlandırmayı seçtiriyor.*/
        {
            Console.Write("Lütfen güncellemek istediğiniz numarayı giriniz:");
            string numara= Console.ReadLine();
            
            int durum=0; /* Bu değişkeni, foreach yapısında numara bulunursa artırıyorum ve böylelikle veri bulunamadı kısmına girmiyorum. 
                         Eğer durum artmazsa veri bulunamadı olarak sayılıyor.*/
            foreach (var item in list) // Önce listedeki "Kişi"lere ulaşıyoruz.
            {
                //Kişi nesnelerinin telefon numaraları özelliğine ulaşarak bunun girilen veriyle örtüşüp örtüşmediğini kontrol ediyor. 
                if (item.TelNo==numara) 
                {
                //örtüşürse mezkur numaranın bilgilerini güncelliyor.

                    Console.Write("Lütfen yeni ismi giriniz:");
                    item.Isim=Console.ReadLine();
                    Console.Write("Lütfen yeni soyismi giriniz:");
                    item.SoyIsim=Console.ReadLine();
                    Console.WriteLine("Girdiğiniz numaranın bilgileri başarıyla güncellendi.\n");
                    durum++;
                    break;
                }
            }
            if(durum==0) // Foreach döngüsü bittikten sonra verinin bulunamadığı durumu gerçekleştiren yapı.
            {
                void VeriBulunamadı() // Girinen veri bulunamadığında çalışacak kodları içeren bir metot. Else durumunda tekrardan aynı kodları yazmamak için kodları metoda yazdım. 
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız:");
                    Console.Write("* Güncellemeyi sonlandırmak için    : (1)\n* Yeniden denemek için              : (2)");
                    int islemNo=int.Parse(Console.ReadLine());
                    if (islemNo==1)
                    {

                    }
                    else if(islemNo==2)
                    {
                        KisiGuncelle(list);
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz veri 1 veya 2 olarak algılanamadı.");
                        VeriBulunamadı();

                    }
                }
                VeriBulunamadı();
                    
            }
            
        }
          public void KisileriListele(List<Kisi> list) //Rehberdeki kişileri numara-isim-soyisim olarak listeleyen metod
        {
            Console.WriteLine("Telefon Rehberi\n*****************************************************");
            foreach (var item in list)
            {
                Console.WriteLine($"İsim: {item.Isim}");
                Console.WriteLine($"Soyisim: {item.SoyIsim}");
                Console.WriteLine($"Telefon Numarası: {item.TelNo}");
                Console.WriteLine("-----------------------------------------------------");
                
            }
            Console.WriteLine("Rehber burada sonlanmıştır :=)\n*****************************************************");
        } 


        public void KisiArama(List<Kisi> list)
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\n*****************************************************\n");
            Console.Write("İsim veya soyisime göre arama yapmak için: (1)\nTelefon numarasına göre arama yapmak için: (2)");
            //Bu metot, yanlış veri girilmesi sonucunda alınacak hatayı mesajla yansıtıp tekrardan veri girilmesini sağlamak için yazıldı. 
            
            void Proceccor(int islemNo) //Parametre ise yukardaki 1 veya 2yi tutar.
        {
                if(islemNo==1)
            {
                Console.Write("Lütfen aramak istediğiniz ismi veya soyismi yazınız:");
                string input=Console.ReadLine();
                int durum=0;
                foreach (var item in list)
                {
                    if (item.Isim==input || item.SoyIsim==input)
                    {
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine($"İsim: {item.Isim}");
                        Console.WriteLine($"Soyisim: {item.SoyIsim}");
                        Console.WriteLine($"Telefon Numarası: {item.TelNo}");
                        Console.WriteLine("-----------------------------------------------------");
                        durum++;
                    }
                }
                if (durum==0)
                {
                    
                        Console.WriteLine("Aradığınız isim veya soyismi bulamadık.");
                        Console.WriteLine("İşlemi sonlandırmak için: (1)\n Tekrar arama yapmak için: (2)");
                        int yesOrNo=int.Parse(Console.ReadLine()); // Buradaki 1 ve 2, islemNo'daki 1 ve 2den farklıdır.
                        if (yesOrNo==1)
                        {
                            
                        }
                        else if(yesOrNo==2)
                        {
                            KisiArama(list);
                        }
                    
                }
            }else if(islemNo==2)
            {
                int durum2=0;
                Console.Write("Lütfen aramak istediğiniz telefon numarasını yazınız:");
                string numara=Console.ReadLine();
                foreach (var item in list)
                {
                    if (item.TelNo==numara)
                    {
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine($"İsim: {item.Isim}");
                        Console.WriteLine($"Soyisim: {item.SoyIsim}");
                        Console.WriteLine($"Telefon Numarası: {item.TelNo}");
                        Console.WriteLine("-----------------------------------------------------");
                        durum2++;
                    }
                }
                if (durum2==0)
                {
                    
                        Console.WriteLine("Aradığınız numarayı bulamadık.");
                        Console.WriteLine("İşlemi sonlandırmak için: (1)\nTekrar arama yapmak için: (2)");
                        int yesOrNo=int.Parse(Console.ReadLine());
                        if (yesOrNo==1)
                        {
                            
                        }
                        else if(yesOrNo==2)
                        {
                            KisiArama(list);
                        }
                    
                }
            }
        }
            // Girilen veri int'e dönüştürülebilir ve 1 veya 2 olması durumunda işlem gerçekleşecek.
            if (int.TryParse(Console.ReadLine(), out int Checker) && Checker==1 || Checker==2 ) 
            {
                int islemNo= Checker;
                Proceccor(islemNo);
            }else // girilen veri int değilse veya 1-2 dışında bir sayıysa mesaj yansıtıp KisiArama metodunu çalıştırarak tekrardan veri almayı sağlayacak.
            {
                Console.WriteLine("Girdiğiniz veri 1 veya 2 olarak algılanamadı, lütfen tekrar deneyiniz\n");
                KisiArama(list);
            }


        }


}

// Furkan Cengiz tarafından yazılmıştır, okuyup incelediğiniz için müteşekkirim. Geri bildirimlerinize teşneyim, bana Discord'dan ulaşabilirsiniz. Esen kalın 4_4

// Discordum: Furki4_4#9356
