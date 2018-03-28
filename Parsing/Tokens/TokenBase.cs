using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public abstract class TokenBase : Token
    {
        // Properties
        public override string Value { get { return _value; } }

        // Var
        private readonly string _value;

        // Constructor
        public TokenBase(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            _value = value;
        }
    }
}
