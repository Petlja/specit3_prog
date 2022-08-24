using System;

class Program
{
    static void Main(string[] args)
    {
        ulong a = 1;
        ulong b = 1;
        int iter = 0;
        while (a < (1UL << 63))
        {
            iter++;
            ulong z = a + b;
            b = a;
            a = z;
            Console.WriteLine("a = {0}, b = {1} -> {2} iteracija", a, b, iter);
        }
    }
}
