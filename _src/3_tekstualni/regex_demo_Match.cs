using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string[] tekstovi = { "Veliko Slovo", "veLiko Slovo", "A", "mala slova" };

        Console.WriteLine("Nalazenje prvog poklapanja pomocu Regex.Match");
        foreach (string rec in tekstovi)
        {
            Match m = Regex.Match(rec, "[A-Z][a-z]+");
            if (m.Success)
                Console.WriteLine("'{0}' -> '{1}'", rec, m.Value);
            else
                Console.WriteLine("'{0}' -> nema", rec);
        }
    }
}
