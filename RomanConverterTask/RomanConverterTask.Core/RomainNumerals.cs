using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanConverterTask.Core
{
    public static class RomainNumerals
    {
        public static char[] OriginalSequenceSymbols => new char[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        public static readonly IRomainNumerals Original = new Implementation(OriginalSequenceSymbols);

        public static IRomainNumerals Create(params char[] increasingSequenceSymbols)
        {
            return new Implementation(increasingSequenceSymbols);
        }

        class Implementation : IRomainNumerals
        {
            private readonly char[] _symbols;
            private readonly IReadOnlyDictionary<char, int> _values;

            public Implementation(params char[] symbols)
            {
                _symbols = symbols;
                _values = symbols.ToDictionary(x => x, x => CalculateValue(x));
            }

            public bool CanSubtract(char subtrahend, char minuend)
            {
                var subtrahendIndex = Array.IndexOf(_symbols, subtrahend);
                var minuendIndex = Array.IndexOf(_symbols, minuend);

                if (subtrahendIndex == -1) throw new ArgumentOutOfRangeException(nameof(subtrahend), _symbols, string.Empty);
                if (minuendIndex == -1) throw new ArgumentOutOfRangeException(nameof(minuend), _symbols, string.Empty);

                if (minuendIndex % 2 != 0) return false;

                var range = subtrahendIndex - minuendIndex;
                return 0 < range && range < 3;
            }

            public bool IsPowerOfTen(char symbol)
            {
                var index = Array.IndexOf(_symbols, symbol);

                if (index == -1) throw new ArgumentOutOfRangeException(nameof(symbol), _symbols, string.Empty);

                return index % 2 == 0;
            }
            public int GetValue(char symbol)
            {
                return _values[symbol];
            }
            private int CalculateValue(char symbol)
            {
                var index = Array.IndexOf(_symbols, symbol);

                if (index == -1) throw new ArgumentOutOfRangeException(nameof(symbol), _symbols, string.Empty);

                var tens = 1;
                for (int i = 0; i < index / 2; i++)
                {
                    tens *= 10;
                }
                return IsPowerOfTen(symbol)
                    ? 1 * tens
                    : 5 * tens;
            }

            public bool IsMore(char left, char rigth)
            {
                return GetValue(left) > GetValue(rigth);
            }

            public bool IsLess(char left, char rigth)
            {
                return GetValue(left) < GetValue(rigth);
            }
        }
    }

    public interface IRomainNumerals
    {
        bool CanSubtract(char subtrahend, char minuend);
        bool IsPowerOfTen(char symbol);
        int GetValue(char symbol);
        bool IsMore(char left, char rigth);
        bool IsLess(char left, char rigth);
    }
}
