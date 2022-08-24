using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Polynomials
{
    public class Polynomial
    {
        private List<double> a;

        public Polynomial(Polynomial P)
        {
            int n = P.Deg + 1;
            a = new List<double>(n); // n is the capacity
            for (int i = 0; i < n; i++)
                a.Add(P.a[i]);
        }
        public Polynomial(IEnumerable coef)
        {
            a = new List<double>();
            foreach (double c in coef)
                a.Add(c);

            a.Reverse();
        }

        // Ovaj metod omogucava da polinome sabiramo, 
        // oduzimamo, mnozimo i delimo sa realnim brojevima
        // tj. da realne brojeve tretiramo kao polinome stepena 0
        public static implicit operator Polynomial(double c)
        {
            Polynomial P = new Polynomial(0);
            P.a[0] = c;
            return P;
        }

        public int Deg 
        { 
            get { return a != null ? a.Count - 1 : -1; } 
        }
        public static Polynomial operator +(Polynomial P, Polynomial Q)
        {
            if (P.Deg < Q.Deg)
            {
                Polynomial tmp = P; P = Q; Q = tmp;
            }
            Polynomial R = new Polynomial(P);
            for (int i = 0; i <= Q.Deg; i++)
                R.a[i] += Q.a[i];

            R.Normalize();
            return R;
        }
        public static Polynomial operator -(Polynomial P, Polynomial Q)
        {
            Polynomial R;
            if (P.Deg >= Q.Deg)
            {
                R = new Polynomial(P);
                for (int i = 0; i <= Q.Deg; i++)
                    R.a[i] -= Q.a[i];
            }
            else 
            {
                R = new Polynomial(Q.Deg);
                for (int i = 0; i <= P.Deg; i++)
                    R.a[i] = P.a[i] - Q.a[i];
                for (int i = P.Deg+1; i <= Q.Deg; i++)
                    R.a[i] = -Q.a[i];
            }
            R.Normalize();
            return R;
        }
        public static Polynomial operator *(Polynomial P, Polynomial Q)
        {
            Polynomial R = new Polynomial(P.Deg + Q.Deg);
            for (int i = 0; i <= P.Deg; i++)
                for (int j = 0; j <= Q.Deg; j++)
                    R.a[i + j] += P.a[i] * Q.a[j];

            return R;
        }
        public static Polynomial Zero()
        {
            return new Polynomial(new double[] { });
        }
        public static Tuple<Polynomial, Polynomial> DivMod(Polynomial P, Polynomial Q)
        {
            if (P.Deg < Q.Deg)
                return new Tuple<Polynomial, Polynomial>(Zero(), new Polynomial(Q));

            Polynomial Div = new Polynomial(P.Deg - Q.Deg);
            Polynomial Mod = new Polynomial(P);
            for (int i = Div.Deg; i >= 0; i--)
            {
                if (Mod.Deg < 0)
                    Div.a[i] = 0;
                else
                    Div.a[i] = Mod.a[Mod.Deg] / Q.a[Q.Deg];
                Mod = P - Div * Q; // uz vise pisanja moze efikasnije **********************
            }
            return new Tuple<Polynomial, Polynomial>(Div, Mod);
        }
        public static Polynomial operator /(Polynomial P, Polynomial Q)
        {
            return DivMod(P, Q).Item1;
        }
        public static Polynomial operator %(Polynomial P, Polynomial Q)
        {
            return DivMod(P, Q).Item2;
        }

        public override string ToString()
        {
            if (Deg < 0)
                return "0";
            if (Deg == 0)
                return string.Format("{0}", a[0]);

            StringBuilder sb = new StringBuilder();
            if (Deg == 1)
            {
                sb.Append(string.Format("{0}*x", a[1]));

                if (a[0] > 0)
                    sb.Append(string.Format("+{0}", a[0]));
                else if (a[0] < 0)
                    sb.Append(string.Format("{0}", a[0]));

                return sb.ToString();
            }

            sb.Append(string.Format("{0}*x^{1}", a[Deg], Deg));
            for (int i = Deg-1; i >= 2; i--)
            {
                if (a[i] > 0)
                    sb.Append(string.Format("+{0}*x^{1}", a[i], i));
                else if (a[i] < 0)
                    sb.Append(string.Format("{0}*x^{1}", a[i], i));
            }
            if (a[1] > 0)
                sb.Append(string.Format("+{0}*x", a[1]));
            else if (a[1] < 0)
                sb.Append(string.Format("{0}*x", a[1]));
            if (a[0] > 0)
                sb.Append(string.Format("+{0}", a[0]));
            else if (a[0] < 0)
                sb.Append(string.Format("{0}", a[0]));

            return sb.ToString();
        }
        private Polynomial(int n)
        {
            a = new List<double>(n+1); // capacity
            for (int i = 0; i <= n; i++)
                a.Add(0);
        }
        private void Normalize()
        {
            int n = Deg, k = 0;
            while (k <= n && a[n - k] == 0)
                k++;

            if (k > 0)
                a.RemoveRange(n - k + 1, k);
        }

        private Polynomial TimesxPow(int n)
        {
            Polynomial P = new Polynomial(Deg + n);
            for (int i = Deg; i >= 0; i--)
                P.a[i + n] = a[i];

            return P;
        }
        public static Polynomial Karatsuba(Polynomial P, Polynomial Q)
        {
            if (P.Deg <= 1 || Q.Deg <= 1) 
                return P * Q;

            int n = 1 + Math.Min(P.Deg, Q.Deg);
            int m = n / 2;
            Polynomial Lo1 = new Polynomial(m - 1);
            Polynomial Hi1 = new Polynomial(P.Deg - m);
            Polynomial Lo2 = new Polynomial(m - 1);
            Polynomial Hi2 = new Polynomial(Q.Deg - m);
            for (int i = 0; i < m; i++)
            {
                Lo1.a[i] = P.a[i];
                Lo2.a[i] = Q.a[i];
            }
            for (int i = m; i <= P.Deg; i++)
                Hi1.a[i - m] = P.a[i];
            for (int i = m; i <= Q.Deg; i++)
                Hi2.a[i - m] = Q.a[i];

            Polynomial z0 = Karatsuba(Lo1, Lo2);
            Polynomial z2 = Karatsuba(Hi1, Hi2);
            Polynomial z1 = Karatsuba(Lo1 + Hi1, Lo2 + Hi2) - z2 - z0;
            return z0 + z1.TimesxPow(m) + z2.TimesxPow(2 * m);
        }
    }
}
