class IzrazParser
{
    public IzrazParser(string s)
    {
        _lekser = new IzrazLekser(s);
    }
    
    public Izraz Parsiraj()
    {
        // citamo prvi token
        _token = _lekser.SledeciToken();
        return Izraz();
    }
    
    private Izraz Izraz()
    {
        Izraz sabirak = Sabirak();
        while (_token == Token.PLUS || _token == Token.MINUS) {
            if (_token == Token.PLUS)
            {
                // preskacemo token PLUS
                _token = _lekser.SledeciToken();
                Izraz noviSabirak = Sabirak();
                sabirak = new Plus(sabirak, noviSabirak);
            }

            else if (_token == Token.MINUS)
            {
                // preskacemo token MINUS
                _token = _lekser.SledeciToken();
                Izraz noviSabirak = Sabirak();
                sabirak = new Minus(sabirak, noviSabirak);
            }
        }
        return sabirak;
    }

    private Izraz Sabirak()
    {
        Izraz cinilac = Cinilac();
        while (_token == Token.PUTA || _token == Token.PODELJENO) {
            if (_token == Token.PUTA)
            {
                // preskacemo token PUTA
                _token = _lekser.SledeciToken();
                Izraz noviCinilac = Cinilac();
                cinilac = new Puta(cinilac, noviCinilac);
            }
            else if (_token == Token.PODELJENO)
            {
                // preskacemo token PODELJENO
                _token = _lekser.SledeciToken();
                Izraz noviCinilac = Cinilac();
                cinilac = new Podeljeno(cinilac, noviCinilac);
            }
        }
        return cinilac;
    }

    private Izraz Cinilac()
    {
        if (_token == Token.OTVORENA_ZAGRADA)
        {
            // preskacemo token OTVORENA_ZAGRADA
            _token = _lekser.SledeciToken();
            Izraz izraz = Izraz();
            // preskacemo token ZATVORENA_ZAGRADA
            _token = _lekser.SledeciToken();
            return izraz;
        } else if (_token == Token.PROMENLJIVA) {
            // preskacemo token PROMENLJIVA
            _token = _lekser.SledeciToken();
            return new Promenljiva();
        } else if (_token == Token.KONSTANTA) {
            Izraz k = new Konstanta(_lekser.Vrednost());
            // preskacemo token KONSTANTA
            _token = _lekser.SledeciToken();
            return k;
        } else if (_token == Token.ID && _lekser.Tekst() == "sqrt") {
            // preskacemo token ID
            _token = _lekser.SledeciToken();
            // preskacemo token OTVORENA_ZAGRADA
            _token = _lekser.SledeciToken();
            Izraz op = Izraz();
            // preskacemo token ZATVORENA_ZAGRADA
            _token = _lekser.SledeciToken();
            return new Sqrt(op);
        }
        // ako je ulaz ispravan do ovoga se ne moze stici
        return null;
    }

    // leksicki analizator
    private IzrazLekser _lekser;
    // token koji je naredni na ulazu
    private Token _token;
}
