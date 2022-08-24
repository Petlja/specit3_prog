// nzd dva broja - euklidov algoritam (prva verzija)
using System;

class Program
{
    static long NZD(long a, long b)
    {
        while (b > 0)
        {
            long d = a % b;
            a = b;
            b = d;
        }
        return a;
    }
    static void Main(string[] args)
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        Console.WriteLine(NZD(a, b));
    }
}
