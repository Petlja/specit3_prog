using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        
        // ucitavamo zmije i lestve
        int m = int.Parse(Console.ReadLine());
        var prelaz = new Dictionary<int, int>();
        for (int i = 0; i < m; i++)
        {
            string[] str = Console.ReadLine().Split();
            int a = int.Parse(str[0]);
            int b = int.Parse(str[1]);
            prelaz[a] = b;
        }

        // broj koraka potreban da se stigne do svakog polja (-1 znaci da je taj
        // broj trenutno nepoznat)
        int[] rastojanje = new int[n];
        Array.Fill(rastojanje, -1);

        // pretraga u sirinu
        var red = new Queue<int>();
        red.Enqueue(0);
        rastojanje[0] = 0;
        while (red.Count > 0)
        {
            int polje = red.Dequeue();
            for (int i = 1; i <= k && polje + i < n; i++)
            {
                // pomeramo se za i polja
                int cilj = polje + i;
                // sa tog polja pratimo lestve i zmije dok je god moguce, vodeci
                // racuna o tome da ne upadnemo u ciklus
                bool ciklus = false;
                while (true) {
                    int prelazDo;
                    if (!prelaz.TryGetValue(cilj, out prelazDo))
                        break;
                    cilj = prelazDo;
                    if (cilj == polje + i) {
                        ciklus = true;
                        break;
                    }
                }
                // ako smo uspesno stigli na neposeceno polje, dodajemo ga u red
                if (!ciklus && rastojanje[cilj] == -1) {
                    rastojanje[cilj] = rastojanje[polje] + 1;
                    red.Enqueue(cilj);
                    // prvi put kada stignemo do cilja prekidamo pretragu
                    if (polje == n-1)
                        break;
                }
            }
        }

        Console.WriteLine(rastojanje[n-1]);
    }
}
