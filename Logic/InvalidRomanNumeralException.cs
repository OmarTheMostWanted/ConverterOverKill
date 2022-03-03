namespace RomanConverter.Logic;

public class InvalidRomanNumeralException : Exception
{
    public InvalidRomanNumeralException(string message) : base(message)
    {
    }
}