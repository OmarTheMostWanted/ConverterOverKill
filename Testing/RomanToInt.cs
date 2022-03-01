using Xunit;
using RomanConverter.Logic;

namespace RomanConverter.Testing;

public class RomanToInt
{
    private IConverter _converter;


    int RunTestInt(string number)
    {
        return _converter.ConvertToInt(number);
    }


    string RunTestRoman(int number)
    {
        return _converter.ConvertToRoman(number);
    }

    [Fact]
    public void Test()
    {

        SymbolFactory symbolFactory = new SymbolFactory();

        symbolFactory.CreateSymbol('I', 1);


    }


}
