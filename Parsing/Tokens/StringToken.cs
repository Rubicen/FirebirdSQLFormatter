using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public class StringToken : TokenBase
    {
        // Const
        protected const char SINGLEQUOTE = '\'';

        // Constructor
        public StringToken(string value)
            : base(value)
        {
        }

        // Static
        public static bool TryParse(string text, int startIndex, out int endIndex, out Token token)
        {
            if (text[startIndex] == SINGLEQUOTE)
            {
                endIndex = startIndex + 1;
                while (endIndex < text.Length)
                {
                    if (text[endIndex] == SINGLEQUOTE)
                    {
                        if ((endIndex + 1 < text.Length) && (text[endIndex + 1] == SINGLEQUOTE))
                        {
                            endIndex += 2; // Skip over the escaped quote
                        }
                        else
                        {
                            endIndex += 1;
                            token = new StringToken(text.Substring(startIndex, endIndex - startIndex));
                            return true;
                        }
                    }
                    else
                    {
                        endIndex += 1;
                    }
                }

                throw new Exception("Unterminated string at index " + startIndex.ToString());
            }

            endIndex = startIndex;
            token = null;
            return false;
        }
    }
}
