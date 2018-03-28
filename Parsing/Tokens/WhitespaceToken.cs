using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public class WhitespaceToken : Token //Base
    {
        // IsWhitespaceCache
        // private static readonly bool[] _IsWhiteSpace = Enumerable.Range(0, 255).Select(i => char.IsWhiteSpace((char)i)).ToArray();

        // Properties
        public override string Value
        {
            get { return _value; }
        }

        // Var
        private readonly string _value;

        // Constructor
        public WhitespaceToken(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            _value = value;
        }

        // Static
        public static bool TryParse(string text, int startIndex, out int endIndex, out Token token)
        {
            if (char.IsWhiteSpace(text[startIndex])) // _IsWhiteSpace[text[startIndex]]
            {
                endIndex = startIndex + 1;
                while ((endIndex < text.Length) && char.IsWhiteSpace(text[endIndex])) // _IsWhiteSpace[text[endIndex]]
                    endIndex++;

                token = new WhitespaceToken(text.Substring(startIndex, endIndex - startIndex));
                return true;
            }

            endIndex = startIndex;
            token = null;
            return false;
        }
    }
}
