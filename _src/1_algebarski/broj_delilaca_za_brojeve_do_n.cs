// Brzo racunanje broja delilaca za brojeve do n
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
            // broj delilaca od x=(p[1]^a[1] * ... * p[k]^a[k])
            // je (a[1] + 1) * ... * (a[k] + 1)
            long brDel = 1;
            while (x > 1)
            {
                int p = delilac[x];
                int a = 1;
                while (delilac[x] == p)
                {
                    a++;
                    x = x / delilac[x];
                }
                brDel *= a;
            }
            Console.WriteLine("Broj {0} ima {1} delilaca.", x0, brDel);
        }
    }
}
