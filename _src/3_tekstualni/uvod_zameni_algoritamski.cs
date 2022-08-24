using System;

class Program
{
    static void Main(string[] args)
    {
        string s = "neki-dugacak-tekst-sa-mnogo-crtica";
        char[] a = s.ToCharArray();
        int n = a.Length;
        int brPoj = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] == '-')
            {
                brPoj++;
                if (brPoj % 2 == 1) a[i] = '_';
                else a[i] = '+';
            }
        }
        s = new string(a);
        Console.WriteLine(s);
    }
}
