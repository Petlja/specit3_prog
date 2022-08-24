using System;

class Program
{
    static int Vrednost(string izraz, ref int i)
    {
        if (Char.IsDigit(izraz[i]))
            return izraz[i++] - '0';
        else
        {
            // preskacemo otvorenu zagradu
            i++;
            // izracunavamo vrednost prvog operanda
            int op1 = Vrednost(izraz, ref i);
            // pamtimo operator
            char op = izraz[i++];
            // prevodimo drugi operand
            int op2 = Vrednost(izraz, ref i);
            // preskacemo zatvorenu zagradu
            i++;
            // racunamo konacnu vrednost u zavisnosti od operatora
            if (op == '+')
                return op1 + op2;
            if (op == '*')
                return op1 * op2;
            return 0;
        }
    }

    static int Vrednost(string izraz)
    {
        int i = 0;
        return Vrednost(izraz, ref i);
    }
    
    static void Main(string[] args)
    {
        string izraz = Console.ReadLine();
        Console.WriteLine(Vrednost(izraz));
    }
}

