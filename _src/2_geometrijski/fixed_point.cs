using System;
class Program
{
    class FixedPoint
    {
        const int SHIFT = 24; // broj bita koji se koristi kao razomljeni deo
        int x;
        int Internal { get { return x; } }
        public FixedPoint() { x = 0; }
        FixedPoint(int a) { x = a << SHIFT; }
        public static FixedPoint operator +(FixedPoint a, FixedPoint b)
        => new FixedPoint() { x = a.x + b.x };
        public static FixedPoint operator -(FixedPoint a, FixedPoint b)
        => new FixedPoint() { x = a.x - b.x };
        public static FixedPoint operator *(FixedPoint a, FixedPoint b)
        {
            long ab = ((((long)a.x * b.x) >> (SHIFT - 1)) + 1) >> 1;
            return new FixedPoint() { x = (int)ab };
        }
        public static FixedPoint operator /(FixedPoint a, FixedPoint b)
        {
            long a_div_b = ((((long)a.x) << SHIFT) + (b.x >> 1)) / b.x;
            return new FixedPoint() { x = (int)a_div_b };
        }
        public override string ToString()
        {
            double rez = (double)x / (1 << SHIFT);
            return rez.ToString("0.0000000");
        }
        static void Main(string[] args)
        {
            FixedPoint jedan = new FixedPoint(1);
            FixedPoint dva = new FixedPoint(2);
            FixedPoint tri = new FixedPoint(3);

            Console.WriteLine("1 se pise kao " + jedan.Internal);

            Console.WriteLine("2*3=" + (dva * tri));
            Console.WriteLine("2/3=" + (dva / tri));

            Console.WriteLine("2/1=" + (dva / jedan));
            Console.WriteLine("1/2=" + (jedan / dva));

            Console.WriteLine("3/1=" + (tri / jedan));
            Console.WriteLine("1/3=" + (jedan / tri));
        }
    }
}
