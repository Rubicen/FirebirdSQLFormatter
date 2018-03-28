using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public class AlphaNumericToken : TokenBase
    {
        // Constructor
        public AlphaNumericToken(string value)
            : base(value)
        {
        }

        // Static
        private static bool GetIsValidWordCharacter(char c)
        {
            return ((c >= 'A') && (c <= 'Z'))
                || ((c >= 'a') && (c <= 'z'))
                || ((c >= '1') && (c <= '9'))
                || (c == '0')
                || (c == '_');
        }

        public static bool TryParse(string text, int startIndex, out int endIndex, out Token token)
        {
            if (GetIsValidWordCharacter(text[startIndex]))
            {
                endIndex = startIndex + 1;
                while ((endIndex < text.Length) && GetIsValidWordCharacter(text[endIndex]))
                    endIndex++;

                token = new AlphaNumericToken(text.Substring(startIndex, endIndex - startIndex));
                return true;
            }

            endIndex = startIndex;
            token = null;
            return false;
        }
    }
}
