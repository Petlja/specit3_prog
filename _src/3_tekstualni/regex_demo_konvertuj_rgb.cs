using System;
using System.Text.RegularExpressions;

class Program
{
    static string KonvertujBoju(Match m)
    {
        Regex decBroj = new Regex(@"\d+");
        MatchCollection brojevi = decBroj.Matches(m.Value);
        return string.Format("#{0:X2}{1:X2}{2:X2}",
            int.Parse(brojevi[0].Value),
            int.Parse(brojevi[1].Value),
            int.Parse(brojevi[2].Value));
    }

    static void Main()
    {
        string s1 = Console.ReadLine();
        string rgbString = @"rgb\s*\(\d+,\s*\d+,\s*\d+\s*\)";
        string s2 = Regex.Replace(s1, rgbString, KonvertujBoju);
        Console.WriteLine(s2);
    }
}
