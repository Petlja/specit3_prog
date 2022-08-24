enum Token
{
    PROMENLJIVA, KONSTANTA,
    PLUS, MINUS, PUTA, PODELJENO,
    OTVORENA_ZAGRADA, ZATVORENA_ZAGRADA,
    ID,
    KRAJ,
};

class IzrazLekser
{
    public IzrazLekser(string s)
    {
        this._s = s;
        this._i = 0;
    }

    public Token SledeciToken()
    {
        // preskacemo beline
        while (_i < _s.Length && Char.IsWhiteSpace(_s[_i]))
            _i++;

        if (_i >= _s.Length)
            return Token.KRAJ;
               
        if (_s[_i] == '(')
        {
            _i++;
            return Token.OTVORENA_ZAGRADA;
        }
        if (_s[_i] == ')')
        {
            _i++;
            return Token.ZATVORENA_ZAGRADA;
        }
        if (_s[_i] == '+')
        {
            _i++;
            return Token.PLUS;
        }
        if (_s[_i] == '-')
        {
            _i++;
            return Token.MINUS;
        }
        if (_s[_i] == '*')
        {
            _i++;
            return Token.PUTA;
        }
        if (_s[_i] == '/')
        {
            _i++;
            return Token.PODELJENO;
        }
        if (_s[_i] == 'x')
        {
            _i++;
            return Token.PROMENLJIVA;
        }
        
        if (Char.IsDigit(_s[_i])) {
            _vrednost = 0.0;
            while (_i < _s.Length && Char.IsDigit(_s[_i])) {
                _vrednost = 10*_vrednost + _s[_i] - '0';
                _i++;
            }
            if (_i < _s.Length && _s[_i] == '.') {
                _i++;
                double decimala = 0.1;
                while (_i < _s.Length && Char.IsDigit(_s[_i])) {
                    _vrednost += decimala * (_s[_i] - '0');
                    decimala /= 10;
                    _i++;
                }
            }
            return Token.KONSTANTA;
        }

        if (Char.IsLetter(_s[_i]))
        {
            // optimizovati nadovezivanje niski
            _naziv = "";
            while (_i < _s.Length &&
                   (Char.IsLetter(_s[_i]) || Char.IsDigit(_s[_i])))
            {
                _naziv += _s[_i];
                _i++;
            }
            return Token.ID;
        }
        
        return Token.KRAJ;
    }

    public double Vrednost()
    {
        return _vrednost;
    }

    public string Naziv()
    {
        return _naziv;
    }

    private string _s;
    private int _i;
    private double _vrednost;
    private string _naziv;
}
