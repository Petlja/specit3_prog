using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string tekstSaViskomBelina = "Primer    viska    belina      u tekstu.";

        string tekstBezViskaBelina = Regex.Replace(tekstSaViskomBelina, "\\s+", " ");

        Console.WriteLine("Primer zamene u stringu pomocu regexa (metod Regex.Replace)");
        Console.WriteLine("Tekst pre zamene: '" + tekstSaViskomBelina + "'");
        Console.WriteLine("Tekst posle zamene: '" + tekstBezViskaBelina + "'");
    }
}
