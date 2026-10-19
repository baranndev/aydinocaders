
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double kareKenar = Convert.ToDouble(textBox1.Text);
            double yaricap = Convert.ToDouble(textBox2.Text);
            double en = Convert.ToDouble(textBox3.Text);
            double boy = Convert.ToDouble(textBox4.Text);


            kare kutu = new kare(kareKenar);
            daire dunya = new daire(yaricap);
            dikdortgen masa = new dikdortgen(en, boy);

            richTextBox1.Text = "Bu Kutunun alanı = " + kutu.AlanHesapla().ToString() + "\n";
            richTextBox1.Text += "Dünyamızın alanı = " + dunya.AlanHesapla().ToString() + "\n";
            richTextBox1.Text += "Bu dikdörtgen masanın alanı = " + masa.AlanHesapla().ToString();

            kutu.sekilCiz();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Pen kalem = new Pen(Color.Black, 2);
            Brush fircaKare = Brushes.LightBlue;
            Brush fircaDikdortgen = Brushes.LightGreen;
            Brush fircaDaire = Brushes.LightPink;

            // Çok biçimlilik sayesinde tür ayrımı yapmadan her şekli çizdiriyoruz
            foreach (var sekil in sekiller)
            {
                Brush aktifFirca = sekil is Kare ? fircaKare :
                                   (sekil is Dikdortgen ? fircaDikdortgen : fircaDaire);

                // Polimorfik çizim çağrısı
                sekil.Ciz(g, kalem, aktifFirca);

                // Şeklin altına alan bilgisini yazdırma
                double alan = sekil.AlanHesapla();
                int yOfset = sekil is Daire ? ((Daire)sekil).Yaricap * 2 + 10 :
                             (sekil is Kare ? ((Kare)sekil).Kenar + 10 : ((Dikdortgen)sekil).Yukseklik + 10);

                g.DrawString($"Alan: {alan:F1}", this.Font, Brushes.DarkSlateGray, sekil.X, sekil.Y + yOfset);
            }
        }
    }
}
