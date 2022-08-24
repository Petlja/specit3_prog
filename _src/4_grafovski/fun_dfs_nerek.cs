static void DFS(int polazniCvor, List<List<int>> susedi)
{
    int n = susedi.Count;
    bool[] zakazan = new bool[n];
    var zaPosetu = new Stack<int>();
    zaPosetu.Push(polazniCvor);
    zakazan[polazniCvor] = true;
    while (zaPosetu.Count > 0)
    {
        int tekuciCvor = zaPosetu.Pop();
        Console.WriteLine("Poseta cvoru {0}", tekuciCvor);
        int stepen = susedi[tekuciCvor].Count;
        for (int i = stepen - 1; i >= 0; i--)
        {
            int sused = graf[tekuciCvor][i];
            if (!zakazan[sused])
            {
                zaPosetu.Push(sused);
                zakazan[sused] = true;
            }
        }
    }
}
