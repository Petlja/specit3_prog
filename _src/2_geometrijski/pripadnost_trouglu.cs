// pripadnost trouglu
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
    static double Rastojanje(Tacka P, Tacka Q)
    {
        double dx = P.x - Q.x;
        double dy = P.y - Q.y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
    static double PTrougla(double a, double b, double c)
    {
        double s = (a + b + c) * 0.5;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        // broj operacija: (5 4 0 1)
    }
    static bool UTrouglu1(Tacka A, Tacka B, Tacka C, Tacka M)
    {
        double AB = Rastojanje(A, B); // (3 2 0 1) * 6 = (18 12 0 6)
        double AC = Rastojanje(A, C);
        double BC = Rastojanje(B, C);
        double AM = Rastojanje(A, M);
        double BM = Rastojanje(B, M);
        double CM = Rastojanje(C, M);
        double Pabc = PTrougla(AB, AC, BC); // (5 4 0 1) * 4 = (20 16 0 4)
        double Pabm = PTrougla(AB, AM, BM);
        double Pbcm = PTrougla(BC, BM, CM);
        double Pcam = PTrougla(AC, AM, CM);
        return Math.Abs(Pabm + Pbcm + Pcam - Pabc) < 1e-6; // (3 0 1 0)
        // broj operacija: (18 12 0 6) + (20 16 0 4) + (3 0 1 0) = (41 28 1 10)
    }
    static double PTrougla(Tacka A, Tacka B, Tacka C)
    {
        return 0.5 * Math.Abs(A.x * (B.y - C.y) + B.x * (C.y - A.y) + C.x * (A.y - B.y));
        // broj operacija: (5 4 1 0)
    }
    static bool UTrouglu2(Tacka A, Tacka B, Tacka C, Tacka M)
    {
        double Pabc = PTrougla(A, B, C); // (5 4 1 0) * 4 = (20 16 4 0)
        double Pabm = PTrougla(A, B, M);
        double Pbcm = PTrougla(B, C, M);
        double Pcam = PTrougla(A, C, M);
        return Math.Abs(Pabm + Pbcm + Pcam - Pabc) < 1e-6; // (3 0 1 0)
        // broj operacija: (20 16 0 4) + (3 0 1 0) = (23 16 1 4)
    }
    static bool UTrouglu3(Tacka A, Tacka B, Tacka C, Tacka M)
    {
        // AM = a AB + b AD
        // M.x - A.x = a*(B.x-A.x) + b*(C.x-A.x)
        // M.y - A.y = a*(B.y-A.y) + b*(C.y-A.y)
        // a = (b1 a22 - b2 a12) / (a11 a22 - a21 a12),
        // b = (b2 a11 - b1 a21) / (a11 a22 - a21 a12)
        double a = ((M.x - A.x) * (C.y - A.y) - (M.y - A.y) * (C.x - A.x)) /
            ((B.x - A.x) * (C.y - A.y) - (B.y - A.y) * (C.x - A.x));
        double b = ((M.y - A.y) * (B.x - A.x) - (M.x - A.x) * (B.y - A.y)) /
            ((B.x - A.x) * (C.y - A.y) - (B.y - A.y) * (C.x - A.x));
        return a > 0 && b > 0 && a + b < 1;
        // broj operacija: (20 8 0 0)
    }

    static int Zaokret(Tacka A, Tacka B, Tacka C)
    {
        double z = (C.y - A.y) * (B.x - A.x) - (B.y - A.y) * (C.x - A.x);
        if (z > 0) return 1;
        else if (z < 0) return -1;
        else return 0;
        // broj operacija: (5 2 0 0)
    }
    static bool UTrouglu4(Tacka A, Tacka B, Tacka C, Tacka M)
    {
        double Zabc = Zaokret(A, B, C);
        double Zabm = Zaokret(A, B, M);
        double Zbcm = Zaokret(B, C, M);
        double Zcam = Zaokret(C, A, M);
        return (Zabc != 0) && (Zabc == Zabm) && (Zabc == Zbcm) && (Zabc == Zcam);
        // broj operacija: 4*(5 2 0 0) = (20 8 0 0)
    }

    static void Main(string[] args)
    {
        Tacka A = UcitajTacku();
        Tacka B = UcitajTacku();
        Tacka C = UcitajTacku();
        Tacka M = UcitajTacku();
        Console.WriteLine(UTrouglu1(A, B, C, M)); // (41 28 1 10)
        Console.WriteLine(UTrouglu2(A, B, C, M)); // (23 16 1  4)
        Console.WriteLine(UTrouglu3(A, B, C, M)); // (20  8 0  0)
        Console.WriteLine(UTrouglu4(A, B, C, M)); // (20  8 0  0)
    }
}
