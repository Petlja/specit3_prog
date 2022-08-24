using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Unesite koeficijente a, b, c jednacine ax+by+c=0: ");
        string[] s = Console.ReadLine().Split();
        double a = double.Parse(s[0]);
        double b = double.Parse(s[1]);
        double c = double.Parse(s[2]);
        Console.Write("Unesite koordinate tacke x, y: ");
        s = Console.ReadLine().Split();
        double x = double.Parse(s[0]);
        double y = double.Parse(s[1]);
        if (a * x + b * y + c == 0)
            Console.WriteLine("Tacka pripada pravoj");
        else
            Console.WriteLine("Tacka ne pripada pravoj");
    }
}
