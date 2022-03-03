using Xunit;
using RomanConverter.Logic;

namespace RomanConverter.Testing;

public class RomanToInt
{
    
    [Fact]
    public void CreateAllSymbolsTest()
    {
        var symbolFactory = new SymbolFactory();
        var res = symbolFactory.GenerateAllSymbols();
        Assert.NotEmpty(res);
        Assert.Equal(1, res['I'].Val);
        Assert.Equal(5, res['V'].Val);
        Assert.Equal(10, res['X'].Val);
        Assert.Equal(50, res['L'].Val);
        Assert.Equal(100, res['C'].Val);
        Assert.Equal(500, res['D'].Val);
        Assert.Equal(1000, res['M'].Val);

        Assert.Equal(typeof(AbstractSymbol), symbolFactory.CreateSymbol('V', 5).GetType().BaseType);
    }

    [Fact]
    public void ParseTest()
    {
        var basic = new Basic();
        var i = basic.Parse("I");
        var iii = basic.Parse("III");
        var iv = basic.Parse("IV");
        Assert.Single(i);
        Assert.Equal(1, i[0].Val);
        Assert.Equal('I', i[0].S);
        Assert.Equal(3, iii.Count);
        Assert.Equal('V', iv[1].S);
    }


    [Fact]
    public void ConvertToIntTest() //TDD
    {
        var basic = new Basic();

        Assert.Equal(1, basic.ConvertToInt("I"));
        Assert.Equal(2, basic.ConvertToInt("II"));
        Assert.Equal(4, basic.ConvertToInt("IV"));
        Assert.Equal(5, basic.ConvertToInt("V"));
        Assert.Equal(6, basic.ConvertToInt("VI"));
        Assert.Equal(7, basic.ConvertToInt("VII"));
        Assert.Equal(8, basic.ConvertToInt("VIII"));
        Assert.Equal(10, basic.ConvertToInt("X"));
        Assert.Equal(20, basic.ConvertToInt("XX"));
        Assert.Equal(30, basic.ConvertToInt("XXX"));
        Assert.Equal(40, basic.ConvertToInt("XL"));
        Assert.Equal(700, basic.ConvertToInt("DCC"));
        Assert.Equal(1001, basic.ConvertToInt("MI"));
    }

    [Theory]
    [InlineData(0, "")]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(10, "X")]
    [InlineData(20, "XX")]
    [InlineData(30, "XXX")]
    [InlineData(40, "XL")]
    [InlineData(700, "DCC")]
    [InlineData(1001, "MI")]
    [InlineData(39, "XXXIX")]
    [InlineData(246, "CCXLVI")]
    [InlineData(789, "DCCLXXXIX")]
    [InlineData(2421, "MMCDXXI")]
    [InlineData(160, "CLX")]
    [InlineData(207, "CCVII")]
    [InlineData(1009, "MIX")]
    [InlineData(1066, "MLXVI")]
    public void ConvertToIntParametrizedTest(int expected, string number)
    {
        var basic = new Basic();
        Assert.Equal(expected, basic.ConvertToInt(number));
    }

    [Fact]
    public void InvalidSymbolTest()
    {
        Assert.Throws<InvalidRomanNumeralException>(() => { new Basic().ConvertToInt(" "); });
    }
    
    
    [Theory]
    [InlineData(0, "")]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(10, "X")]
    [InlineData(20, "XX")]
    [InlineData(30, "XXX")]
    [InlineData(40, "XL")]
    [InlineData(700, "DCC")]
    [InlineData(1001, "MI")]
    [InlineData(39, "XXXIX")]
    [InlineData(246, "CCXLVI")]
    [InlineData(789, "DCCLXXXIX")]
    [InlineData(2421, "MMCDXXI")]
    [InlineData(160, "CLX")]
    [InlineData(207, "CCVII")]
    [InlineData(1009, "MIX")]
    [InlineData(1066, "MLXVI")]
    public void ConvertToRomanParametrizedTest(int number, string expected)
    {
        var basic = new Basic();
        Assert.Equal(expected, basic.ConvertToRoman(number));
    }
    
}