using System;
using System.Windows.Forms;

namespace OgrenciOgretmenSistemi
{
    public partial class Form1 : Form
    {
        // Temel Personel Sınıfı
        public class Personel
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Eposta { get; set; }
        }

        // Öğrenci Sınıfı (Personel sınıfından türetilmiştir)
        public class Ogrenci : Personel
        {
            public string Bolum { get; set; }
            private int notu;

            // Not hesaplama metodu sınıf içine alındı
            public int NotHesapla(int vize)
            {
                this.notu = vize * 10;
                return this.notu;
            }
        }

        // Öğretmen Sınıfı (Personel sınıfından türetilmiştir)
        public class Ogretmen : Personel
        {
            public string Unvan { get; set; }
        }

        // Form Yükleme / Kurucu Metod
        public Form1()
        {
            InitializeComponent();

            // Öğretmen nesnesi oluşturma ve değer atama
            Ogretmen ogretmen = new Ogretmen();
            ogretmen.Ad = "Ahmet";
            ogretmen.Soyad = "Yılmaz";
            ogretmen.Unvan = "Prof. Dr.";

            // Öğrenci nesnesi oluşturma ve değer atama
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.Ad = "Mehmet";
            ogrenci.Soyad = "Demir";
            ogrenci.Bolum = "Yazılım Mühendisliği";
            
            // Öğrenci not hesaplama kullanımı
            int sonuc = ogrenci.NotHesapla(8); // Örn: Vize notu çarpanı
        }
    }
} 



