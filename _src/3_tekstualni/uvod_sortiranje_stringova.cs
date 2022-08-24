using System;
using System.Globalization;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        string[] a = new string[] {
            "ш", "џ", "ч", "ц", "х", "ф", "у", "ћ", "т", "с", "р", "п", "о", "њ", "н",
            "м", "љ", "л", "к", "ј", "и", "з", "ж", "е", "ђ", "д", "г", "в", "б", "а",
            "Ш", "Џ", "Ч", "Ц", "Х", "Ф", "У", "Ћ", "Т", "С", "Р", "П", "О", "Њ", "Н",
            "М", "Љ", "Л", "К", "Ј", "И", "З", "Ж", "Е", "Ђ", "Д", "Г", "В", "Б", "А"
        };
        Console.WriteLine("Nesortirano:");
        foreach (string s in a)
            Console.Write(s);
        Console.WriteLine();

        Console.WriteLine("Sortirano koristeci tekucu kulturu:");
        Array.Sort(a, StringComparer.CurrentCulture);
        foreach (string s in a)
            Console.Write(s);
        Console.WriteLine();

        Console.WriteLine("Sortirano po kodovima karaktera:");
        Array.Sort(a, StringComparer.Ordinal);
        foreach (string s in a)
            Console.Write(s);
        Console.WriteLine();
    }
}
