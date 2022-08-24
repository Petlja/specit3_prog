// obim
using System;

class Program
{
    class Tacka { public double x; public double y; }
    static Tacka UcitajTacku()
    {
        string[] s = Console.ReadLine().Split();
        return new Tacka()
        {
            x = double.Parse(s[0]),
            y = double.Parse(s[1])
        };
    }

    static double Rastojanje(Tacka A, Tacka B)
    {
        double dx = A.x - B.x, dy = A.y - B.y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
    static void Main(string[] args)
    {
        Console.Write("Unesite broj temena: ");
        int n = int.Parse(Console.ReadLine());
        Tacka[] t = new Tacka[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Unesite koordinate jednog temena: ");
            t[i] = UcitajTacku();
        }

        double obim = Rastojanje(t[0], t[n - 1]);
        for (int i = 1; i < n; i++)
            obim += Rastojanje(t[i], t[i - 1]);

        Console.WriteLine("Obim je {0}", obim);
    }
}
