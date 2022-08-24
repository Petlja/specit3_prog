using System;
using System.Text.RegularExpressions;

class Program
{
    static string HehUDec(Match m) // konvertuje heksadekadni zapis u dekadni
    {
        int n = Convert.ToInt32(m.Value, 16);
        return n.ToString();
    }

    static string DecUHex(Match m) // konvertuje dekadni zapis u heksadekadni
    {
        int n = Convert.ToInt32(m.Value);
        return "0x" + n.ToString("X");
    }

    static void Main()
    {
        string s1 = "ASCII kodovi karaktera 'a' i 'A' su redom 0x41 i 0x61";
        string s2 = Regex.Replace(s1, @"0x(\d|[a-f]|[A-F])+", HehUDec);
        string s3 = Regex.Replace(s2, @"\d+", DecUHex);
        Console.WriteLine("s1 = '{0}'", s1);
        Console.WriteLine("s2 = '{0}'", s2);
        Console.WriteLine("s3 = '{0}'", s3);
    }
}
