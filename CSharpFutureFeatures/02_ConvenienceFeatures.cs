using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Console;
using System.Math;
using System.IO;

namespace CSharpFutureFeatures
{
    // Before

    public static class UtilsCS5
    {
        public static double DegSin(double degrees)
        {
            return Math.Sin(180.0 * degrees / Math.PI);
        }

        public static void PrintSin(double radians)
        {
            Console.WriteLine(Math.Sin(radians));
        }

        public static Dictionary<int, double> PrecalculateSines()
        {
            return new Dictionary<int, double>
            {
                { 0,  0 },
                { 30, 0.5 },
                { 45, Math.Sqrt(2) / 2 },
                { 60, Math.Sqrt(3) / 2 },
                { 90, 1 },
            };
        }

        public static decimal? MaybeParseDecimal(string text)
        {
            decimal amount;

            if (Decimal.TryParse(text, out amount))
            {
                return amount;
            }

            return null;
        }

        public static int GetRandomSquare(int maxValue)
        {
            var r = new Random();
            var x = r.Next(maxValue);
            var square = x * x;
            return square;
        }
    }

    // After

    public static class UtilsCS6
    {
        public static double DegSin(double degrees)
        {
            return Sin(180.0 * degrees / PI);
        }

        public static void PrintSin(double radians)
        {
            WriteLine(Sin(radians));
        }

        public static decimal? MaybeParseDecimal(string text)
        {
            if (Decimal.TryParse(text, out decimal amount))  // declaration expression
            {
                return amount;
            }

            return null;
        }

        public static int GetRandomSquare(int maxValue)
        {
            var r = new Random();
            var square = (var x = r.Next(maxValue)) * x;
            return square;
        }

        public static IEnumerable<decimal> GetDecimals(string filePath, decimal errorValue)
        {
            return File.ReadAllLines(filePath)
                       .Select(l => Decimal.TryParse(l, out var d) ? d : errorValue);  // type inference
        }
    }
}
