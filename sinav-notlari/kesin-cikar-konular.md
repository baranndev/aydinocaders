using System;

public class Ornek
{
    public void metot1()
    {
        Console.WriteLine("Birinci proses çalıştı");
    }

    public void metot2()
    {
        Console.WriteLine("İkinci proses çalıştı");
    }

    public void metot2(int x)
    {
        Console.WriteLine(x);
        metot2(); // Parametresiz metot2'yi çağırır
    }
}

class program
{
    public static void Main()
    {
        Ornek obj = new Ornek(); // 'Örnek' yerine 'Ornek' olarak düzeltildi
        obj.metot1();
        obj.metot2(10);
    }
}
