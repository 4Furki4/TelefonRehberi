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
switch (islem)
{
    case 1:
    KisiYarat();

break;
    
    
}

void KisiYarat()
{
Console.WriteLine("Lütfen isim giriniz              :");
string isim=Console.ReadLine();
Console.WriteLine("Lütfen soyisim giriniz           :");

Console.WriteLine("Lütfen telefon numarası giriniz  :");

string soyisim=Console.ReadLine();
string numara=Console.ReadLine();

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
