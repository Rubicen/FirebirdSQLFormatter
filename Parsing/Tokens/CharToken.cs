using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public class CharToken : TokenBase
    {
        // Constructor
        public CharToken(string value)
            : base(value)
        {
        }

        // Static
        public static bool TryParse(string text, int startIndex, out int endIndex, out Token token)
        {
            if (text[startIndex] == '#')
            {
                endIndex = startIndex + 1;
                while ((endIndex < text.Length) && char.IsNumber(text[endIndex]))
                    endIndex++;

                token = new CharToken(text.Substring(startIndex, endIndex - startIndex));
                return true;
            }

            endIndex = startIndex;
            token = null;
            return false;
        }
    }
}
