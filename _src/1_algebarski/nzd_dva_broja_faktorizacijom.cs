// nzd dva broja - algoritam uporedne faktorizacije
using System;

class Program
{
    static long NZD(long a, long b)
    {
        long d = 2;
        long nzd = 1;
        while (d * d <= a || d * d <= b)
        {
            bool deljiv_a = (a % d == 0);
            bool deljiv_b = (b % d == 0);
            if (deljiv_a)
                a /= d;
            if (deljiv_b)
                b /= d;
            if (deljiv_a && deljiv_b)
                nzd *= d;
            if (!deljiv_a && !deljiv_b)
                d++;
        }

        if (a == b)
            nzd *= a;

        return nzd;
    }
    static void Main(string[] args)
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        Console.WriteLine(NZD(a, b));
    }
}
