
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace katas
{
    public class Kata
    {
        public static long NextSmaller(long n)
        {
            var result = n.ToString().NextSmaller(n.ToString().Length);
            return result;
        }
    }

    public static class longExtensions
    {
        public static long NextSmaller(this string number, int lenght)
        {
            int i, j;

            // I) Start from the right most digit 
            // and find the first digit that is 
            // smaller than the digit next to it. 
            for (i = lenght - 1; i > 0; i--)
                if (number[i] < number[i - 1])
                    break;

            // If no such digit is found 
            // then all digits are in ascending order 
            // means there cannot be a smallest number 
            // with same set of digits 
            if (i == 0)
            {
                return -1;
            }

            // II) Find the greatest digit on 
            // right side of (i-1)'th digit that is 
            // smaller than number[i-1] 
            int x = number[i - 1], greatest = i;
            for (j = i; j < lenght; j++)
                if (number[j] < x && number[j] > number[greatest])
                    greatest = j;


            // III) Swap the above found smallest digit with number[i-1] 
            var result = SwapCharacters(number, greatest, i - 1);

            // IV) Sort the digits after (i-1) in descending order 
            var sortedResult = Sort(result, i);

            if (sortedResult.StartsWith("0"))
                return -1;

            return long.Parse(sortedResult);
        }

        private static string Sort(string number, int index)
        {
            char[] array = number.ToArray();
            char[] part = new char[array.Length - index];
            char[] front = new char[index];
            Array.Copy(array, 0, front, 0, index);
            Array.Copy(array, index, part, 0, array.Length - index);
            var sorted = part.OrderByDescending(c => c).ToArray();
            var result = $"{new string(front)}{new string(sorted)}";
            return result;
        }

        private static string SwapCharacters(string value, int position1, int position2)
        {
            char[] array = value.ToCharArray();
            char temp = array[position1];
            array[position1] = array[position2];
            array[position2] = temp;
            return new string(array);
        }
    }
    public class CompareDescending : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            if (x > y) return 0;
            else return -1;
        }
    }


}
