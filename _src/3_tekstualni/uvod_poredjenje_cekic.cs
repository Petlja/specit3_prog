using System;
using System.Globalization;
using System.Threading;

class Program
{
    static void UporediStringove(CompareOptions opt)
    {
        Console.Write(opt.ToString() + ": ");
        string s1 = "čekić", s2 = "Cekic";
        int rez = String.Compare(s1, s2, CultureInfo.InvariantCulture, opt);
        if (rez < 0) Console.WriteLine("{0} je pre {1}", s1, s2);
        else if (rez > 0) Console.WriteLine("{0} je posle {1}", s1, s2);
        else Console.WriteLine("{0} i {1} su ekvivalentni", s1, s2);
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        UporediStringove(CompareOptions.None);
        UporediStringove(CompareOptions.IgnoreNonSpace);
        UporediStringove(CompareOptions.IgnoreCase);
        UporediStringove(CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase);
    }
}
