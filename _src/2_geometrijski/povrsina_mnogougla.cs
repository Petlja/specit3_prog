// povrsina mnogougla
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

    static double PovrsinaFormulaTrapeza(Tacka[] t)
    {
        int n = t.Length;
        double povrsina = (t[0].x - t[n - 1].x) * (t[0].y + t[n - 1].y);
        for (int i = 1; i < n; i++)
            povrsina += (t[i].x - t[i - 1].x) * (t[i].y + t[i - 1].y);

        return 0.5 * Math.Abs(povrsina);
    }
    static double PovrsinaFormulaPertlanja(Tacka[] t)
    {
        int n = t.Length;
        double povrsina = (t[0].x * t[n - 1].y) - (t[0].y * t[n - 1].x);
        for (int i = 1; i < n; i++)
            povrsina += (t[i].x * t[i - 1].y) - (t[i].y * t[i - 1].x);

        return 0.5 * Math.Abs(povrsina);
    }
    static double PovrsinaOptFormula(Tacka[] t)
    {
        int n = t.Length;
        double povrsina = t[0].x * (t[n - 1].y - t[1].y);
        povrsina += t[n - 1].x * (t[n - 2].y - t[0].y);
        for (int i = 1; i < n - 1; i++)
            povrsina += t[i].x * (t[i - 1].y - t[i + 1].y);

        return 0.5 * Math.Abs(povrsina);
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

        Console.WriteLine("Povrsina po formuli trapeza je {0}", PovrsinaFormulaTrapeza(t));
        Console.WriteLine("Povrsina po formuli pertlanja je {0}", PovrsinaFormulaPertlanja(t));
        Console.WriteLine("Povrsina po optimizovanoj formuli pertlanja je {0}", PovrsinaOptFormula(t));
    }
}
