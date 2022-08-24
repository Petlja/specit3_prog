class Tacka3D
{
    public double x;
    public double y;
    public double z;
    public static Tacka3D Ucitaj()
    {
        string[] s = Console.ReadLine().Split();
        return new Tacka3D()
        {
            x = double.Parse(s[0]),
            y = double.Parse(s[1]),
            z = double.Parse(s[2])
        };
    }
}
class Kutija
{
    Duz1D X;
    Duz1D Y;
    Duz1D Z;
    public Kutija(Duz1D DX, Duz1D DY, Duz1D DZ) { X = DX; Y = DY; Z = DZ; }
    public static Kutija Ucitaj()
    {
        string[] s = Console.ReadLine().Split();
        double x1 = double.Parse(s[0]);
        double y1 = double.Parse(s[1]);
        double z1 = double.Parse(s[2]);
        double x2 = double.Parse(s[3]);
        double y2 = double.Parse(s[4]);
        double z2 = double.Parse(s[5]);
        return new Kutija(new Duz1D(x1, x2), new Duz1D(y1, y2), new Duz1D(z1, z2));
    }
    public bool Sadrzi(Tacka3D T)
    {
        return X.Sadrzi(T.x) && Y.Sadrzi(T.y) && Z.Sadrzi(T.z);
    }
    public double Rastojanje(Tacka3D T)
    {
        double dx = X.Rastojanje(T.x);
        double dy = Y.Rastojanje(T.y);
        double dz = Z.Rastojanje(T.z);
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
    public double Rastojanje(Kutija K)
    {
        double dx = X.Rastojanje(K.X);
        double dy = Y.Rastojanje(K.Y);
        double dz = Z.Rastojanje(K.Z);
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
    public bool Preseca(Kutija K)
    {
        return X.Preseca(K.X) && Y.Preseca(K.Y) && Z.Preseca(K.Z);
    }
}
