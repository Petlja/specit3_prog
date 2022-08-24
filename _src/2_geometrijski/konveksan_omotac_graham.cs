using System;
using System.Collections.Generic;

class Program
{
    class Tacka { public long x; public long y; }
    static Tacka UcitajTacku()
    {
        string[] s = Console.ReadLine().Split();
        return new Tacka()
        {
            x = long.Parse(s[0]),
            y = long.Parse(s[1])
        };
    }
    static Tacka[] UcitajMnogougao()
    {
        Console.Write("Unesite broj temena: ");
        int n = int.Parse(Console.ReadLine());
        Tacka[] t = new Tacka[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Unesite koordinate jednog temena: ");
            t[i] = UcitajTacku();
        }
        return t;
    }
    static int Zaokret(long xa, long ya, long xb, long yb, long xc, long yc)
    {
        long z = (yc - ya) * (xb - xa) - (yb - ya) * (xc - xa);
        if (z > 0) return 1;
        else if (z < 0) return -1;
        else return 0;
    }
    static void Main(string[] args)
    {
        Tacka[] q = UcitajMnogougao();
        int n = q.Length;
        
        // odredi najnizu tacku
        int iMin = 0;
        for (int i = 1; i < n; i++)
            if (q[i].y < q[iMin].y || (q[i].y == q[iMin].y && q[i].x < q[iMin].x))
                iMin = i;
        Tacka p0 = new Tacka() { x = q[iMin].x, y = q[iMin].y };
        
        // prebaci ostale tacke u listu koja ce biti sortirana
        List<Tacka> p = new List<Tacka>();
        for (int i = 1; i < n; i++)
            if (i != iMin)
                p.Add(new Tacka() { x = q[i].x, y = q[i].y });

        p.Sort(delegate (Tacka a, Tacka b) {
            int z = Zaokret(p0.x, p0.y, a.x, a.y, b.x, b.y);
            if (z != 0) return -z;
            // p0, a, b su kolinearne 
            if (a.x < b.x || a.y < b.y) return -1; // |ap0| < |bp0|
            if (a.x > b.x || a.y > b.y) return 1;  // |ap0| > |bp0|           
            return 0; // a i b su ista tacka
        });

        // Ne koristimo Stack<Tacka> jer nam treba pristup pretposlednjoj tacki
        List<Tacka> stek = new List<Tacka>();
        stek.Add(p0);
        stek.Add(p[0]);
        stek.Add(p[1]);
        for (int i = 2; i < n - 1; i++)
        {
            while (Zaokret(
                    stek[stek.Count - 2].x, stek[stek.Count - 2].y,
                    stek[stek.Count - 1].x, stek[stek.Count - 1].y,
                    p[i].x, p[i].y) <= 0)
                stek.RemoveAt(stek.Count - 1);
            stek.Add(p[i]);
        }

        Console.WriteLine();
        Console.WriteLine("Konveksan omotac je:");
        foreach (Tacka t in stek)
            Console.WriteLine("({0}, {1})", t.x, t.y);
    }
}
