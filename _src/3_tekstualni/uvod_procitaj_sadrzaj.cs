using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        string[] linije = {
            "Уводно поглавље ...........................................11",
            "Поглавље са примерима .....................................17",
            "Поглавље са задацима са вежбу .............................25"
        };
        int n = linije.Length;
        string[] naslovi = new string[n];
        int[] stranice = new int[n];
        for (int i = 0; i < n; i++)
        {
            int p = linije[i].LastIndexOf(' ');
            naslovi[i] = linije[i].Substring(0, p);
            stranice[i] = int.Parse(linije[i].Substring(p + 1).TrimStart('.'));
        }
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0} има {1} страница.",
                naslovi[i], stranice[i + 1] - stranice[i]);
        }
    }
}
