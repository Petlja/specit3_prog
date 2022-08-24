using System;

class Program
{
    enum Zaokret { Nalevo, Kolinearne, Nadesno };
    static Zaokret OrijentacijaTrojke(long xa, long ya, long xb, long yb, long xc, long yc)
    {
        long z = (yc - ya) * (xb - xa) - (yb - ya) * (xc - xa);
        if (z > 0) return Zaokret.Nalevo;
        else if (z < 0) return Zaokret.Nadesno;
        else return Zaokret.Kolinearne;
    }
    static void Main(string[] args)
    {
        Console.Write("Unesite koordinate tacaka: ");
        string[] s = Console.ReadLine().Split();
        long xa = long.Parse(s[0]);
        long ya = long.Parse(s[1]);
        long xb = long.Parse(s[2]);
        long yb = long.Parse(s[3]);
        long xc = long.Parse(s[4]);
        long yc = long.Parse(s[5]);
        Zaokret z = OrijentacijaTrojke(xa, ya, xb, yb, xc, yc);
        if (z == Zaokret.Nadesno)
            Console.WriteLine("Zaokret nadesno");
        else if (z == Zaokret.Nalevo)
            Console.WriteLine("Zaokret nalevo");
        else
            Console.WriteLine("Kolinearna trojka");

    }
}
