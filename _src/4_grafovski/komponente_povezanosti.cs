using System;
using System.Collections.Generic;

class Program
{
    // obilazak grafa u dubinu koji je zadat listama povezanosti
    // obilazi se komponenta k krenuvsi od njenog cvora cvor
    // niz komponente sadrzi brojeve komponenata posecenih cvorova i vrednosti
    // 0 za sve neposecene cvorove
    static void DFS(List<int>[] A, int cvor, int[] komponente, int k)
    {
        komponente[cvor] = k;
        foreach (int sused in A[cvor])
            if (komponente[sused] == 0)
                DFS(A, sused, komponente, k);
    }

    static void Main(string[] args)
    {
        // ucitavamo broj cvorova i grana
        string[] str = Console.ReadLine().Split();
        int v = int.Parse(str[0]);
        int e = int.Parse(str[1]);

        // gradimo prazne liste suseda
        var A = new List<int>[v];
        for (int i = 0; i < v; i++)
            A[i] = new List<int>();

        // ucitavamo grane neusmerenog grafa
        for (int i = 0; i < e; i++) {
            str = Console.ReadLine().Split();
            int a = int.Parse(str[0]);
            int b = int.Parse(str[1]);
            A[a].Add(b);
            A[b].Add(a);
        }

        // svakom cvoru dodeljujemo njegovu komponentu povezanosti
        // (broj od 1 nadalje)
        // vrednost 0 oznacava da cvor nije posecen
        int[] komponente = new int[v];
        // broj do sada pronadjenih komponenata
        int k = 0;
        for (int i = 0; i < v; i++)
            // neposecen cvor zapocinje novu komponentu koju obilazimo
            if (komponente[i] == 0)
                DFS(A, i, komponente, ++k);
        
        // ispisujemo komponente svih cvorova
        for (int i = 0; i < v; i++)
            Console.Write(komponente[i] + " ");
        Console.WriteLine();
    }
}
