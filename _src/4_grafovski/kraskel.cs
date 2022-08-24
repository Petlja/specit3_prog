using System;
using System.Collections.Generic;

using Cvor = System.Int32;
using Duzina = System.Double;
using Grana = System.Tuple<System.Double, System.Int32, System.Int32>;

class Program
{
    static void Main(string[] args)
    {
        // ucitavamo tezinski graf predstavljen listom grana
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        Grana[] grane = new Grana[m];
        for (int i = 0; i < m; i++)
        {
            string[] str = Console.ReadLine().Split();
            int cvor1 = int.Parse(str[0]);
            int cvor2 = int.Parse(str[1]);
            double duzina = double.Parse(str[2]);
            grane[i] = Tuple.Create(duzina, cvor1, cvor2);
        }

        // sortiramo grane u rastucemo redosledu duzina (duzina je
        // prvi element torke)
        Array.Sort(grane);

        // struktura podataka za predstavljanje formiranih grupa za
        // svaki element pamtimo u kojoj se grupi (komponenti) nalazi
        int[] grupa = new int[n];
        for (int i = 0; i < n; i++)
            grupa[i] = i;
        
        // ukupna duzina odabranih grana u trenutnoj sumi
        double ukupnaDuzina = 0.0;
        // broj trenutno dodatih grana
        int dodatoGrana = 0;
        for (int i = 0; i < m && dodatoGrana < n-1; i++)
        {
            int c1 = grane[i].Item2;
            int c2 = grane[i].Item3;
            // ako trenutna grana spaja cvorove u dve razlicite komponente,
            // tada spajamo komponente
            if (grupa[c1] != grupa[c2])
            {
                int g1 = grupa[c1];
                // tada spajamo komponente
                for (int j = 0; j < n; j++)
                    if (grupa[j] == g1)
                        grupa[j] = grupa[c2];
                
                // dodajemo granu u sumu
                ukupnaDuzina += grane[i].Item1;
                dodatoGrana++;
            }
        }
        // ispisujemo konacan rezultat
        Console.WriteLine(ukupnaDuzina.ToString("0.0"));
    }
}
