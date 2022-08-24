using System;

class Program
{

    // Indukcijom po broju cvorova izracunavamo duzine najkracih
    // puteva izmedju svaka dva cvora u grafu
    static int[,] SviNajkraciPutevi(int[,] D, int n)
    {
        int[,] minD = new int[n, n];

        // dodajemo jedan po jedan cvor
        for (int i = 0; i < n; i++)
        {
            minD[i, i] = 0;

            // odredjujemo najkrace puteve od cvora i do svih prethodnih
            // cvorova j
            for (int j = 0; j < i; j++)
            {
                // pretpostavljamo da je direktno rastojanje najkrace
                minD[i, j] = D[i, j];
                // proveravamo da li je mozda bolji put od i do j koji
                // vodi preko nekog prethodnog cvora k
                for (int k = 0; k < i; k++)
                    if (D[i, k] + minD[k, j] < minD[i, j])
                        minD[i, j] = D[i, k] + minD[k, j];
            }

            // odredjujemo najkrace puteve do cvora i od svih prethodnih
            // cvorova j
            for (int j = 0; j < i; j++)
            {
                // pretpostavljamo da je direktno rastojanje najkrace
                minD[j, i] = D[j, i];
                // proveravamo da li je mozda bolji put od cvora j do i koji
                // vodi preko nekog prethodnog cvora k
                for (int k = 0; k < i; k++)
                    if (minD[j, k] + D[k, i] < minD[j, i])
                        minD[j, i] = minD[j, k] + D[k, i];
            }

            // popravljamo rastojanja od prethodnih cvorova j do prethodnih
            // cvorova k, analizirajuci puteve koji vode preko cvora i
            for (int j = 0; j < i; j++)
                for (int k = 0; k < i; k++)
                    if (minD[j, i] + minD[i, k] < minD[j, k])
                        minD[j, k] = minD[j, i] + minD[i, k];
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

        // racunamo sve najkrace puteve
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
