using System;
using System.Collections.Generic;

class Program
{
    static List<List<int>> UcitajGraf()
    {
        Console.Write("Broj cvorova: ");
        int n = int.Parse(Console.ReadLine());
        List<List<int>> graf = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            graf.Add(new List<int>());
            Console.Write("Susedi cvora {0}: ", i);
            string[] s = Console.ReadLine().Split();
            int stepen = s.Length;
            for (int j = 0; j < stepen; j++)
                graf[i].Add(int.Parse(s[j]));
        }
        return graf;
    }

    static void DFS(int cvor, List<List<int>> graf, bool[] posecen)
    {
        Console.WriteLine("Poseta cvoru {0}", cvor);
        posecen[cvor] = true;
        int stepen = graf[cvor].Count;
        for (int i = 0; i < stepen; i++)
            if (!posecen[graf[cvor][i]])
                DFS(graf[cvor][i], graf, posecen);
    }
    static void Main(string[] args)
    {
        List<List<int>> graf = UcitajGraf();
        int n = graf.Count;
        bool[] posecen = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (!posecen[i])
                DFS(i, graf, posecen);
        }
    }
}
