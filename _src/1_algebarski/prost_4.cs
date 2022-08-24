// test primalnosti - cetvrta verzija
using System;

class Program
{
    static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        bool prost;
        if (n == 1) prost = false;
        else if (n == 2) prost = true;
        else if (n % 2 == 0) prost = false;
        else if (n == 3) prost = true;
        else if (n % 3 == 0) prost = false;
        else
        {
            prost = true;
            long kn = (long)Math.Ceiling(Math.Sqrt(n));
            long di = 4;
            for (long i = 5; i <= kn; i += di)
            {
                if (n % i == 0)
                {
                    prost = false;
                    break;
                }
                di = 6 - di;
            }
        }
        Console.WriteLine(prost ? "DA" : "NE");
    }
}
