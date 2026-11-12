
namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public class arac
        {
            public string Marka { get; set; }
            public string Model { get; set; }

            public string Calis()
            {
                return Model;
            }
        }

        public class araba : arac
        {
            public int kapiSayisi { get; set; }

            public string bilgiYazdir()
            {
                // kapiSayisi değişkenini dinamik olarak kullanıyoruz
                return $" Bu araba {kapiSayisi} kapılıdır";
            }
        }

        public Form1()
        {
            InitializeComponent();

            araba benimArabam = new araba();
            benimArabam.Model = "Corolla";
            benimArabam.Marka = "Toyota";
            benimArabam.kapiSayisi = 5;
            araclıstesı.Text = benimArabam.Calis() + " " + benimArabam.bilgiYazdir();
        }
    }
}