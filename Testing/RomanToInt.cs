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
        var res = symbolFactory.GenerateAllSymbols();

        
        
        Assert.NotEmpty(res);
        Assert.Equal(1 , res['I'].Val);
        Assert.Equal(5 , res['V'].Val);
        Assert.Equal(10 , res['X'].Val);
        Assert.Equal(50 , res['L'].Val);
        Assert.Equal(100 , res['C'].Val);
        Assert.Equal(500 , res['D'].Val);
        Assert.Equal(1000 , res['M'].Val);
        

    }


}
