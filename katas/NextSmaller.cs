
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace katas
{
    public class NextSmallerKata
    {
        public static long NextSmaller(long n)
        {
            var originalDigits = GetDigits(n);
            try
            {
                //// Find first number where prev is greater
                var x = FindFirst(originalDigits);

                //// Find first number which is greater than x
                var y = FindSecond(originalDigits, x.number);

                originalDigits.RemoveAt(y.index);
                originalDigits.Insert(x.index, y.number);

                var right = originalDigits.GetRange(0, x.index);
                var left = originalDigits.GetRange(x.index, originalDigits.Count - right.Count);

                right.Sort();
                var rightStr = String.Join("", right);
                var leftStr = String.Join("", left);
                var result = $"{leftStr}{rightStr}";

                if (result.StartsWith("0"))
                    return -1;

                return long.Parse(result);
            }
            catch (Exception e)
            {
                return -1;
            }
            return -1;
        }

        private static (long number, int index) FindSecond(List<long> originalDigits, long x)
        {
            for (int i = 0; i < originalDigits.Count; i++)
            {
                long item = originalDigits[i];
                if (item > x)
                    return (item, i);
            }
            var first = originalDigits.First();
            return (first, originalDigits.IndexOf(first));
        }

        private static (long number, int index) FindFirst(List<long> originalDigits)
        {
            long x = 0;
            for (int i = 0; i < originalDigits.Count; i++)
            {
                long item = originalDigits[i];
                var previndex = i - 1 < 0 ? i : i - 1;
                long previous = originalDigits[previndex];
                if (previous > item)
                {
                    x = item;
                    return (item, i);
                }
            }
            //If nothing found, the first was the smallest
            var first = originalDigits.First();
            return (first, 0);
        }

        private static List<long> GetDigits(long n)
        {
            var digits = new List<long>();
            do
            {
                digits.Add(n % 10);
                n = n / 10;
            } while (n > 0);
            return digits;
        }

    }
}
