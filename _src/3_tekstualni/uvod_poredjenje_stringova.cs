using System;
using System.Globalization;
using System.Threading;

class Program
{
    static void OpisiPoredjenje(int rez, string s1, string s2)
    {
        if (rez < 0) Console.WriteLine("{0} je pre {1}", s1, s2);
        else if (rez > 0) Console.WriteLine("{0} je posle {1}", s1, s2);
        else Console.WriteLine("{0} i {1} su ekvivalentni", s1, s2);
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        string s1 = "А", s2 = "Ј";
        int rez1 = String.Compare(s1, s2, StringComparison.Ordinal);
        OpisiPoredjenje(rez1, s1, s2);
        int rez2 = String.Compare(s1, s2, StringComparison.CurrentCulture);
        OpisiPoredjenje(rez2, s1, s2);
    }
}
