using System;
using System.Collections.Generic;

class Program
{
    static int Vrednost(string izraz)
    {
        var vrednosti = new Stack<int>();
        var operatori = new Stack<char>();
        foreach (char c in izraz)
            if (Char.IsDigit(c))
            {
                vrednosti.Push(c - '0');
            }
            else if (c == ')')
            {
                char op = operatori.Pop();
                int op2 = vrednosti.Pop();
                int op1 = vrednosti.Pop();
                if (op == '+')
                    vrednosti.Push(op1 + op2);
                else if (op == '*')
                    vrednosti.Push(op1 * op2);
            }
            else if (c == '+' || c == '*')
            {
                operatori.Push(c);
            }
        return vrednosti.Pop();
    }

    static void Main(string[] args)
    {
        string izraz = Console.ReadLine();
        Console.WriteLine(Vrednost(izraz));
    }
}

