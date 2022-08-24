using System;
using System.Text;

class Program
{
    static string Zameni(string tekst, string trazi, string zamNepar, string zamPar)
    {
        StringBuilder sb = new StringBuilder();
        bool par = false;
        int p1 = 0;
        while (p1 >= 0)
        {
            int p2 = tekst.IndexOf(trazi, p1);
            if (p2 < 0)
                break;

            sb.Append(tekst.Substring(p1, p2 - p1));
            sb.Append(par ? zamPar : zamNepar);
            p1 = p2 + trazi.Length;
            par = !par;
        }
        sb.Append(tekst.Substring(p1));
        return sb.ToString();
    }
    static void Main(string[] args)
    {
        string s = "neki-dugacak-tekst-sa-mnogo-crtica";
        string rez = Zameni(s, "-", "--", "+");
        Console.WriteLine(rez);
    }
}
