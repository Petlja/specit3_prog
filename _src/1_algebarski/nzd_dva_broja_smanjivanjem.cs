// nzd dva broja - algoritam smanjivanja za po 1
using System;

class Program
{
    static long NZD(long a, long b)
    {
        long d = Math.Min(a, b);
        while (a % d > 0 || b % d > 0)
            d--;

        return d;
    }
    static void Main(string[] args)
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        Console.WriteLine(NZD(a, b));
    }
}
