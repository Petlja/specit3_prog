using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Regex reciNaVelikoI = new Regex(@"\bI\w+");
        string tekst = "Imam Ivanov, Majin i tvoj broj, nemam Ilijin.";

        MatchCollection uklapanja = reciNaVelikoI.Matches(tekst);

        Console.WriteLine("Primer upotrebe kolekcije uklapanja (metod Matches)");
        Console.WriteLine("Tekst: '" + tekst + "'");
        Console.WriteLine("Uklapanja:");
        for (int i = 0; i < uklapanja.Count; i++)
            Console.WriteLine("poz {0}: '{1}'", uklapanja[i].Index, uklapanja[i].Value);
    }
}
