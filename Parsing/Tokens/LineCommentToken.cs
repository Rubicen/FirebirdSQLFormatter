using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public class LineCommentToken : CommentToken
    {
        // Constructor
        protected LineCommentToken(string value)
            : base(value)
        {
        }

        // Static
        public static bool TryParse(string text, int startIndex, out int endIndex, out Token token)
        {
            if ((text[startIndex] == '/') && (startIndex + 1 < text.Length) && (text[startIndex + 1] == '/'))
            {
                endIndex = startIndex + 2;
                while ((endIndex < text.Length) && (text[endIndex] != '\r') && (text[endIndex] != '\n'))
                    endIndex++;

                token = new LineCommentToken(text.Substring(startIndex, endIndex - startIndex));
                return true;
            }

            endIndex = startIndex;
            token = null;
            return false;
        }
    }
}
