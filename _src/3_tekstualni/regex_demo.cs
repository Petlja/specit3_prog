using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void RegexKolekcijaMeceva()
    {
        // izraz '/b' predstavlja granice reci (mesta izmedju karaktera)
        Regex reciNaVelikoI = new Regex(@"\b[I]\w+");
        string tekst = "Imam Ivanov, Majin i tvoj broj, nemam Ilijin.";
        MatchCollection uklapanja = reciNaVelikoI.Matches(tekst);

        Console.WriteLine("Primer upotrebe kolekcije uklapanja (metod Matches)");
        Console.WriteLine("Tekst: " + tekst);
        Console.Write("Uklapanja:");
        for (int i = 0; i < uklapanja.Count; i++)
            Console.Write(" " + uklapanja[i].Value);
        Console.WriteLine();
        Console.WriteLine("----------------------------------");
    }

    static void RegexZamena()
    {
        string tekstSaViskomBelina = "Primer    viska    belina      u tekstu.";
        string tekstBezViskaBelina = Regex.Replace(tekstSaViskomBelina, "\\s+", " ");

        Console.WriteLine("Primer zamene u stringu pomocu regexa (metod Regex.Replace)");
        Console.WriteLine("Tekst pre zamene:" + tekstSaViskomBelina);
        Console.WriteLine("Tekst posle zamene:" + tekstBezViskaBelina);
        Console.WriteLine("----------------------------------");
    }
    static void RegexRazdvajanje()
    {
        string tekst = "Jedan_dva, tri:3, opet.";
        string slova = "[a-zA-Z]+";
        string[] result = Regex.Split(tekst, slova);
        // Isto se dobija ako u regex ukljucima samo mala slova i koristimo opciju IgnoreCase
        //string slova = "[a-z]+";
        //string[] result = Regex.Split(str, a_z, RegexOptions.IgnoreCase);

        Console.WriteLine("Primer razdvanja teksta pomocu regexa (metod Regex.Split)");
        Console.WriteLine("Tekst: '" + tekst + "'");
        Console.Write("Delovi razdvojeni serijama slova:");
        for (int i = 0; i < result.Length; i++)
            Console.Write(" '" + result[i] + "'");
        Console.WriteLine();
        Console.WriteLine("----------------------------------");
    }

    static void RegexProveraUklapanjaReci()
    {
        Regex ime = new Regex(@"[A-Z][a-z]*");
        string[] recenica = "Danas su se Pera i Vera sreli u Novom Sadu.".Split();

        Console.WriteLine("Primer provere uklapanja pojedinacnih reci (metod IsMatch)");
        Console.WriteLine("Tekst: '" + recenica + "'");
        Console.Write("Reci koje izgledaju kao imena:   ");
        foreach (string rec in recenica)
            if (ime.IsMatch(rec))
                Console.Write(" " + rec);
        Console.WriteLine();

        Console.Write("Ostale reci:   ");
        foreach (string rec in recenica)
            if (!ime.IsMatch(rec))
                Console.Write(" " + rec);
        Console.WriteLine();

        Console.WriteLine("Provera poklapanja (bez viska) pomocu Regex.Match(a, b).Success");
        foreach (string rec in recenica)
            if (Regex.Match(rec, "^[A-Z][a-zA-Z]*$").Success)
                Console.WriteLine("{0}: da", rec);
            else
                Console.WriteLine("{0}: ne", rec);
        Console.WriteLine("----------------------------------");
    }
    static void Main(string[] args)
    {
        //Klasa Regex predstavlja neimenljiv regularan izraz.  
        RegexKolekcijaMeceva();
        RegexZamena();
        RegexRazdvajanje();
        RegexProveraUklapanjaReci();
    }
}
