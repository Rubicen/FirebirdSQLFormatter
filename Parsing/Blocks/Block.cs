using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parsing.Tokens;

namespace Parsing.Blocks
{
    public abstract class Block
    {
        public abstract IEnumerable<LinkedListNode<Token>> TokenNodes { get; }
    }
}
