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
        else if (D.t0 > t1) return D.t0 - t1;
        else return 0;
    }
    public bool Preseca(Duz1D D)
    {
        return t0 <= D.t1 && D.t0 <= t1;
    }
}
