static void BFS(int polazniCvor, List<List<int>> susedi)
{
    int n = susedi.Count;
    bool[] zakazan = new bool[n];
    var zaPosetu = new Queue<int>();
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
}
