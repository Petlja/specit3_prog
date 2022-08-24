using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        
        // ucitavamo zmilje i lestve
        int m = int.Parse(Console.ReadLine());
        var prelaz = new Dictionary<int, int>();
        for (int i = 0; i < m; i++)
        {
            string[] str = Console.ReadLine().Split();
            int a = int.Parse(str[0]);
            int b = int.Parse(str[1]);
            prelaz[a] = b;
        }

        // kreiramo graf
        var graf = new List<int>[n];
        for (int i = 0; i < n; i++)
            graf[i] = new List<int>();
        
        for (int polje = 0; polje < n; polje++) {
            if (prelaz.ContainsKey(polje))
                continue;
            for (int i = 1; i <= k && polje + i < n; i++) {
                // pomeramo se za i polja
                int cilj = polje + i;
                // sa tog polja pratimo lestve i zmije dok je god moguce, vodeci
                // racuna o tome da ne upadnemo u ciklus
                bool ciklus = false;
                while (true) {
                    // pokusavamo da pronadjemo prelaz (preko zmija
                    // ili lestvi) od tekuceg cilja
                    int prelazDo;
                    if (!prelaz.TryGetValue(cilj, out prelazDo))
                        // ako prelaz ne postoji, odredjen je cilj i petlja se prekida
                        break;
                    cilj = prelazDo;
                    if (cilj == polje + i) {
                        ciklus = true;
                        break;
                    }
                }
                // ako smo uspesno stigli na neko krajnje polje, dodajemo prelaz u graf
                if (!ciklus)
                    graf[polje].Add(cilj);
            }
        }

        // broj koraka potreban da se stigne do svakog polja (-1 znaci da je taj
        // broj trenutno nepoznat)
        int[] rastojanje = new int[n];
        Array.Fill(rastojanje, -1);

        // klasicna pretraga u sirinu
        var red = new Queue<int>();
        red.Enqueue(0);
        rastojanje[0] = 0;
        while (red.Count > 0)
        {
            int polje = red.Dequeue();
            foreach (int cilj in graf[polje])
                if (rastojanje[cilj] == -1) {
                    rastojanje[cilj] = rastojanje[polje] + 1;
                    red.Enqueue(cilj);
                    // prvi put kada stignemo do cilja prekidamo pretragu
                    if (polje == n-1)
                        break;
                }
        }
        
        Console.WriteLine(rastojanje[n-1]);
    }
}
