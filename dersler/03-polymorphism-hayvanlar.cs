using System.Windows.Forms;

namespace WinFormsApp4
{
    public class Hayvan
    {
        public string Ad { get; set; }

        public virtual string SesCikar()
        {
            return "Hayvan bir ses çıkardı";
        }
    }

    public class Kopek : Hayvan
    {
        public override string SesCikar()
        {
            return "havladı: Hav Hav";
        }
    }

    public class Kedi : Hayvan
    {
        public override string SesCikar()
        {
            return "miyavladı: Miyav";
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Hayvan benimKopegim = new Kopek { Ad = "Karabaş" };
            Hayvan benimKedim = new Kedi { Ad = "Tekir" };

            richTextBox1.Text = benimKopegim.Ad + " " + benimKopegim.SesCikar() + "\r\n";
            richTextBox1.Text += benimKedim.Ad + " " + benimKedim.SesCikar();
        }
    }
}