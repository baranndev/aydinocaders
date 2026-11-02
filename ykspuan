using System;
namespace ConsoleApp2
{
    public class Ögrenci
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int puan { get; set; }

        public Ögrenci(string name, string lastName, int puan)
        {
            Name = name;
            LastName = lastName;
            this.puan = puan; // this kullanarak sınıftaki değişkene atama yapıldı
        }

        public bool BursDurumu()
        {
            return puan > 500;
        }
    }

    public class BursOrani
    {
        public double bursOraniHesapla(Ögrenci ogrenci)
        {
            if (ogrenci.puan > 500 && ogrenci.puan < 550)
            {
                return 0.50;
            }
            else if (ogrenci.puan > 550)
            {
                return 0.75;
            }

            return 0; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sisteme Hoşgeldiniz");
            Console.Write("Adınız :");
            string ad = Console.ReadLine();
            Console.Write("Soyadınız:");
            string soyad = Console.ReadLine();
            Console.Write("YKS PUANI: ");
            int puan = Convert.ToInt32(Console.ReadLine());

            Ögrenci yeniÖğrenci = new Ögrenci(ad, soyad, puan);

            if (!yeniÖğrenci.BursDurumu())
            {
                Console.WriteLine("Hata Burs İçin Puanınız Yeterli Değil");
            }

            BursOrani ogrBurs = new BursOrani();
            double burs = ogrBurs.bursOraniHesapla(yeniÖğrenci);

            if (burs > 0)
            {
                Console.WriteLine($"Tebrikler: %{(burs * 100)} burs kazandınız.");
            }
        }
    }
}
