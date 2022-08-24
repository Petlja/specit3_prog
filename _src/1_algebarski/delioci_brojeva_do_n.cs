// svi prosti delioci brojeva do n
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
        int n = int.Parse(Console.ReadLine());
        int[] delilac = NajmanjiDelilac(n);

        while (true)
        {
            int a = int.Parse(Console.ReadLine());
            if (a == 0)
                break;

            while (a > 1)
            {
                Console.Write(delilac[a] + " ");
                a = a / delilac[a];
            }
            Console.WriteLine();
        }
    }
}
