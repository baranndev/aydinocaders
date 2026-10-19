using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace WinFormsApp7
{
    public abstract class sekilSinifi
    {
        public abstract double AlanHesapla();
        public abstract  int sekilCiz();
    }
    public class kare : sekilSinifi
    {
        public double kenar { get; set; }
        public kare(double x)
        {
            kenar = x;
        }
        public override double AlanHesapla()
        {
            double alan = kenar * kenar;
            return alan;
        }
        public override int sekilCiz()
        {
            base.OnPaint(e);

            Graphics x =e.Graphics;
            Pen kalem = new Pen(Color.Red, 3);
            x.DrawRectangle(kalem, 50, 50, 5, 5);
            return 0;
        }   
    }

    public class dikdortgen : sekilSinifi
    {
        public double en { get; set; }
        public double boy { get; set; }
        public dikdortgen(double x, double y)
        {
            en = x;
            boy = y;
        }
        public override double AlanHesapla()
        {
            double alan = en * boy;
            return alan;
        }
    }

    public class daire : sekilSinifi
    {
        public double yaricap { get; set; }
        public daire(double x)
        {
            yaricap = x;
        }
        public override double AlanHesapla()
        {
            double alan = 3 * yaricap * yaricap;
            return alan;
        }
    }
}
