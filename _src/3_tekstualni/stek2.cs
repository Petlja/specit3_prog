using System;
using System.Collections.Generic;

class Program
{
    // provera da li je karakter aritmeticki operator
    static bool jeOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }

    // prioritet datog operatora
    static int prioritet(char c)
    {
        if (c == '+' || c == '-')
            return 1;
        else if (c == '*' || c == '/')
            return 2;
        // greska
        return 0;
    }

    // primenjuje datu operaciju na dve vrednosti na vrhu steka, 
    // zamenjujuci ih sa rezultatom primene te operacije
    // vracamo informaciju o tome da li operator uspesno primenjen ili je
    // doslo do deljenja nulom
    static bool primeni(Stack<char> operatori, Stack<int> vrednosti)
    {
        // operator se nalazi na vrhu steka operatora
        char op = operatori.Pop();
        // operandi se nalaze na vrhu steka operatora
        int op2 = vrednosti.Pop();
        int op1 = vrednosti.Pop();

        // izracunavamo vrednost izraza
        int v = 0;
        if (op == '+') v = op1 + op2;
        else if (op == '-') v = op1 - op2;
        else if (op == '*') v = op1 * op2;
        else if (op == '/') {
            // deljenje nulom
            if (op2 == 0)
                return false;
            v = op1 / op2;
        }
        // postavljamo ga na stek operatora
        vrednosti.Push(v);
        // operator je uspesno primenjen
        return true;
    }


    // izracunavamo vrednost izraza
    // vracamo informaciju o tome da li je vrednost uspesno izracunata ili
    // je doslo do deljenja nulom
    static bool vrednost(string izraz, out int v)
    {
        v = 0;
        var vrednosti = new Stack<int>();
        var operatori = new Stack<char>();

        // analiziramo sve karaktere u ulaznom izrazu
        int i = 0;
        while (i < izraz.Length) {
            if (Char.IsDigit(izraz[i]))
            {
                // brojevne konstante postavljamo na stek
                v = izraz[i] - '0';
                i++;
                while (i < izraz.Length && Char.IsDigit(izraz[i]))
                    v = 10 * v + (izraz[i++] - '0');
                vrednosti.Push(v);
            }
            else if (izraz[i] == '(')
            {
                // otvorene zagrade postavljamo na stek
                operatori.Push('(');
                i++;
            }
            else if (izraz[i] == ')')
            {
                // izracunavamo vrednost izraza u zagradi
                while (operatori.Peek() != '(')
                    if (!primeni(operatori, vrednosti))
                        return false;
                // uklanjamo otvorenu zagradu
                operatori.Pop();
                i++;
            } else if (jeOperator(izraz[i])) {
                // obradjujemo sve prethodne operatore viseg prioriteta
                while (operatori.Count > 0 && jeOperator(operatori.Peek()) &&
                       prioritet(operatori.Peek()) >= prioritet(izraz[i]))
                    if (!primeni(operatori, vrednosti))
                        return false;
                // stavljamo operator na stek
                operatori.Push(izraz[i]);
                i++;
            }
        }

        // izracunavamo sve preostale operacije
        while (operatori.Count > 0)
            if (!primeni(operatori, vrednosti))
                return false;

        // vrednost izraza se nalazi na vrhu steka
        v = vrednosti.Pop();
        return true;
    }
    
    static void Main(string[] args)
    {
        string s;
        while ((s = Console.ReadLine()) != null)
        {
            // pokusavamo da izracunamo vrednost izraza 
            int rez;
            if (vrednost(s, out rez))
                Console.WriteLine(rez);
            else
                Console.WriteLine("deljenje nulom");
        }
    }
    
}
