using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // broj predmeta (cvorova grafa)
        int n = int.Parse(Console.ReadLine());

        // ulazni stepeni svih cvorova
        int[] stepen = new int[n];

        // za svaki predmet gradimo listu predmeta koji od njega zavise
        var zavisni = new List<int>[n];
        for (int i = 0; i < n; i++)
            zavisni[i] = new List<int>();

        // ucitavamo sve parove koji odredjuju zavisnosti izmedju dva predmeta
        // (grane grafa)
        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            // predmet x zavisi od predmeta y
            string[] str = Console.ReadLine().Split();
            int x = int.Parse(str[0]);
            int y = int.Parse(str[1]);
            stepen[x]++;
            zavisni[y].Add(x);
        }

        // odredjujemo sve cvorove koji inicijalno imaju stepen 0 (oni se mogu polagati)
        var cvoroviStepena0 = new Queue<int>();
        for (int cvor = 0; cvor < n; cvor++)
            if (stepen[cvor] == 0)
                cvoroviStepena0.Enqueue(cvor);

        // dok god ima predmeta koji se mogu polagati
        while (cvoroviStepena0.Count > 0)
        {
            // polazemo naredni predmet 
            int cvor = cvoroviStepena0.Dequeue();
            Console.WriteLine(cvor);
            // smanjujemo stepene svim predmetima koji od njega zavise
            // ako se nekom stepen spusti na 0, tada i on moze da se polaze
            foreach (int z in zavisni[cvor])
                if (--stepen[z] == 0)
                    cvoroviStepena0.Enqueue(z);
        }
    }
}
