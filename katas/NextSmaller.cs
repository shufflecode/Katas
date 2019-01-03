
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace katas
{
    public class NextSmallerKata
    {
        public static long NextSmaller(long n)
        {
            var sum1 = QuerSumme(n);
            var digits = new List<int>();

            while (n % 10 >= 0)
            {
                var number = n % 10;

                n = n - number;

                if (number == 0)
                {
                    number = n / 10;
                    digits.Add((int)number);
                }
                else
                {
                    digits.Add((int)number);
                }
            }

            long sum = 0;
            digits.ForEach(d =>
            {
                sum += d;
            });

            while (n > 0)
            {
                n--;
                var quer = QuerSumme(n);
                if (sum1 == quer)
                {
                    return sum1;
                }
            }

            return 0;
        }

        public static long QuerSumme(long input)
        {
            long prüfSumme = 0;
            do
            {
                prüfSumme += input % 10;
                input /= 10;
            } while (input > 0);
            return prüfSumme;
        }

    }
}
