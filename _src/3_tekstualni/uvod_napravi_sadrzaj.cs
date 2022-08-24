using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        string[] sadrzaj = {
            "Уводно поглавље",
            "Поглавље са примерима",
            "Поглавље са задацима са вежбу"
        };
        int[] stranice = { 11, 17, 25 };
        for (int i = 0; i < sadrzaj.Length; i++)
        {
            Console.WriteLine("{0} {1}", sadrzaj[i],
                stranice[i].ToString().PadLeft(60 - sadrzaj[i].Length, '.'));
        }
    }
}
