using System;

class Program
{
    static void ProsireniEuklid(long a0, long b0,
        out long d, out long x, out long y)
    {
        long a = a0, b = b0;
        long xPre = 1, yPre = 0;
        x = 0;
        y = 1;
        // invarijanta pre i posle svakog prolaska kroz petlju:
        // xPre*a0 + yPre*b0 = a
        // x*a0 + y*b0 = b
        while (b > 0)
        {
            long r = a % b;
            // r = 1*a + (-a/b)*b
            //   = 1*(xPre*a0 + yPre*b0) + (-a/b)*(x*a0 + y*b0)
            //   = (xPre - a/b * x)*a0 + (yPre - a/b * y)*b0
            //   = xSled*a0 + ySled*b0
            long xSled = xPre - a / b * x;
            long ySled = yPre - a / b * y;

            xPre = x; yPre = y;
            x = xSled; y = ySled;
            a = b; b = r;
        }
        d = a; x = xPre; y = yPre;
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
