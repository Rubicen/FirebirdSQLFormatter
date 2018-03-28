using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parsing.Tokens;

namespace Parsing
{
    public static class Parser
    {
        public static IEnumerable<Token> ParseToTokens(string source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int index = 0;
            while (index < source.Length)
            {
                int endIndex;
                Token token;

                if (!TryParseToken(source, index, out endIndex, out token))
                    throw new Exception("Failed to parse token beginning at index " + index.ToString() + " (Char: '" + source[index] + "')");

                yield return token;
                index = endIndex;
            }
        }

        public static bool TryParseToken(string source, int startIndex, out int endIndex, out Token token)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return
                AlphaNumericToken.TryParse(source, startIndex, out endIndex, out token) ||
                
                WhitespaceToken.TryParse(source, startIndex, out endIndex, out token) ||
                StringToken.TryParse(source, startIndex, out endIndex, out token) ||
                MultilineStringToken.TryParse(source, startIndex, out endIndex, out token) ||
                BlockCommentToken.TryParse(source, startIndex, out endIndex, out token) ||
                LineCommentToken.TryParse(source, startIndex, out endIndex, out token) ||
                CharToken.TryParse(source, startIndex, out endIndex, out token) ||
                SymbolToken.TryParse(source, startIndex, out endIndex, out token);
        }
    }
}
