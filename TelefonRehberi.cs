// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Generic;

Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) \n********************************************");
Console.WriteLine("(1) Yeni Numara Kaydetmek");
Console.WriteLine("(2) Varolan Numarayı Silmek");
Console.WriteLine("(3) Varolan Numarayı Güncelleme");
Console.WriteLine("(4) Rehberi Listelemek");
Console.WriteLine("(5) Rehberde Arama Yapmak");
int islem =0;
try
{
     islem = int.Parse(Console.ReadLine());
}
catch (System.FormatException)
{
    Console.WriteLine("Lütfen 1-5 arası bir rakam girdiğinizden emin olunuz.");
    
}
if(islem<1 || islem>5)
{
    Console.WriteLine("Lütfen 1-5 arası bir rakam girdiğinizden emin olunuz.");

}
KisiYonetimi Secenekler = new KisiYonetimi();

List<Kisi> Rehber= new List<Kisi>();
           Rehber.Add(new Kisi("Furkan","Cengiz","5071707878"));
           Rehber.Add(new Kisi("Semiha","Kansız","5354441454"));
           Rehber.Add(new Kisi("Umut","Tavşan","5132313113"));
           Rehber.Add(new Kisi("Esat","Cengiz","0555553681"));
           Rehber.Add(new Kisi("Aybüke", "Akçelik","5052604416"));
switch (islem)
{
    case 1:
    Secenekler.KisiYarat(Rehber);
    break;
    
    
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
        Console.WriteLine("Lütfen isim giriniz              :");
        string isim=Console.ReadLine();
        Console.WriteLine("Lütfen soyisim giriniz           :");
        string soyisim= Console.ReadLine();
        Console.WriteLine("Lütfen telefon numarası giriniz  :");
        string numara=Console.ReadLine();
        Kisi yeniInsan = new Kisi(isim,soyisim,numara);
        rehber.Add(yeniInsan);


    }
        void KisiSil(List<Kisi> list)
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
        void KisiGuncelle(List<Kisi> list)
        {
            Console.WriteLine("Lütfen güncellemek istediğiniz numarayı giriniz:");
            string numara= Console.ReadLine();
            Console.WriteLine("Lütfen yeni ismi giriniz:");
            string yeniIsim=Console.ReadLine();
            Console.WriteLine("Lütfen yeni soyismi giriniz:");
            string yeniSoyIsim=Console.ReadLine();
            foreach (var item in list)
            {
                if (item.TelNo==numara)
                {
                    item.Isim=yeniIsim;
                    item.SoyIsim=yeniSoyIsim;
                    Console.WriteLine("Girdiğiniz numaranın bilgileri başarıyla güncellendi.");
                    break;
                }else
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız:");
                    Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)\n* Yeniden denemek için              : (2)");
                    int islemNo=int.Parse(Console.ReadLine());
                    if (islemNo==1)
                    {
                        break;
                    }else if(islemNo==2)
                    {
                        KisiGuncelle(list);
                    }
                }
            }
            
                


        }
          void KisileriListele(List<Kisi> list) //Rehberdeki kişileri numara-isim-soyisim olarak listeleyen metod
        {
            Console.WriteLine("Telefon Rehberi\n**********************************************");
            foreach (var item in list)
            {
                Console.WriteLine($"İsim: {item.Isim}");
                Console.WriteLine($"Soyisim: {item.SoyIsim}");
                Console.WriteLine($"Telefon Numarası: {item.TelNo}");
                Console.WriteLine("-----------------------------------------------------");
                
            }
        } 


}
