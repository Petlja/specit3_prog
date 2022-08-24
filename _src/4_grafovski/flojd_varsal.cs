using System;

class Program
{

    // Flojd-Varsalovim algoritmom izracunavamo duzine najkracih
    // puteva izmedju svaka dva cvora u grafu
    static int[,] SviNajkraciPutevi(int[,] D, int n)
    {
        int[,] minD = (int[,])D.Clone();
        for (int k = 0; k < n; k++) {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (minD[i, k] + minD[k, j] < minD[i, j])
                        minD[i, j] = minD[i, k] + minD[k, j];
        }
        return minD;
    }
    

    static void Main(string[] args)
    {
        // ucitavamo duzine direktnih puteva 
        int n = int.Parse(Console.ReadLine());
        int[,] D = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            string[] str = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
                D[i, j] = int.Parse(str[j]);
        }

        // racunamo duzine svih najkracih puteva
        int[,] minD = SviNajkraciPutevi(D, n);

        // ispisujemo rezultat
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write((D[i, j] - minD[i, j]) +  " ");
            Console.WriteLine();
        }
    }
}
