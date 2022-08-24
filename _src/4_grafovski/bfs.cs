using System;
using System.Collections.Generic;

class Program
{
    static List<List<int>> UcitajGraf()
    {
        Console.Write("Broj cvorova: ");
        int n = int.Parse(Console.ReadLine());
        var susedi = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            susedi.Add(new List<int>());
            Console.Write("Susedi cvora {0}: ", i);
            string[] s = Console.ReadLine().Split();
            int stepen = s.Length;
            for (int j = 0; j < stepen; j++)
                susedi[i].Add(int.Parse(s[j]));
        }
        return susedi;
    }

    static void BFS(int polazniCvor, List<List<int>> susedi)
    {
        int n = susedi.Count;
        bool[] zakazan = new bool[n];
        
        Queue<int> zaPosetu = new Queue<int>();
        zaPosetu.Enqueue(polazniCvor);
        zakazan[polazniCvor] = true;
        while (zaPosetu.Count > 0)
        {
            int tekuciCvor = zaPosetu.Dequeue();
            Console.WriteLine("Poseta cvoru {0}", tekuciCvor);
            foreach (int sused in susedi[tekuciCvor])
                if (!zakazan[sused])
                {
                    zaPosetu.Enqueue(sused);
                    zakazan[sused] = true;
                }
        }
    }

    static void Main(string[] args)
    {
        List<List<int>> susedi = UcitajGraf();
        Console.WriteLine("Polazni cvor:");
        int polazniCvor = int.Parse(Console.ReadLine());
        BFS(susedi, polazniCvor);
    }
}
