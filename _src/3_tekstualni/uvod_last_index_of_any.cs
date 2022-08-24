using System;

class Program
{
    static void Main(string[] args)
    {
        string tekst = "Na 3 mesta u ovom tekstu se pojavljuju cifre: 2 ovde i 1 na pocetku.";
        char[] trazeni = "0123456789".ToCharArray();
        Console.WriteLine("Tekst: {0}", tekst);
        Console.WriteLine("Poslednja pojavljivanja neke cifre:");

        int p = tekst.LastIndexOfAny(trazeni);
        Console.WriteLine("- Poslednje ukupno: na poziciji {0}.", p);

        p = tekst.LastIndexOfAny(trazeni, 15);
        Console.WriteLine("- Poslednje od poz. 15: na poziciji {0}.", p);

        p = tekst.LastIndexOfAny(trazeni, 15, 5);
        Console.WriteLine("- Poslednje od poz. 15 u narednih 5 karaktera: na poziciji {0}.", p);

        p = tekst.LastIndexOfAny(trazeni, 1);
        Console.WriteLine("- Poslednje od poz. 1: na poziciji {0}.", p);
    }
}
