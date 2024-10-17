using System;

public class Fraction {
    private int _top;
    private int _bottom;

    public Fraction ()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFraction()
    {
        return $"{_top}/{_bottom}";
        
    }

    public double GetDecimal()
    {
        return (double)_top / _bottom;
    }
}   