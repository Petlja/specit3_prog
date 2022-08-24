class Tacka2D
{
    public double x;
    public double y;
    public static Tacka2D Ucitaj()
    {
        string[] s = Console.ReadLine().Split();
        return new Tacka2D()
        {
            x = double.Parse(s[0]),
            y = double.Parse(s[1])
        };
    }
}
class Ram
{
    Duz1D X;
    Duz1D Y;
    public Ram(Duz1D DX, Duz1D DY) { X = DX; Y = DY; }
    public static Ram Ucitaj()
    {
        string[] s = Console.ReadLine().Split();
        double x1 = double.Parse(s[0]);
        double y1 = double.Parse(s[1]);
        double x2 = double.Parse(s[2]);
        double y2 = double.Parse(s[3]);
        return new Ram(new Duz1D(x1, x2), new Duz1D(y1, y2));
    }
    public bool Sadrzi(Tacka2D T)
    {
        return X.Sadrzi(T.x) && Y.Sadrzi(T.y);
    }
    public double Rastojanje(Tacka2D T)
    {
        double dx = X.Rastojanje(T.x);
        double dy = Y.Rastojanje(T.y);
        return Math.Sqrt(dx * dx + dy * dy);
    }
    public double Rastojanje(Ram R)
    {
        double dx = X.Rastojanje(R.X);
        double dy = Y.Rastojanje(R.Y);
        return Math.Sqrt(dx * dx + dy * dy);
    }
    public bool Preseca(Ram K)
    {
        return X.Preseca(K.X) && Y.Preseca(K.Y);
    }
}
