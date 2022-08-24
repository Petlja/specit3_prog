// pripadnost paralelogramu
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
    static bool UParalelogramu(Tacka A, Tacka B, Tacka D, Tacka M)
    {
        // AM = a AB + b AD
        // M.x - A.x = a*(B.x-A.x) + b*(D.x-A.x)
        // M.y - A.y = a*(B.y-A.y) + b*(D.y-A.y)
        // a = (b1 a22 - b2 a12) / (a11 a22 - a21 a12),
        // b = (b2 a11 - b1 a21) / (a11 a22 - a21 a12)
        double a = ((M.x - A.x) * (D.y - A.y) - (M.y - A.y) * (D.x - A.x)) /
            ((B.x - A.x) * (D.y - A.y) - (B.y - A.y) * (D.x - A.x));
        double b = ((M.y - A.y) * (B.x - A.x) - (M.x - A.x) * (B.y - A.y)) /
            ((B.x - A.x) * (D.y - A.y) - (B.y - A.y) * (D.x - A.x));
        return a > 0 && b > 0 && a < 1 && b < 1;
        // broj operacija: (20 8 0 0)
    }

    static void Main(string[] args)
    {
        Tacka A = UcitajTacku();
        Tacka B = UcitajTacku();
        Tacka D = UcitajTacku();
        Tacka M = UcitajTacku();
        Console.WriteLine(UParalelogramu(A, B, D, M)); // (20  8 0  0)
    }
}
