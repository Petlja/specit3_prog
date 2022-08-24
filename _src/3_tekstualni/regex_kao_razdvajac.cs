using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string tekst = "Jedan_dva, tri:4,pet 6.78";
        string slova = "[^\\w]+";

        string[] rezultat = Regex.Split(tekst, slova);

        Console.WriteLine("Primer razdvanja teksta pomocu regexa (metod Regex.Split)");
        Console.WriteLine("Tekst: '" + tekst + "'");
        Console.WriteLine("Delovi razdvojeni serijama nealfanumerickih karaktera:");
        for (int i = 0; i < rezultat.Length; i++)
            Console.WriteLine(rezultat[i]);
    }
}
