namespace RomanConverter.Logic;

public interface IConverter
{
    public int ConvertToInt(string number);
    public string ConvertToRoman(int number);
    
}