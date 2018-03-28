using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public class SymbolToken : Token 
    {
        // Static
        protected static readonly char[] _symbols = new char[] {
            '+', '-', '*', '/', '^', // Operations
            '=', '<', '>', // Relations
            '#', ':', ';', '.', ',', // Misc
            '(', ')', '[', ']' }; // Brackets

        protected static readonly bool[] _isSymbol;

        static SymbolToken()
        {
            _isSymbol = new bool[256];
            
            // Operations
            _isSymbol['+'] = true;
            _isSymbol['-'] = true;
            _isSymbol['*'] = true;
            _isSymbol['/'] = true;
            _isSymbol['^'] = true;

            // Relations
            _isSymbol['='] = true;
            _isSymbol['<'] = true;
            _isSymbol['>'] = true;

            // Brackets
            _isSymbol['('] = true;
            _isSymbol[')'] = true;
            _isSymbol['['] = true;
            _isSymbol[']'] = true;

            // Misc
            _isSymbol['#'] = true;
            _isSymbol[':'] = true;
            _isSymbol[';'] = true;
            _isSymbol['.'] = true;
            _isSymbol[','] = true;
        }

        // Properties
        public override string Value
        {
            get { return _value; }
        }

        // Var
        private readonly string _value;

        // Constructor
        public SymbolToken(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            _value = value;
        }

        public static bool TryParse(string text, int startIndex, out int endIndex, out Token token)
        {
            if (_isSymbol[text[startIndex]]) // _symbols.Contains(text[startIndex]))
            {
                endIndex = startIndex + 1;
                token = new SymbolToken(text.Substring(startIndex, endIndex - startIndex)); // Oddly not much slower than [].ToString() on the single char.
                return true;
            }

            endIndex = startIndex;
            token = null;
            return false;
        }
    }
}
