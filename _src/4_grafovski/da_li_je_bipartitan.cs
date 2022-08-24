using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // ucitavamo neusmeren graf i predstavljamo ga u obliku lista suseda
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        var susedi = new List<int>[n];
        for (int i = 0; i < n; i++)
            susedi[i] = new List<int>();
        
        for (int i = 0; i < m; i++) {
            string[] str = Console.ReadLine().Split();
            int a = int.Parse(str[0]);
            int b = int.Parse(str[1]);
            susedi[a].Add(b);
            susedi[b].Add(a);
        }

        // na pocetku ni jedan cvor nije obojen
        int[] boje = new int[n];
        for (int i = 0; i < n; i++)
            boje[i] = -1;
        // da li se graf moze obojiti sa dve boje (0 i 1)
        bool moze = true;
        // vrsimo bojenje svake komponente povezanosti
        for (int i = 0; i < n && moze; i++) {
            // ako cvor i nije obojen, kreceno bojenje njegove komponente od njega
            if (boje[i] == -1) {
                var stek = new Stack<int>();
                stek.Push(i);
                // pocetni cvor u svakoj komponenti bojimo u boju 0
                int boja = 0;
                boje[i] = boja;
                while (stek.Count > 0) {
                    int x = stek.Pop();
                    // susede cvora x bojimo u suprotnu boju od x
                    boja = 1 - boje[x];
                    foreach (int sused in susedi[x]) {
                        // ako je neki sused vec obojen u boju cvora x,
                        // bojenje sa dve boje nije moguce
                        if (boje[sused] != -1 && boje[sused] != boja) {
                            moze = false;
                            break;
                        }
                        // ako sused nije obojen, bojimo ga u boju suprotnu od x
                        if (boje[sused] == -1) {
                            boje[sused] = boja;
                            stek.Push(sused);
                        }
                    }
                }
            }
        }

        if (moze) {
            // ispisujemo cvorove obojene u boju 0 (u koju je obojen i cvor 0)
            for (int i = 0; i < n; i++)
                if (boje[i] == 0)
                    Console.Write(i + " ");
            Console.WriteLine();
        } else
            Console.WriteLine("-");
    }
}
