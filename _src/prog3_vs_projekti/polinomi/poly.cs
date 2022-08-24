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
                Div.a[i] = Mod.a[i + Q.Deg] / Q.a[Q.Deg];
                for (int j = 0; j <= Q.Deg; j++)
                    Mod.a[j + i] -= Q.a[j] * Div.a[i];
            }
            Mod.Normalize();
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

        private string Monomial(double ai, int i, bool leading)
        {
            if (ai == 0)
                return "";

            string sign = (leading || ai < 0) ? "" : "+";
            string coef = (ai != 1 && ai != -1) ? ai.ToString() :
                (i == 0) ? ai.ToString() : "";
            string xPowI = 
                (i == 0) ? "" :
                (i == 1) ? "x" : 
                string.Format("x^{0}", i);

            return sign + coef + xPowI;
        }
        public override string ToString()
        {
            if (Deg < 0)
                return "0";

            StringBuilder sb = new StringBuilder();
            sb.Append(Monomial(a[Deg], Deg, true));
            for (int i = Deg-1; i >= 0; i--)
                sb.Append(Monomial(a[i], i, false));

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

            int n = 1 + Math.Max(P.Deg, Q.Deg);
            int n2 = n / 2;
            Polynomial Lo1 = new Polynomial(n2 - 1);
            Polynomial Hi1 = new Polynomial(P.Deg - n2);
            Polynomial Lo2 = new Polynomial(n2 - 1);
            Polynomial Hi2 = new Polynomial(Q.Deg - n2);
            for (int i = 0; i < n2; i++)
            {
                Lo1.a[i] = P.a[i];
                Lo2.a[i] = Q.a[i];
            }
            for (int i = n2; i <= P.Deg; i++)
                Hi1.a[i - n2] = P.a[i];
            for (int i = n2; i <= Q.Deg; i++)
                Hi2.a[i - n2] = Q.a[i];

            Polynomial z0 = Karatsuba(Lo1, Lo2);
            Polynomial z2 = Karatsuba(Hi1, Hi2);
            Polynomial z1 = Karatsuba(Lo1 + Hi1, Lo2 + Hi2) - z2 - z0;
            return z0 + z1.TimesxPow(n2) + z2.TimesxPow(2 * n2);
        }
    }
}
