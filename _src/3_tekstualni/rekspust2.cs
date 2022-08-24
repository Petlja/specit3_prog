using System;

class Program
{
    static int izraz(string s, ref int i, ref bool ok)
    {
        // racunamo vrednost prvog sabirka (ili umanjenika)
        int a = term(s, ref i, ref ok);
        // dok ima jos sabiraka (ili umanjilaca)
        while (ok && i < s.Length && (s[i] == '+' || s[i] == '-'))
        {
            // ako iza sledi sabirak 
            if (s[i] == '+')
            {
                // preskacemo znak +
                i++;
                // citamo i dodajemo vrednost narednog sabirka
                a += term(s, ref i, ref ok);
            }
            // ako iza sledi umanjilac
            else if (s[i] == '-')
            {
                // preskacemo znak -
                i++;
                // citamo i oduzimamo vrednost umanjioca
                a -= term(s, ref i, ref ok);
            }
        }
        return a;
    }
    
    static int term(string s, ref int i, ref bool ok)
    {
        // citamo i racunamo vrednost prvog cinioca (ili deljenika)
        int a = faktor(s, ref i, ref ok);
        // dok ima jos cinilaca (ili delilaca)
        while (ok && i < s.Length && (s[i] == '*' || s[i] == '/'))
        {
            // ako iza sledi cinilac
            if (s[i] == '*')
            {
                // preskacemo znak *
                i++;
                // citamo i mnozimo izraz narednim ciniocem
                a *= faktor(s, ref i, ref ok);
            }
            // ako iza sledi delilac
            else if (s[i] == '/')
            {
                // preskacemo znak /
                i++;
                // citamo i racunamo vrednost delioca
                int b = faktor(s, ref i, ref ok);
                // proveravamo da li je u pitanju deljenje nulom
                if (b == 0)
                    ok = false;
                else
                    a /= b;
            }
        }
        return a;
    }
    
    static int faktor(string s, ref int i, ref bool ok)
    {
        // ako smo procitali prvu cifru
        if (s[i] >= '0' && s[i] <= '9')
            // citamo i odredjujemo vrednost celog broja
            return broj(s, ref i);
        else
        {
            // preskacemo otvorenu zagradu
            i++;
            // citamo i racunamo vrednost izraza u zagradama
            int a = izraz(s, ref i, ref ok);
            // preskacemo zatvorenu zagradu
            i++;
            return a;
        }
    }

    static int broj(string s, ref int i)
    {
        // Hornerovom shemom racunamo vrednost broja
        // citamo cifre dokle god ih ima
        int x = 0;
        while (i < s.Length && s[i] >= '0' && s[i] <= '9')
        {
            x = x * 10 + s[i] - '0';
            i++;
        }
        return x;
    }
    
    static void Main(string[] args)
    {
        string s;
        int i, rez;
        bool ok;
        while ((s = Console.ReadLine()) != null)
        {
            i = 0;
            ok = true;
            rez = izraz(s, ref i, ref ok);
            if (ok)
                Console.WriteLine(rez);
            else
                Console.WriteLine("deljenje nulom");
        }
    }
}
