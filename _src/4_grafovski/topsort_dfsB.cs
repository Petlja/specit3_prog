using System;
using System.Collections.Generic;

class Program
{
    static void DFS(int cvor, bool[] posecen, List<int> redosled,
                    List<int>[] susedi)
    {
        // preskacemo sve ranije posecene cvorove
        if (posecen[cvor])
            return;
        posecen[cvor] = true;
        // pre tekuceg cvora moramo obraditi sve poslove od kojih on zavisi
        foreach (int sused in susedi[cvor])
            DFS(sused, posecen, redosled, susedi);
        // sada mozemo obraditi i tekuci posao
        redosled.Add(cvor);
    }

    // topolosko sortiranje
    static List<int> TopoloskiSort(List<int>[] susedi)
    {
        int n = susedi.Length;
        // pokrecemo pretragu u dubinu iz svakog cvora
        bool[] posecen = new bool[n];
        var redosled = new List<int>();
        for (int cvor = 0; cvor < n; cvor++)
            DFS(cvor, posecen, redosled, susedi);
        return redosled;
    }
    
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var susedi = new List<int>[n];
        for (int i = 0; i < n; i++)
            susedi[i] = new List<int>();
        
        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            string[] str = Console.ReadLine().Split();
            int x = int.Parse(str[0]);
            int y = int.Parse(str[1]);
            susedi[x].Add(y);
        }

        var redosled = TopoloskiSort(susedi);
        foreach (int x in redosled)
            Console.WriteLine(x);
    }
}
