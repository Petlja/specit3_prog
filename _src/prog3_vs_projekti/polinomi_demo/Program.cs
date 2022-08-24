using System;
using Polynomials;

namespace polinomi_demo
{
    class Program
    {
        static void TestIspisivanja()
        {
            double[][] coefsAraay = {
                new double[]{ 4, -3, 2, 0 },  // 4x^3-3x^2+2x
                new double[]{ 4, 0, 0 },      // 4x^2
                new double[]{ 4, 0, 1 },      // 4x^2+1
                new double[]{ 2, 0 },         // 2x
                new double[]{ 2, -1 },        // 2x-1
                new double[]{ 2, 1 },         // 2x+1
                new double[]{ 1, 1 }          // x+1
            };
            Console.WriteLine("Ispisivanje:"); 
            foreach (var coefs in coefsAraay)
                Console.WriteLine(new Polynomial(coefs));
        }
        static void TestOperacija()
        {
            Console.WriteLine("Operacije:");
            double[] a = { 3, 2, -1 };
            double[] b = { 1, 1 };
            Polynomial P = new Polynomial(a);
            Polynomial Q = new Polynomial(b);
            Console.WriteLine("P = {0}", P);
            Console.WriteLine("Q = {0}", Q);
            Console.WriteLine("P/2 = {0}", P/2);
            Console.WriteLine("P + Q = {0}", P + Q);
            Console.WriteLine("P - Q = {0}", P - Q);
            Console.WriteLine("Q - P = {0}", Q - P);
            Console.WriteLine("P * Q = {0}", P * Q);
            Console.WriteLine("P - P = {0}", P - P);
            Console.WriteLine("P / Q = {0}", P / Q);
            Console.WriteLine("P % Q = {0}", P % Q);
            var dm = Polynomial.DivMod(P, Q);
            Console.WriteLine("div1: " + dm.Item1);
            Console.WriteLine("mod1: " + dm.Item2);
            
            double[] c = { 4, 3, 2, 1 };
            Polynomial R = new Polynomial(c);
            Polynomial T = R * R;
            Console.WriteLine("obicno mnozenje: {0}", T * R);
            Console.WriteLine("Karacuba mnoz.   {0}", Polynomial.Karatsuba(T, R));
        }

        static void Main(string[] args)
        {
            TestIspisivanja();
            Console.WriteLine();
            TestOperacija();
        }
    }
}
