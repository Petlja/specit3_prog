using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Regex VelPocSlovo = new Regex("[A-Z][a-z]+");
        string[] tekstovi = { "Veliko Slovo", "veLiko Slovo", "A", "mala slova" };

        Console.WriteLine("Primer provere uklapanja (metod IsMatch)");
        foreach (string tekst in tekstovi)
            if (VelPocSlovo.IsMatch(tekst))
                Console.WriteLine("'{0}' -> da", tekst);
            else
                Console.WriteLine("'{0}' -> ne", tekst);
    }
}
