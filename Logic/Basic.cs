// namespace RomanConverter.Logic;
//
// public class Basic : IConverter
// {
//
//
//     public Symbol[] Parse(string number)
//     {
//         var enumerator = number.GetEnumerator();
//         var symbols = new Symbol[number.Length];
//         int c = 0;
//         while (enumerator.MoveNext())
//         {
//             symbols[c] = Enum.Parse<Symbol>(Convert.ToString(enumerator.Current));
//         }
//         return symbols;
//     }
//     
//     
//     
//     public int ConvertToInt(string number)
//     {
//         int res = 0;
//         var symbols = Parse(number);
//
//         for (var i = 0; i < symbols.Length - 1; i++)
//         {
//             if (symbols[i] >= symbols[i + 1])
//             {
//                 res += symbols.;
//             }
//         }
//
//         return res;
//     }
//
//     public string ConvertToRoman(int number)
//     {
//         throw new NotImplementedException();
//     }
// }