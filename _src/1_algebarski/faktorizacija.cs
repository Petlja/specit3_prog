// faktorizacija broja
using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        Stopwatch sw = new Stopwatch();
        sw.Start();
        long kn = (long)Math.Ceiling(Math.Sqrt(n));
        long i = 2;
        while (i <= kn)
        {
            if (n % i == 0)
            {
                Console.WriteLine(i);
                n = n / i;
                kn = (long)Math.Ceiling(Math.Sqrt(n));
            }
            else
            {
                i++;
            }
        }
        if (n > 1)
            Console.WriteLine(n);
        sw.Stop();
        Console.WriteLine("Vreme: {0}", sw.ElapsedMilliseconds * 0.001);
    }
}
