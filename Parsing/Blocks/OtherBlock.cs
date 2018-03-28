using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parsing;
using Parsing.Tokens;

namespace Parsing.Blocks
{
    public class OtherBlock : BlockBase
    {
        protected OtherBlock(IEnumerable<LinkedListNode<Token>> tokens)
            : base(tokens)
        {
        }

        private static bool IsNodeAnOtherNode(LinkedListNode<Token> node)
        {
            return !((node.Value is AlphaNumericToken) && (node.Value.Value.ToLower() == "procedure" || node.Value.Value.ToLower() == "function"));
        }

        public static bool TryParse(LinkedListNode<Token> startNode, out LinkedListNode<Token> endNode, out Block block)
        {
            if (IsNodeAnOtherNode(startNode))
            {
                List<LinkedListNode<Token>> blockTokens = new List<LinkedListNode<Token>>(new LinkedListNode<Token>[] { startNode });

                endNode = startNode.Next;
                while ((endNode != null) && IsNodeAnOtherNode(endNode))
                {
                    blockTokens.Add(endNode);
                    endNode = endNode.Next;
                }

                block = new OtherBlock(blockTokens);
                return true;
            }

            endNode = startNode;
            block = null;
            return false;
        }
    }
}
