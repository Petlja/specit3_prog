using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    struct Tunel
    {
        public int dvoranaDo;
        public int razlikaVisina;
        public Tunel(int dvoranaDo, int razlikaVisina)
        {
            this.dvoranaDo = dvoranaDo;
            this.razlikaVisina = razlikaVisina;
        }
    }

    static void visineDFS(int dvorana, int visina,
                          List<Tunel>[] tuneli,
                          bool[] posecena,
                          int[] visine)
    {
        posecena[dvorana] = true;
        visine[dvorana] = visina;
        foreach (Tunel h in tuneli[dvorana])
           if (!posecena[dvoranaDo])
               visineDFS(h.dvoranaDo, visina + h.razlikaVisina,
                      tuneli, posecena, visine);
    }

    static int minVisinaDFS(int dvorana, int visina, List<Tunel>[] tuneli)
    {
        int n = tuneli.Length;
        bool[] posecena = new bool[n];
        int[] visine = new int[n];
        visineDFS(dvorana, visina, tuneli, posecena, visine);
        return visine.Min();
    }
    
    static void Main(string[] args)
    {
        int visinaTla = int.Parse(Console.ReadLine());

        int n = int.Parse(Console.ReadLine());
        var tuneli = new List<Tunel>[n];
        for (int i = 0; i < n; i++)
            tuneli[i] = new List<Tunel>();

        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            int dvoranaOd, dvoranaDo, razlikaVisina;
            string[] str = Console.ReadLine().Split();
            dvoranaOd = int.Parse(str[0]);
            dvoranaDo = int.Parse(str[1]);
            razlikaVisina = int.Parse(str[2]);
            tuneli[dvoranaOd].Add(new Tunel(dvoranaDo, razlikaVisina));
            tuneli[dvoranaDo].Add(new Tunel(dvoranaOd, -razlikaVisina));
        }

        Console.WriteLine(minVisinaDFS(0, visinaTla, tuneli));
    }
}
