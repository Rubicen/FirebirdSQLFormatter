using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsing.Tokens
{
    public abstract class CommentToken : TokenBase
    {
        protected CommentToken(string value)
            : base(value)
        {
        }
    }
}
