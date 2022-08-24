static string Zameni(string tekst, string trazi, string zamNepar, string zamPar)
{
    // odredjujemo duzinu rezultujuceg stringa
    int duzina = tekst.Length;
    int promenaNepar = zamNepar.Length - trazi.Length;
    int promenaPar = zamPar.Length - trazi.Length;
    bool par = false;
    int p1 = 0;
    while (p1 >= 0)
    {
        int p2 = tekst.IndexOf("-", p1);
        if (p2 < 0)
            break;
        p1 = p2 + trazi.Length;
        duzina += (par ? promenaPar : promenaNepar);
        par = !par;
    }

    // vrsimo zamene, prepisujuci rezultat u niz a
    char[] a = new char[duzina];
    par = false;
    p1 = 0;
    int k = 0;
    while (p1 >= 0)
    {
        int p2 = tekst.IndexOf("-", p1);
        if (p2 < 0)
            break;

        for (int i = p1; i < p2; i++)
            a[k++] = tekst[i];
        foreach (char c in (par ? zamPar : zamNepar))
            a[k++] = c;
        p1 = p2 + trazi.Length;
        par = !par;
    }
    for (int i = p1; i < tekst.Length; i++)
        a[k++] = tekst[i];
    return new string(a);
}
