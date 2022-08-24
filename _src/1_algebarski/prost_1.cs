// test primalnosti - prva verzija
using System;

class Program
{
    static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());

        bool prost;
        if (n == 1) prost = false;     // broj 1 nije prost
        else
        {
            prost = true;
            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    prost = false;
        }
        Console.WriteLine(prost ? "DA" : "NE");
    }
}
