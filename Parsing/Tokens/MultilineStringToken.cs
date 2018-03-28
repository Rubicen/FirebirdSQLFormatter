using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public class MultilineStringToken : TokenBase
    {
        // Const
        protected const char APOS = '`';

        // Constructor
        protected MultilineStringToken(string value)
            : base(value)
        {
        }

        // Static
        public static bool TryParse(string text, int startIndex, out int endIndex, out Token token)
        {
            if (text[startIndex] == APOS)
            {
                endIndex = startIndex + 1;
                while (endIndex < text.Length)
                {
                    if (text[endIndex] == APOS)
                    {
                        if ((endIndex + 1 < text.Length) && (text[endIndex + 1] == APOS))
                        {
                            endIndex += 2; // Skip over the escaped quote
                        }
                        else
                        {
                            endIndex += 1;
                            token = new MultilineStringToken(text.Substring(startIndex, endIndex - startIndex));
                            return true;
                        }
                    }
                    else
                    {
                        endIndex += 1;
                    }
                }

                throw new Exception("Unterminated multiline string at index " + startIndex.ToString());
            }

            endIndex = startIndex;
            token = null;
            return false;
        }
    }
}
