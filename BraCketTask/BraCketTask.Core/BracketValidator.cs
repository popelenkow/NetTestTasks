using System;
using System.Collections.Generic;
using System.Text;

namespace BraCketTask.Core
{
    public static class BracketValidator
    {
        public static bool Validate(string value, char bra, char cket)
        {
            int counter = 0;
            foreach (var element in value)
            {
                if (bra == element) counter++;
                else if (cket == element) counter--;
                if (counter < 0) return false;
            }
            return counter == 0;
        }
    }
}
