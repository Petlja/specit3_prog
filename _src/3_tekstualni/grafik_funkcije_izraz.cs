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
