// test primalnosti - druga verzija
using System;

class Program
{
    static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        long kn = (long)Math.Ceiling(Math.Sqrt(n));
        bool prost;
        if (n == 1) prost = false;
        else if (n == 2) prost = true;
        else
        {
            prost = true;
            for (long i = 2; i <= kn; i++)
                if (n % i == 0)
                {
                    prost = false;
                    break;
                }
        }

        Console.WriteLine(prost ? "DA" : "NE");
    }
}
