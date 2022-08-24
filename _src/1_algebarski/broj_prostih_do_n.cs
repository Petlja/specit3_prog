// broj prostih brojeva u [1, k] za svako k
using System;

class Program
{
    static int[] BrojProstih(long n)
    {
        int[] jeProst = new int[n + 1];
        for (int i = 2; i <= n; i++)
            jeProst[i] = 1;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (jeProst[i] == 1)
            {
                for (int j = i * i; j <= n; j += i)
                    jeProst[j] = 0;
            }
        }
        int[] brProstihDo = jeProst; // isti prostor
        for (int i = 1; i <= n; i++)
            brProstihDo[i] = brProstihDo[i - 1] + jeProst[i];
        return brProstihDo;
    }
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] brProstihDo = BrojProstih(n);

        while (true)
        {
            string[] s = Console.ReadLine().Split();
            int a = int.Parse(s[0]);
            int b = int.Parse(s[1]);
            if (b == 0)
                break;

            if (a > 0)
                Console.WriteLine(brProstihDo[b] - brProstihDo[a - 1]);
            else
                Console.WriteLine(brProstihDo[b]);
        }
    }
}
