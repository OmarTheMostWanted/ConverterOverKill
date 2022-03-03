using System.Text;

namespace RomanConverter.Logic;

public class Basic : IConverter
{
    private static HashSet<char> allowedSymbols = new HashSet<char>(new char[] {'I', 'V', 'X', 'L', 'C', 'D', 'M'});

    public List<AbstractSymbol> Parse(string number)
    {
        SymbolFactory symbolFactory = new SymbolFactory();
        var symbols = symbolFactory.GenerateAllSymbols();
        List<AbstractSymbol> list = new List<AbstractSymbol>();

        for (var i = 0; i < number.Length; i++)
        {
            if (allowedSymbols.Contains(number[i]))
            {
                list.Add(symbols[number[i]]);
            }
            else throw new InvalidRomanNumeralException($"{number[i]} is not a valid Symbol");
        }

        return list;
    }


    public int ConvertToInt(string number)
    {
        int res = 0;

        var list = Parse(number);

        for (var i = 0; i < list.Count - 1; i++)
        {
            if (list[i].CompareTo(list[i + 1]) >= 0)
            {
                res += list[i].Val;
            }
            else res -= list[i].Val;
        }

        if (number.Length > 0)
        {
            res += list[number.Length - 1].Val;
        }

        return res;
    }

    private static int[] ranks = {1000, 500, 100, 50, 10, 5, 1};

    public string ConvertToRoman(int number)
    {
        var numbers = new SymbolFactory().GenerateAllNumbers();

        var res = new StringBuilder();

        if (number == 0) return res.ToString();
        if (number < 0) throw new Exception("Niggative numbers not allowed");

        var cur = number;

        while (cur > 0)
        {
            int factor = -1;
            int rank;
            for (var i = 0; i <= ranks.Length-1; i++)
            {
                factor = cur / ranks[i];
                while (factor > 0)
                {
                    var s = numbers[ranks[i]].S;
                    res.Append(s);
                    factor--;
                    cur -= factor;
                }
            }
        }


        return res.ToString();
    }
}