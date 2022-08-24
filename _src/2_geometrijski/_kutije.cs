using System;
class Program
{
    class Duz1D
    {
        double t0;
        double t1;
        public Duz1D(double a, double b)
        {
            if (a < b) { t0 = a; t1 = b; }
            else { t0 = b; t1 = a; }
        }
        public bool Sadrzi(double t)
        {
            return t0 <= t && t <= t1;
        }
        public double Rastojanje(double t)
        {
            if (t < t0) return t0 - t;
            else if (t < t1) return 0;
            else return t1 - t;
        }
        public double Rastojanje(Duz1D D)
        {
            if (t0 > D.t1) return t0 - D.t1;
            if (D.t0 > t1) return D.t0 - t1;
            return 0;
        }
        public bool Preseca(Duz1D D)
        {
            return t0 <= D.t1 && D.t0 <= t1;
        }
    }
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
    static void Main(string[] args)
    {
        Tacka3D A3 = new Tacka3D() { x = 2, y = 1, z = 3 };
        Tacka3D B3 = new Tacka3D() { x = 2, y = 2, z = 2 };
        Tacka3D C3 = new Tacka3D() { x = 5, y = 6, z = 15 };
        Kutija K1 = new Kutija(new Duz1D(1, 2), new Duz1D(1, 2), new Duz1D(2, 3));
        Kutija K2 = new Kutija(new Duz1D(3, 4), new Duz1D(3, 4), new Duz1D(4, 5));
        Console.WriteLine(K1.Sadrzi(A3));
        Console.WriteLine(K1.Rastojanje(A3));
        Console.WriteLine(K1.Rastojanje(B3));
        Console.WriteLine(K1.Rastojanje(C3));
        Console.WriteLine(K1.Preseca(K2));
        Console.WriteLine(K1.Rastojanje(K2));
    }
}
