// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Generic;
void TaslakYazıcı()
{
Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) \n*****************************************************");
Console.WriteLine("(1) Yeni Numara Kaydetmek");
Console.WriteLine("(2) Varolan Numarayı Silmek");
Console.WriteLine("(3) Varolan Numarayı Güncelleme");
Console.WriteLine("(4) Rehberi Listelemek");
Console.WriteLine("(5) Rehberde Arama Yapmak");
Console.WriteLine("(6) Konsolu Kapatmak");
}
TaslakYazıcı();

int islem =0;
try
{
     islem = int.Parse(Console.ReadLine());
}
catch (System.FormatException)
{
    Console.WriteLine("Lütfen 1-5 arası bir rakam girdiğinizden emin olunuz.");
    
}
if(islem<1 || islem>6)
{
    Console.WriteLine("Lütfen 1-5 arası bir rakam girdiğinizden emin olunuz.");

}
KisiYonetimi Secenekler = new KisiYonetimi();

List<Kisi> Rehber= new List<Kisi>(); //5 kişi atandı.
           Rehber.Add(new Kisi("Furkan","Cengiz","5071707878"));
           Rehber.Add(new Kisi("Semiha","Kansız","5354441454"));
           Rehber.Add(new Kisi("Umut","Tavşan","5132313113"));
           Rehber.Add(new Kisi("Esat","Cengiz","0555553681"));
           Rehber.Add(new Kisi("Aybüke", "Akçelik","5052604416"));
int KonsolKapatıcı=0;           
while(KonsolKapatıcı!=6)
{
switch (islem)
{
    case 1:
    Secenekler.KisiYarat(Rehber);
    break;
    case 2:
    Secenekler.KisiSil(Rehber);
    break;
    case 3:
    Secenekler.KisiGuncelle(Rehber);
    break;
    case 4:
    Secenekler.KisileriListele(Rehber);
    break;
    case 5:
    Secenekler.KisiArama(Rehber);
    break;   
    case 6:
    KonsolKapatıcı=6; 
    Console.WriteLine("Console'dan başarılı bir şekilde çıkış yapıldı, yine bekleriz :=)"); 
    break; 
}
if(KonsolKapatıcı!=6)
{
TaslakYazıcı();
islem= int.Parse(Console.ReadLine());
}

}


class Kisi{
    public Kisi(string isimGirdisi, string soyIsimGirdisi, string numara)
    {
        isim=isimGirdisi;
        soyIsim=soyIsimGirdisi;
        telNo= numara;
    }
    string isim;
    string soyIsim;
    string telNo;  
    public string Isim 
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

class KisiYonetimi
{
    public void KisiYarat(List<Kisi> rehber)
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
        public void KisiSil(List<Kisi> list)
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string input =Console.ReadLine();
            foreach (var item in list)
            {
                if(item.Isim ==input || item.SoyIsim== input)
                {
                   Console.Write($" {item.Isim} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n):");
                   string cevap=Console.ReadLine();
                   if(cevap=="y")
                   {
                       list.Remove(item);
                       break;
                   }else if(cevap=="n")
                   {
                    break;
                   }
                }
                else
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için      : (2)");
                    int cevap =int.Parse(Console.ReadLine());
                    if(cevap==1)
                    {
                        Console.WriteLine("Silme işlemi sonlandırıldı.");
                        break;
                    }else if(cevap==2)
                    {
                        KisiSil(list);
                    }
                }
            }

        }
        public void KisiGuncelle(List<Kisi> list)
        {
            Console.Write("Lütfen güncellemek istediğiniz numarayı giriniz:");
            string numara= Console.ReadLine();
            Console.Write("Lütfen yeni ismi giriniz:");
            string yeniIsim=Console.ReadLine();
            Console.Write("Lütfen yeni soyismi giriniz:");
            string yeniSoyIsim=Console.ReadLine();
            int durum=0;
            foreach (var item in list)
            {
                if (item.TelNo==numara)
                {
                    item.Isim=yeniIsim;
                    item.SoyIsim=yeniSoyIsim;
                    Console.WriteLine("Girdiğiniz numaranın bilgileri başarıyla güncellendi.\n");
                    durum++;
                    break;
                }
            }
            if(durum==0)
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
            int islemNo=int.Parse(Console.ReadLine());
            
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
                        int yesOrNo=int.Parse(Console.ReadLine());
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
                        Console.WriteLine("İşlemi sonlandırmak için: (1)\n Tekrar arama yapmak için: (2)");
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


}
