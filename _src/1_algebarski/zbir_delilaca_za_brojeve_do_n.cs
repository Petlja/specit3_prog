// Brzo racunanje zbira delilaca za brojeve do n
using System;

class Program
{
    static int[] NajmanjiDelilac(long n)
    {
        int[] delilac = new int[n + 1];
        for (int i = 0; i <= n; i++)
            delilac[i] = i;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (delilac[i] == i)
            {
                for (int j = i * i; j <= n; j += i)
                    if (delilac[j] == j)
                        delilac[j] = i;
            }
        }

        return delilac;
    }
    static void Main(string[] args)
    {
        Console.Write("Unesite granicu n ");
        int n = int.Parse(Console.ReadLine());
        int[] delilac = NajmanjiDelilac(n);

        while (true)
        {
            Console.Write("x = ");
            int x0 = int.Parse(Console.ReadLine());
            if (x0 == 0)
                break;
            long x = x0;
            // zbir delilaca od x=(p[1]^a[1] * ... * p[k]^a[k])
            // je jednak proizvodu svih (p[i]^(a[i] + 1) - 1) / (p[i] - 1)
            long zbirDel = 1;
            while (x > 1)
            {
                int p = delilac[x];
                int p_na_ai = p;
                while (delilac[x] == p)
                {
                    p_na_ai *= p;
                    x = x / p;
                }
                zbirDel *= (p_na_ai - 1) / (p - 1);
            }
            Console.WriteLine("Zbir delilaca broja {0} je {1}.", x0, zbirDel);
        }
    }
}
