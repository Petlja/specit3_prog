// konveksnost, pripadnost mnogouglu
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
    static int Zaokret(Tacka P, Tacka Q, Tacka R)
    {
        double vp = (R.y - P.y) * (Q.x - P.x) - (Q.y - P.y) * (R.x - P.x);
        if (vp > 0) return 1;
        else if (vp < 0) return -1;
        else return 0;
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

        int z = Zaokret(t[n - 2], t[n - 1], t[0]);
        bool konveksan = (z == Zaokret(t[n - 1], t[0], t[1]));
        for (int i = 1; (i < n - 1) && konveksan; i++)
        {
            if (z != Zaokret(t[i - 1], t[i], t[i + 1]))
                konveksan = false;
        }

        if (konveksan)
        {
            Console.WriteLine("Mnogougao je konveksan");
            Console.Write("Unesite koordinate tacke M: ");
            Tacka m = UcitajTacku();
            z = Zaokret(t[n - 1], t[0], t[1]);
            bool pripada = (z == Zaokret(t[n - 1], t[0], m));
            pripada = pripada && (z == Zaokret(t[n - 2], t[n - 1], m));
            for (int i = 1; (i < n - 1) && pripada; i++)
            {
                if (z != Zaokret(t[i - 1], t[i], m))
                    pripada = false;
            }
            if (pripada)
                Console.WriteLine("Tacka M pripada mnogouglu");
            else
                Console.WriteLine("Tacka M ne pripada mnogouglu");
        }
        else
            Console.WriteLine("Mnogougao nije konveksan");
    }
}
