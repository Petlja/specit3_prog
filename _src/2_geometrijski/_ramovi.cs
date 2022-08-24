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
    static void Main(string[] args)
    {
        Tacka2D A2 = new Tacka2D() { x = 2, y = 1 };
        Tacka2D B2 = new Tacka2D() { x = 2, y = 2 };
        Tacka2D C2 = new Tacka2D() { x = 5, y = 6 };
        Ram R1 = new Ram(new Duz1D(1, 2), new Duz1D(1, 2));
        Ram R2 = new Ram(new Duz1D(3, 4), new Duz1D(4, 5));
        Console.WriteLine(R1.Sadrzi(A2));
        Console.WriteLine(R1.Rastojanje(A2));
        Console.WriteLine(R1.Rastojanje(B2));
        Console.WriteLine(R1.Rastojanje(C2));
        Console.WriteLine(R1.Preseca(R2));
        Console.WriteLine(R1.Rastojanje(R2));
    }
}
