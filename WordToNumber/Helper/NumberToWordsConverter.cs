using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordToNumber.Helper
{
    public static class NumberToWordsConverter
    {
        private static readonly string[] Units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static readonly string[] Teens = { "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] Tens = { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        private static readonly string[] IndianNumbering = { "", "Thousand", "Lakh", "Crore" };

        public static string ConvertToWords(long number)
        {
            if (number == 0)
            {
                return Units[0];
            }

            if (number < 0)
            {
                return "Negative " + ConvertToWords(-number);
            }

            int group = 0;
            string words = "";

            while (number > 0)
            {
                long part = number % 1000;

                if (part > 0)
                {
                    string partWords = ConvertThreeDigitGroup((int)part);
                    if (!string.IsNullOrEmpty(partWords))
                    {
                        if (!string.IsNullOrEmpty(words))
                        {
                            words = partWords + " " + IndianNumbering[group] + " " + words;
                        }
                        else
                        {
                            words = partWords;
                        }
                    }
                }

                number /= 1000;
                group++;
            }

            return words;
        }

        private static string ConvertThreeDigitGroup(int num)
        {
            string result = "";

            if (num >= 100)
            {
                result += Units[num / 100] + " Hundred";
                num %= 100;

                if (num > 0)
                {
                    result += " and ";
                }
            }

            if (num >= 20)
            {
                result += Tens[num / 10 - 1];

                if (num % 10 > 0)
                {
                    result += " " + Units[num % 10];
                }
            }
            else if (num >= 10)
            {
                result += Teens[num - 11];
            }
            else if (num > 0)
            {
                result += Units[num];
            }

            return result;
        }
    }

}
