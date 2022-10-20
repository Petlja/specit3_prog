static void DFS(int cvor, List<List<int>> susedi, bool[] posecen)
{
    Console.WriteLine("Poseta cvoru {0}", cvor);
    posecen[cvor] = true;
    foreach (int sused in susedi[cvor])
        if (!posecen[sused])
            DFS(sused, graf, posecen);
}

static void DFS(int cvor, List<List<int>> susedi)
{
    int n = susedi.Count;
    bool[] posecen = new bool[n];
    return DFS(cvor, susedi, posecen);
}
