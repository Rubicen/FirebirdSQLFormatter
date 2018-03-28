using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parsing.Tokens;

namespace Parsing.Blocks
{
    public class FunctionBlock : BlockBase
    {
        public string Name { get { return _name; } }

        private readonly string _name;

        protected FunctionBlock(string name, IEnumerable<LinkedListNode<Token>> tokens)
            : base(tokens)
        {
            _name = name;
        }

        public static bool TryParse(LinkedListNode<Token> startNode, out LinkedListNode<Token> endNode, out Block block)
        {
            if ((startNode.Value is AlphaNumericToken) && (startNode.Value.Value.ToLower() == "procedure" || startNode.Value.Value.ToLower() == "function"))
            {
                // Init tokens for the block
                List<LinkedListNode<Token>> blockTokens = new List<LinkedListNode<Token>>(new LinkedListNode<Token>[] { startNode });
                
                // Function name
                string functionName = null;

                // Read the rest of the function
                int depth = 0;

                endNode = startNode;

                bool enteredBody = false;
                bool done = false;
                while (!done)
                {
                    endNode = endNode.Next;
                    if (endNode == null)
                        throw new Exception("End of tokens reached while parsing function");

                    if (endNode.Value is AlphaNumericToken)
                    {
                        if (functionName == null)
                            functionName = endNode.Value.Value;
                        else
                        {
                            switch (endNode.Value.Value.ToLower())
                            {
                                case "try":
                                case "case":
                                case "begin":
                                    depth += 1;
                                    enteredBody = true;
                                    break;
                                case "end":
                                    depth -= 1;
                                    if (depth < 0)
                                        throw new Exception("Depth<0 while parsing function " + functionName);
                                    break;
                            }
                        }
                    }
                    else if (endNode.Value is SymbolToken)
                    {
                        if (endNode.Value.Value == ";")
                            if (enteredBody && depth == 0)
                                done = true;
                    }
                    else
                    {
                        if (functionName == null && !(endNode.Value is WhitespaceToken))
                            throw new Exception("Found non-whitespace non-word token while searching for function name");
                    }

                    blockTokens.Add(endNode);
                }

                endNode = endNode.Next;
                block = new FunctionBlock(functionName, blockTokens);
                return true;
            }
            
            endNode = startNode;
            block = null;
            return false;
        }
    }
}
