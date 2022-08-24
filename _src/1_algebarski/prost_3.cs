// test primalnosti - treca verzija
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
        else
        {
            prost = true;
            long kn = (long)Math.Ceiling(Math.Sqrt(n));
            for (long i = 3; i <= kn; i += 2)
                if (n % i == 0)
                {
                    prost = false;
                    break;
                }
        }

        Console.WriteLine(prost ? "DA" : "NE");
    }
}
