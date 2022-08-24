using System;

enum Token
{
    PROMENLJIVA, KONSTANTA,
    PLUS, MINUS, PUTA, PODELJENO,
    OTVORENA_ZAGRADA, ZATVORENA_ZAGRADA,
    ID,
    KRAJ,
};

class IzrazLekser
{
    public IzrazLekser(string s)
    {
        this._s = s;
        this._i = 0;
    }

    public Token SledeciToken()
    {
        // preskacemo beline
        while (_i < _s.Length && Char.IsWhiteSpace(_s[_i]))
            _i++;

        if (_i >= _s.Length)
            return Token.KRAJ;
               
        if (_s[_i] == '(')
        {
            _i++;
            return Token.OTVORENA_ZAGRADA;
        }
        if (_s[_i] == ')')
        {
            _i++;
            return Token.ZATVORENA_ZAGRADA;
        }
        if (_s[_i] == '+')
        {
            _i++;
            return Token.PLUS;
        }
        if (_s[_i] == '-')
        {
            _i++;
            return Token.MINUS;
        }
        if (_s[_i] == '*')
        {
            _i++;
            return Token.PUTA;
        }
        if (_s[_i] == '/')
        {
            _i++;
            return Token.PODELJENO;
        }
        if (_s[_i] == 'x')
        {
            _i++;
            return Token.PROMENLJIVA;
        }
        
        if (Char.IsDigit(_s[_i])) {
            _vrednost = 0.0;
            while (_i < _s.Length && Char.IsDigit(_s[_i])) {
                _vrednost = 10*_vrednost + _s[_i] - '0';
                _i++;
            }
            if (_i < _s.Length && _s[_i] == '.') {
                _i++;
                double decimala = 0.1;
                while (_i < _s.Length && Char.IsDigit(_s[_i])) {
                    _vrednost += decimala * (_s[_i] - '0');
                    decimala /= 10;
                    _i++;
                }
            }
            return Token.KONSTANTA;
        }

        if (Char.IsLetter(_s[_i]))
        {
            // optimizovati nadovezivanje niski
            _tekst = "";
            while (_i < _s.Length &&
                   (Char.IsLetter(_s[_i]) || Char.IsDigit(_s[_i])))
            {
                _tekst += _s[_i];
                _i++;
            }
            return Token.ID;
        }
        
        return Token.KRAJ;
    }

    public double Vrednost()
    {
        return _vrednost;
    }

    public string Tekst()
    {
        return _tekst;
    }

    private string _s;
    private int _i;
    private double _vrednost;
    private string _tekst;
}

class IzrazParser
{
    public IzrazParser(string s)
    {
        _lekser = new IzrazLekser(s);
    }
    
    public Izraz Parsiraj()
    {
        _token = _lekser.SledeciToken();
        return Izraz();
    }
    
    private Izraz Izraz()
    {
        Izraz sabirak = Sabirak();
        while (_token == Token.PLUS || _token == Token.MINUS) {
            if (_token == Token.PLUS)
            {
                _token = _lekser.SledeciToken();
                Izraz noviSabirak = Sabirak();
                sabirak = new Plus(sabirak, noviSabirak);
            }

            else if (_token == Token.MINUS)
            {
                _token = _lekser.SledeciToken();
                Izraz noviSabirak = Sabirak();
                sabirak = new Minus(sabirak, noviSabirak);
            }
        }
        return sabirak;
    }

    private Izraz Sabirak()
    {
        Izraz cinilac = Cinilac();
        while (_token == Token.PUTA || _token == Token.PODELJENO) {
            if (_token == Token.PUTA)
            {
                _token = _lekser.SledeciToken();
                Izraz noviCinilac = Cinilac();
                cinilac = new Puta(cinilac, noviCinilac);
            }
            else if (_token == Token.PODELJENO)
            {
                _token = _lekser.SledeciToken();
                Izraz noviCinilac = Cinilac();
                cinilac = new Podeljeno(cinilac, noviCinilac);
            }
        }
        return cinilac;
    }

    private Izraz Cinilac()
    {
        if (_token == Token.OTVORENA_ZAGRADA)
        {
            _token = _lekser.SledeciToken();
            Izraz izraz = Izraz();
            _token = _lekser.SledeciToken();
            return izraz;
        } else if (_token == Token.PROMENLJIVA) {
            _token = _lekser.SledeciToken();
            return new Promenljiva();
        } else if (_token == Token.KONSTANTA) {
            Izraz k = new Konstanta(_lekser.Vrednost());
            _token = _lekser.SledeciToken();
            return k;
        } else if (_token == Token.ID && _lekser.Tekst() == "sqrt") {
            _token = _lekser.SledeciToken();
            _token = _lekser.SledeciToken();
            Izraz op = Izraz();
            _token = _lekser.SledeciToken();
            return new Sqrt(op);
        }
        return null;
    }
    
    private IzrazLekser _lekser;
    private Token _token;
}

abstract class Izraz
{
    public abstract double Vrednost(double x);

    public abstract void Stampaj();
    
    static public Izraz Parsiraj(string s)
    {
        IzrazParser parser = new IzrazParser(s);
        return parser.Parsiraj();
    }
}

class Promenljiva : Izraz
{
    public override void Stampaj()
    {
        Console.Write("x");
    }
    
    public override double Vrednost(double x)
    {
        return x;
    }
}

class Konstanta : Izraz
{
    public Konstanta(double c)
    {
        this._c = c;
    }

    public override void Stampaj()
    {
        Console.Write(_c);
    }
    
    public override double Vrednost(double x)
    {
        return _c;
    }

    private double _c;
}

abstract class UnarnaOperacija : Izraz
{
    public UnarnaOperacija(Izraz op, string simbol)
    {
        this._op = op;
        this._simbol = simbol;
    }

    public override void Stampaj()
    {
        Console.Write(_simbol);
        Console.Write("(");
        _op.Stampaj();
        Console.Write(")");
    }
    
    public abstract double PrimeniOp(double op);
    
    public override double Vrednost(double x)
    {
        return PrimeniOp(_op.Vrednost(x));
    }
    
    private Izraz _op;
    private string _simbol;
}

abstract class BinarnaOperacija : Izraz
{
    public BinarnaOperacija(Izraz op1, Izraz op2, string simbol)
    {
        this._op1 = op1;
        this._op2 = op2;
        this._simbol = simbol;
    }

    public override void Stampaj()
    {
        Console.Write("(");
        _op1.Stampaj();
        Console.Write(")");
        Console.Write(_simbol);
        Console.Write("(");
        _op2.Stampaj();
        Console.Write(")");
    }

    public abstract double PrimeniOp(double op1, double op2);

    public override double Vrednost(double x)
    {
        return PrimeniOp(_op1.Vrednost(x), _op2.Vrednost(x));
    }
    
    private Izraz _op1, _op2;
    private string _simbol;
}

class Plus : BinarnaOperacija
{
    public Plus(Izraz op1, Izraz op2) : base(op1, op2, "+")
    {
    }
        
    public override double PrimeniOp(double op1, double op2)
    {
        return op1 + op2;
    }
}

class Minus : BinarnaOperacija
{
    public Minus(Izraz op1, Izraz op2) : base(op1, op2, "-")
    {
    }
    
    public override double PrimeniOp(double op1, double op2)
    {
        return op1 - op2;
    }
}

class Puta : BinarnaOperacija
{
    public Puta(Izraz op1, Izraz op2) : base(op1, op2, "*")
    {
    }
    
    public override double PrimeniOp(double op1, double op2)
    {
        return op1 * op2;
    }
}

class Podeljeno : BinarnaOperacija
{
    public Podeljeno(Izraz op1, Izraz op2) : base(op1, op2, "/")
    {
    }
    
    public override double PrimeniOp(double op1, double op2)
    {
        return op1 / op2;
    }
}

class Sqrt : UnarnaOperacija
{
    public Sqrt(Izraz op) : base(op, "sqrt")
    {
    }

    public override double PrimeniOp(double op)
    {
        return Math.Sqrt(op);
    }
}

class Program
{
    static void Main()
    {
        Izraz i = Izraz.Parsiraj("sqrt((x*3 + 1.1)*2)");
        i.Stampaj();
        Console.WriteLine();
        Console.WriteLine(i.Vrednost(1.0));
    }
}
