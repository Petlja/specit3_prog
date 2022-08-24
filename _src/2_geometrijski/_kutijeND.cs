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
    class Tacka
    {
        public double[] x;
        public static Tacka Ucitaj()
        {
            string[] s = Console.ReadLine().Split();
            Tacka T = new Tacka();
            for (int i = 0; i < s.Length; i++)
                T.x[i] = double.Parse(s[i]);

            return T;
        }
    }
    class KutijaND
    {
        Duz1D[] X;
        public Duz1D this[int i]
        {
            get => X[i];
        }
        public KutijaND(Duz1D[] DX) { X = (Duz1D[])DX.Clone(); }
        public static KutijaND Ucitaj()
        {
            string[] s = Console.ReadLine().Split();
            int n = s.Length / 2;
            double[] x = new double[n];
            double[] y = new double[n];
            Duz1D[] D = new Duz1D[n];
            for (int i = 0; i < n; i++)
                D[i] = new Duz1D(double.Parse(s[i]), double.Parse(s[n + i]));

            return new KutijaND(D);
        }
        public bool Sadrzi(Tacka T)
        {
            int n = X.Length;
            bool odg = true;
            for (int i = 0; i < X.Length; i++)
                odg = odg && X[i].Sadrzi(T.x[i]);

            return odg;
        }
        public double Rastojanje(Tacka T)
        {
            int n = X.Length;
            double s = 0;
            for (int i = 0; i < X.Length; i++)
            {
                double di = X[i].Rastojanje(T.x[i]);
                s += di * di;
            }
            return Math.Sqrt(s);
        }
        public double Rastojanje(KutijaND K)
        {
            int n = X.Length;
            double s = 0;
            for (int i = 0; i < X.Length; i++)
            {
                double di = X[i].Rastojanje(K[i]);
                s += di * di;
            }
            return Math.Sqrt(s);
        }
        public bool Preseca(KutijaND K)
        {
            int n = X.Length;
            bool odg = true;
            for (int i = 0; i < X.Length; i++)
                odg = odg && X[i].Preseca(K.X[i]);

            return odg;
        }
    }
    static void Main(string[] args)
    {
        Tacka A2 = new Tacka() { x = new double[] { 2, 1 } };
        Tacka B2 = new Tacka() { x = new double[] { 2, 2 } };
        Tacka C2 = new Tacka() { x = new double[] { 5, 6 } };

        KutijaND Ram1 = new KutijaND(new Duz1D[] { new Duz1D(1, 2), new Duz1D(1, 2) });
        KutijaND Ram2 = new KutijaND(new Duz1D[] { new Duz1D(3, 4), new Duz1D(4, 5) });
        Console.WriteLine(Ram1.Sadrzi(A2));
        Console.WriteLine(Ram1.Rastojanje(A2));
        Console.WriteLine(Ram1.Rastojanje(B2));
        Console.WriteLine(Ram1.Rastojanje(C2));
        Console.WriteLine(Ram1.Preseca(Ram2));
        Console.WriteLine(Ram1.Rastojanje(Ram2));

        Tacka A3 = new Tacka() { x = new double[] { 2, 1, 3 } };
        Tacka B3 = new Tacka() { x = new double[] { 2, 2, 2 } };
        Tacka C3 = new Tacka() { x = new double[] { 5, 6, 15 } };
        KutijaND K1 = new KutijaND(new Duz1D[] { new Duz1D(1, 2), new Duz1D(1, 2), new Duz1D(2, 3) });
        KutijaND K2 = new KutijaND(new Duz1D[] { new Duz1D(3, 4), new Duz1D(3, 4), new Duz1D(4, 5) });
        Console.WriteLine(K1.Sadrzi(A3));
        Console.WriteLine(K1.Rastojanje(A3));
        Console.WriteLine(K1.Rastojanje(B3));
        Console.WriteLine(K1.Rastojanje(C3));
        Console.WriteLine(K1.Preseca(K2));
        Console.WriteLine(K1.Rastojanje(K2));
    }
}
