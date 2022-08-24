// prosti brojevi do n - Eratostenovo sito
using System;

class Program
{
    static bool[] ProstiBrojeviDo(long n)
    {
        bool[] prost = new bool[n + 1];
        for (long i = 0; i <= n; i++)
            prost[i] = true;

        prost[0] = prost[1] = false;
        for (long i = 2; i < Math.Sqrt(n); i++)
        {
            if (prost[i])
            {
                for (long j = i * i; j < n; j += i)
                    prost[j] = false;
            }
        }
        return prost;
    }
    static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        bool[] prost = ProstiBrojeviDo(n);
        for (long i = 2; i < n; i++)
            if (prost[i])
                Console.WriteLine(i);
    }
}
