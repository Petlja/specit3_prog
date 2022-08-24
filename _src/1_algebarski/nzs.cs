using System;

class Program
{
    static long NZS(long a, long b)
    {
        long a1 = a, b1 = b;
        while (b1 > 0)
        {
            long t = a1 % b1;
            a1 = b1;
            b1 = t;
        }
        long nzd = a1;
        long nzs = a * (b / nzd);
        return nzs;
    }
    static void Main(string[] args)
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        Console.WriteLine(NZS(a, b));
    }
}