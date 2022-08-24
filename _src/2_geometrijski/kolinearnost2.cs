using System;

class Program
{
    static bool Kolinearne(long ax, long ay, 
        long bx, long by, long cx, long cy)
    {
        return (by - ay) * (cx - ax) == (cy - ay) * (bx - ax);
    }
    static void Main(string[] args)
    {
        Console.Write("Unesite koordinate tacaka: ");
        string[] s = Console.ReadLine().Split();
        long ax = long.Parse(s[0]);
        long ay = long.Parse(s[1]);
        long bx = long.Parse(s[2]);
        long by = long.Parse(s[3]);
        long cx = long.Parse(s[4]);
        long cy = long.Parse(s[5]);
        Console.WriteLine(Kolinearne(ax, ay, bx, by, cx, cy));
    }
}
