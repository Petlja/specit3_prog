using System;
using System.Collections.Generic;
using System.Linq;

using Cvor = System.Int32;
using Duzina = System.Double;
using Par = System.Tuple<System.Double, System.Int32>;

class Program
{
    static void Main(string[] args)
    {
        // ucitavamo neusmeren tezinski graf i predstavljamo ga listama suseda
        int n = int.Parse(Console.ReadLine());
        List<Par>[] susedi = new List<Par>[n];
        for (int i = 0; i < n; i++)
            susedi[i] = new List<Par>();
        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            string[] str = Console.ReadLine().Split();
            int cvor1 = int.Parse(str[0]);
            int cvor2 = int.Parse(str[1]);
            double duzina = double.Parse(str[2]);
            susedi[cvor1].Add(Tuple.Create(duzina, cvor2));
            susedi[cvor2].Add(Tuple.Create(duzina, cvor1));
        }

        // ukupna duzina grana u trenutnom stablu
        double ukupnaDuzina = 0.0;
        const double INF = double.PositiveInfinity;
        // najmanje rastojanje svakog cvora od trenutnog stabla
        Duzina[] rastojanje = Enumerable.Repeat(INF, n).ToArray();
        // da li je cvor ukljucen u trenutno stablo
        bool[] ukljucen = new bool[n];
        // krecemo od praznog stabla - postavljamo rastojanje do cvora 0 na 0.0
        // da bi taj cvor prvi bio ukljucen u stablo
        rastojanje[0] = 0.0;
  
        // broj cvorova u stablu
        int cvorovaUStablu = 0;
        // sve dok ne dodamo n cvorova u stablo
        while (cvorovaUStablu < n)
        {
            // pronalazimo cvor koji je najblizi trenutnom stablu
            Cvor cvorMin = 0;
            Duzina minRastojanje = INF; // rastojanje najblizeg cvora od stabla
            for (Cvor cvor = 0; cvor < n; cvor++)
                if (!ukljucen[cvor] && rastojanje[cvor] < minRastojanje)
                {
                    cvorMin = cvor;
                    minRastojanje = rastojanje[cvor];
                }
            // ukljucujemo cvorMin u stablo
            ukljucen[cvorMin] = true;
            cvorovaUStablu++;
            // uracunavamo duzinu najkrace grane koja ga spaja sa trenutnim
            // stablom
            ukupnaDuzina += minRastojanje;
            // njegovo rastojanje do stabla je sada 0
            rastojanje[cvorMin] = 0.0;
            // razmatramo sve susede  cvoraMin
            foreach (Par p in susedi[cvorMin])
                // azuriramo njihovo rastojanje od trenutnog stabla, ako je to
                // potrebno
                if (p.Item1 < rastojanje[p.Item2])
                    rastojanje[p.Item2] = p.Item1;
        }
        // ispisujemo konacan rezultat
        Console.WriteLine(ukupnaDuzina.ToString("0.0"));
    }
}
