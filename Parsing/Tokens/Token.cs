using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public abstract class Token
    {
        // Properties
        public abstract string Value { get; }

        // Methods
        public override string ToString()
        {
            return this.Value;
        }
    }
}
