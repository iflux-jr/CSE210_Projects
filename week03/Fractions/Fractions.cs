using System;

public class Fraction
{
    // Private attributes (Encapsulation principle)
    private int _top;
    private int _bottom;

    // Constructor 1: no parameters, default to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2: one parameter (numerator only, denominator = 1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor 3: two parameters (numerator and denominator)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter and Setter for Top
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter and Setter for Bottom
    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        // Avoid zero denominator
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine("Denominator cannot be zero. Keeping previous value.");
        }
    }

    // Method to return string representation (like 3/4)
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to return decimal value
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
