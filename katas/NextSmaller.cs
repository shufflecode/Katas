
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
            var lists = originalDigits.Permute();
            var permutations = new Dictionary<string, long>();
            foreach (var item in lists)
            {
                var numstring = String.Join("", item);
                var number = long.Parse(numstring);
                if (!permutations.ContainsKey(numstring))
                    permutations.Add(numstring, number);
            }
            var sorted = permutations.OrderByDescending(p => p.Value);
            var result = sorted.First(num => num.Value < n);

            if (result.Key.StartsWith("0"))
                return -1;
            return result.Value;
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

    public static class ListExtensions
    {
        public static IEnumerable<List<T>> Permute<T>(this IList<T> items)
        {
            var indices = Enumerable.Range(0, items.Count).ToArray();
            yield return indices.Select(idx => items[idx]).ToList();
            var weights = new int[items.Count];
            var idxUpper = 1;
            while (idxUpper < items.Count)
            {
                if (weights[idxUpper] < idxUpper)
                {
                    var idxLower = idxUpper % 2 * weights[idxUpper];
                    var tmp = indices[idxLower];
                    indices[idxLower] = indices[idxUpper];
                    indices[idxUpper] = tmp;
                    yield return indices.Select(idx => items[idx]).ToList();
                    weights[idxUpper]++;
                    idxUpper = 1;
                }
                else
                {
                    weights[idxUpper] = 0;
                    idxUpper++;
                }
            }
        }
    }
}
