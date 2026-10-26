using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace TarimOtomasyonu
{
    public interface IKontrolEdilebilir
    {
        void DurumRaporuVer();
    }

    public abstract class TarimCihazi : IKontrolEdilebilir
    {
        public string CihazAdi { get; set; }
        public bool CalisiyorMu { get; private set; }

        protected TarimCihazi(string cihazAdi)
        {
            CihazAdi = cihazAdi;
            CalisiyorMu = false;
        }

        public virtual void Calistir()
        {
            CalisiyorMu = true;
            Console.WriteLine($"{CihazAdi} aktif hale getirildi");
        }

        public virtual void Durdur()
        {
            CalisiyorMu = false;
            Console.WriteLine($"{CihazAdi} durduruldu");
        }

        public abstract void DurumRaporuVer();
    }

    public class SulamaSistemi : TarimCihazi
    {
        public int SulamaMiktarıLitresi { get; set; }

        public SulamaSistemi(string cihazAdi, int sulamaMiktarıLitresi) : base(cihazAdi)
        {
            SulamaMiktarıLitresi = sulamaMiktarıLitresi;
        }

        public override void Calistir()
        {
            base.Calistir();
            Console.WriteLine($"Su Vanaları Açıldı Hedef Sulama Miktarı: {SulamaMiktarıLitresi}");
        }

        public override void DurumRaporuVer()
        {
            Console.WriteLine($"{CihazAdi} durumu -> Çalışıyor mu: {CalisiyorMu}, Su Miktarı: {SulamaMiktarıLitresi}L");
        }
    }

    public class HavalandirmaSistemi : TarimCihazi
    {
        public HavalandirmaSistemi(string cihazAdi) : base(cihazAdi)
        {
        }

        public override void DurumRaporuVer()
        {
            Console.WriteLine($"{CihazAdi} durumu -> Çalışıyor mu: {CalisiyorMu}");
        }
    }

    public class Tarla
    {
        private string _tarlaAdi;

        public string TarlaAdi
        {
            get { return _tarlaAdi; }
            set { _tarlaAdi = value.Trim(); }
        }

        public List<TarimCihazi> Cihazlar { get; set; }

        public Tarla(string tarlaAdi)
        {
            TarlaAdi = tarlaAdi;
            Cihazlar = new List<TarimCihazi>();
        }

        public void CihazEkle(TarimCihazi cihaz)
        {
            Cihazlar.Add(cihaz);
            Console.WriteLine($"[BİLGİ] {cihaz.CihazAdi}, {TarlaAdi} tarlasına eklendi.");
        }

        public void RaporAl()
        {
            Console.WriteLine($"\n--- {TarlaAdi} Durum Raporu ---");
            foreach (var cihaz in Cihazlar)
            {
                cihaz.DurumRaporuVer();
            }
        }

        public void OtomasyonuBaslat()
        {
            Console.WriteLine($"\n>>> {TarlaAdi} Otomasyonu Başlatılıyor...");
            foreach (var cihaz in Cihazlar)
            {
                cihaz.Calistir();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Tarla domatesSerasi = new Tarla("Ayaş Domates Serası");
            TarimCihazi damlaSulama = new SulamaSistemi("Aklıı Damla Sulama", 200);
            TarimCihazi iklimlendirme = new HavalandirmaSistemi("Otomatik Çatı Kliması ");

            domatesSerasi.CihazEkle(damlaSulama);
            domatesSerasi.CihazEkle(iklimlendirme);

            domatesSerasi.OtomasyonuBaslat();
            domatesSerasi.RaporAl();

            Console.WriteLine("\nProgram Tamamlandı. Çıkış için bir tuşa basın.");
            Console.ReadKey();
        }
    }
}
