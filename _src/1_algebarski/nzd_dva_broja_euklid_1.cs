// nzd dva broja - euklidov algoritam (optimizovana verzija)
using System;

class Program
{
    static long NZD(long a, long b)
    {
        while (a > 0 && b > 0)
        {
            if (a >= b)
                a -= b;
            else
                b -= a;
        }
        if (a == 0)
            return b;
        else
            return a;
    }
    static void Main(string[] args)
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        Console.WriteLine(NZD(a, b));
    }
}
