using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public class BlockCommentToken : CommentToken
    {
        // Constructor
        protected BlockCommentToken(string value)
            : base(value)
        {
        }

        // Static
        public static bool TryParse(string text, int startIndex, out int endIndex, out Token token)
        {
            if (text[startIndex] == '{')
            {
                endIndex = startIndex + 1;
                while (endIndex < text.Length)
                {
                    if (text[endIndex] == '}')
                    {
                        endIndex += 1;
                        token = new BlockCommentToken(text.Substring(startIndex, endIndex - startIndex));
                        return true;
                    }

                    endIndex++;
                }

                throw new Exception("Unterminated block comment at index " + startIndex.ToString());
            }

            endIndex = startIndex;
            token = null;
            return false;
        }
    }
}
