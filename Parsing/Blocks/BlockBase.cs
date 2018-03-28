using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parsing.Tokens;

namespace Parsing.Blocks
{
    public abstract class BlockBase : Block
    {
        public override IEnumerable<LinkedListNode<Token>> TokenNodes
        {
            get { return _tokens; }
        }

        private readonly LinkedListNode<Token>[] _tokens;

        protected BlockBase(IEnumerable<LinkedListNode<Token>> tokens)
        {
            _tokens = tokens.ToArray();
        }
    }
}
