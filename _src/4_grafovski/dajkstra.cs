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
        const Duzina INF = double.PositiveInfinity;
        // ucitavamo graf - koristimo liste suseda
        int n = int.Parse(Console.ReadLine());
        List<Par>[] susedi = new List<Par>[n];
        for (int i = 0; i < n; i++)
            susedi[i] = new List<Par>();
        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            string[] str = Console.ReadLine().Split();
            Cvor cvorOd = Cvor.Parse(str[0]);
            Cvor cvorDo = Cvor.Parse(str[1]);
            Duzina duzina  = Duzina.Parse(str[2]);
            susedi[cvorOd].Add(Tuple.Create(duzina, cvorDo));
        }
        // ucitavamo startni i ciljni cvor
        int start = int.Parse(Console.ReadLine());
        int cilj = int.Parse(Console.ReadLine());

        // za svaki cvor cuvamo duzinu najkraceg poznatog puta od startnog cvora
        Duzina[] duzinaPuta = Enumerable.Repeat(INF, n).ToArray();
        // zatim da li ta procena predstavlja upravo najkraci moguci put
        bool[] resen = new bool[n];        
        // kao i prethodni cvor na tom trenutno procenjenom najkracem putu
        Cvor[] roditelji = Enumerable.Repeat(-1, n).ToArray();
        // u pocetku jedino znamo rastojanje do startnog cvora
        duzinaPuta[start] = 0.0;
        // dok ne odredimo najkraci put za sve cvorove
        int brojResenih = 0;
        while (brojResenih < n)
        {
            // odredjujemo nereseni cvor koji je trenutno najblizi startnom
            Cvor cvorMin = -1; Duzina minDuzina = INF;
            for (Cvor cvor = 0; cvor < n; cvor++)
                if (!resen[cvor] && duzinaPuta[cvor] < minDuzina)
                {
                    cvorMin = cvor;
                    minDuzina = duzinaPuta[cvor];
                }
            // ako su svi dostizni cvorovi reseni, ciljni cvor nije dostizan
            if (cvorMin == -1)
                break;
    
            // nije moguce da postoji bolji put do cvoraMin - belezimo da je on
            // resen i povecavamo broj resenih cvorova
            resen[cvorMin] = true;
            brojResenih++;
            // ako je za ciljni cvor odredjeno rastojanje, nema potrebe vrsiti
            // dalju pretragu
            if (cvorMin == cilj)
                break;
            // analiziramo susede cvoraMin
            foreach (Par p in susedi[cvorMin])
            {
                Cvor cvor = p.Item2;
                Duzina duzina = p.Item1;
                // ako je potrebno, azuriramo duzine puta do njegovih suseda
                if (!resen[cvor] && minDuzina + duzina < duzinaPuta[cvor])
                {
                    duzinaPuta[cvor] = minDuzina + duzina;
                    roditelji[cvor] = cvorMin;
                }
            }
        }

        // ako put do cilja postoji
        if (duzinaPuta[cilj] < INF)
        {
            // ispisujemo duzinu najkraceg puta
            Console.WriteLine(duzinaPuta[cilj].ToString("0.00000"));
            // pratimo put od cilja do starta, unatrag
            // da bismo obrnuli put, koristimo stek
            var put = new Stack<Cvor>();
            put.Push(cilj);
            while (roditelji[cilj] != -1)
            {
                cilj = roditelji[cilj];
                put.Push(cilj);
            }
            // ispisujemo put od starta do cilja
            while (put.Count > 0)
                Console.Write(put.Pop() + " ");
            Console.WriteLine();
        } else
            // prijavljujemo da put do cilja ne postoji
            Console.WriteLine("ne");
    }
}
