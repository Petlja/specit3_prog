using System;

class Program
{
    static void ProsireniEuklid(long a, long b,
        out long d, out long x, out long y)
    {
        if (b == 0)
        {
            d = a;
            x = 1;
            y = 0;
            return;
        }
        long k = a / b;
        long x1, y1;
        ProsireniEuklid(b, a % b, out d, out x1, out y1);
        // x1*b + y1*(a-kb) = d
        // y1*a + x1*b - y1*kb = d
        x = y1;
        y = x1 - y1 * k;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Unesi redom koeficijente a, b, c jednacine ax+by=c");
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());
        long d = 0, x = 0, y = 0;
        ProsireniEuklid(a, b, out d, out x, out y);
        Console.WriteLine("nzd({0}, {1}) = {2} = {3}*{0} + {4}*{1}", a, b, d, x, y);

        if (c % d == 0)
        {
            long k = c / d;
            Console.WriteLine("{0} = {1}*{2} + {3}*{4}", c, k * x, a, k * y, b);
        }
        else
            Console.WriteLine("Zadatak {0} x + {1} y = {2} nema resenja.", a, b, c);
    }
}
