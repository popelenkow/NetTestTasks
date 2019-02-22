using System;
using System.Collections.Generic;

namespace RomanConverterTask.Core
{
    public static class RomanConverter
    {
        public static int RomanToInt(string roman)
        {
           
            var minuendIndexes = GetMinuendIndexes(roman);
            CkeckRepeat(roman, minuendIndexes);
            CkeckDescending(roman, minuendIndexes);
            var value = Calculate(roman, minuendIndexes);
            if (value > 3000) throw new MaxValueException(3000, roman);
            return value;
        }
        private static int Calculate(string roman, List<int> minuendIndexes)
        {
            var acc = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                var sing = !minuendIndexes.Contains(i)
                    ? 1
                    : -1;
                acc += sing*RomainNumerals.Original.GetValue(roman[i]);
            }
            return acc;
        }
        private static List<int> GetMinuendIndexes(string roman)
        {
            var minuendIndexes = new List<int>();
            for (int i = 1; i < roman.Length; i++)
            {
                var cur = roman[i];
                var prev = roman[i - 1];
                if (RomainNumerals.Original.IsMore(cur, prev))
                {
                    if (!RomainNumerals.Original.CanSubtract(cur, prev))
                    {
                        throw new SubtractException($"Must't {cur} minus {prev}", i - 1, roman);
                    }
                    else if (i - 2 != -1 && RomainNumerals.Original.IsMore(cur, roman[i - 2]))
                    {
                        throw new SubtractException($"Must't twice subtract", i - 1, roman);
                    }
                        else if (roman.Length != i + 1 && !RomainNumerals.Original.IsMore(prev, roman[i + 1]))
                    {
                        throw new SubtractException($"Must't subtract previous two more numbers", i - 1, roman);
                    }
                    else
                    {
                        minuendIndexes.Add(i - 1);
                    }
                }
            }
            return minuendIndexes;
        }
        private static void CkeckRepeat(string roman, List<int> minuendIndexes)
        {
            if (roman.Length < 2) return;
            var counter = 0;
            var canRepeat = false;
            var prevSymbol = null as char?;
            for (int i = 0; i < roman.Length; i++)
            {
                if (!minuendIndexes.Contains(i))
                {
                    var cur = roman[i];
                    if (prevSymbol == cur)
                    {
                        if (!canRepeat || (counter == 3 && !minuendIndexes.Contains(i-1)))
                        {
                            throw new RepeatException(i, roman);
                        }
                        counter++;
                    }
                    else
                    {
                        counter = 1;
                        prevSymbol = cur;
                        canRepeat = RomainNumerals.Original.IsPowerOfTen(cur);
                    }
                }

               
            }
        }
        private static void CkeckDescending(string roman, List<int> minuendIndexes)
        {
            for (int i = 1; i < roman.Length; i++)
            {
                if (minuendIndexes.Contains(i)) continue;
                if (i - 2 == -1 && minuendIndexes.Contains(i - 1)) continue;

                var cur = roman[i];
                var prevIndex = !minuendIndexes.Contains(i-1)
                    ? i - 1
                    : i - 2;
                var prev = roman[prevIndex];
                if (RomainNumerals.Original.IsMore(cur, prev))
                {
                    throw new ValueDescendingException(prevIndex, roman);
                }
            }
        }
        
    }

    public class RepeatException : Exception
    {
        public RepeatException(int index, string roman) : base($"Limit is exceeded\r\nPosition {index} of {roman}")
        {
        }
    }

    public class SubtractException : Exception
    {
        public SubtractException(string message, int index, string roman) : base($"{message}\r\nPosition {index} of {roman}")
        {
        }
    }

    public class ValueDescendingException : Exception
    {
        public ValueDescendingException(int index, string roman) : base($"Value is not descending\r\nPosition {index} of {roman}")
        {
        }
    }

    public class MaxValueException : Exception
    {
        public MaxValueException(int value, string roman) : base($"Reached limit of {value} by {roman}")
        {
        }
    }

}
