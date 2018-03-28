// Decompiled with JetBrains decompiler
// Type: Ostendo_String_Parse.StringConverting
// Assembly: Ostendo String Parse, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 581EDD5F-9B22-4BAD-8139-1131ADB4C8B2
// Assembly location: C:\Users\logan\Documents\Ostendo String Parse.exe

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Forms;

namespace FormatSQLFirebird
{
    public static class StringConverting
    {
        private static readonly Regex _stringRegex = new Regex("'([^']*(''[^']*)*)'", RegexOptions.Compiled);
        private static readonly Regex _charRegex = new Regex("#(\\d+)", RegexOptions.Compiled);
        private static int level = 0;
        

        public static List<LinkedListNode<Parsing.Tokens.Token>> GetFormattedCodeFromString(LinkedListNode<Parsing.Tokens.Token> startNode, out LinkedListNode<Parsing.Tokens.Token> endNode)
        {
            bool betweenSelectAndFrom = false;
            level++;
            //            var regex = new Regex(@"
            //    \(                    # Match (
            //    (
            //        [^()]+            # all chars except ()
            //        | (?<Level>\()    # or if ( then Level += 1
            //        | (?<-Level>\))   # or if ) then Level -= 1
            //    )+                    # Repeat (to go from inside to outside)
            //    (?(Level)(?!))        # zero-width negative lookahead assertion
            //    \)                    # Match )",
            //                RegexOptions.None);
            //
            //            foreach (Match c in regex.Matches(input))
            //            {
            //                MessageBox.Show(c.Value.Trim('(', ')'));
            //            }
            //First, remove all formatting from the thing. Separate all by just spaces, no return characters at all.
            //Decide if sql, procedure/trigger
            //Second, group it by separate select statements 
            List<LinkedListNode<Parsing.Tokens.Token>> blockTokens = new List<LinkedListNode<Parsing.Tokens.Token>>(new LinkedListNode<Parsing.Tokens.Token>[] { startNode });
            string test = "";
            //MessageBox.Show(test);
            int depth = 0;

            if (startNode.Value.Value.ToLower() == "select")
                betweenSelectAndFrom = true;
            endNode = startNode;

            LinkedListNode<Parsing.Tokens.Token> newFirstNode = startNode.Next;

            bool enteredBody = false;
            bool done = false;
            int index = 0;
            string tempString = "";
            while (!done)
            {
                tempString = "";
                if (endNode == null)
                    break;
                endNode = endNode.Next;
                if (endNode == null)
                {
                    if (depth > 1)
                        throw new Exception("End of tokens reached while parsing function (likely too many '(' )");
                    else
                        break;
                }

                if (endNode.Value is Parsing.Tokens.SymbolToken)
                {
                    switch (endNode.Value.Value.ToLower())
                    {
                        case "(":
                            level++;
                            newFirstNode = endNode;
                            depth += 1;
                            enteredBody = true;
                            for (int i = 0; i < level-1; i++)
                                tempString += "    ";
                            blockTokens[0].List.AddAfter(newFirstNode, new Parsing.Tokens.StringToken(tempString));
                            blockTokens[0].List.AddAfter(newFirstNode, new Parsing.Tokens.StringToken("\n"));
                            //blockTokens[1].List.AddBefore(endNode, new Parsing.Tokens.StringToken("\n"));
                            GetFormattedCodeFromString(newFirstNode, out endNode).ForEach(r=>blockTokens.Add(r));
                            break;
                        case ")":
                            level--;
                            blockTokens.Add(endNode);
                            depth -= 1;
                            for (int i = 0; i < level-1; i++)
                                tempString += "    ";
                            blockTokens[0].List.AddAfter(newFirstNode, new Parsing.Tokens.StringToken(tempString));
                            blockTokens[0].List.AddAfter(endNode, new Parsing.Tokens.StringToken("\n"));
                            if (level > 1 && depth < 0)
                            {
                                done = true;
                                break;
                            }
                            else if (enteredBody && depth == 0)
                            {
                                done = true;
                            }
                            else if (depth < 0)
                            {
                                throw new IndexOutOfRangeException("depth<0 error");
                            }
                            break;
                        case ",":
                            blockTokens.Add(endNode);
                            for (int i = 0; i < level - 1 + (betweenSelectAndFrom? 1 : 0); i++)
                                tempString += "    ";
                            blockTokens[0].List.AddAfter(endNode, new Parsing.Tokens.StringToken(tempString));
                            blockTokens[0].List.AddAfter(endNode, new Parsing.Tokens.StringToken("\n"));
                            break;
                        default:
                            blockTokens.Add(endNode);
                            break;
                    }
                }
                else if(endNode.Value.Value.ToLower() == "select")
                {
                    betweenSelectAndFrom = true;
                    blockTokens.Add(endNode);
                    for (int i = 0; i < level - 1; i++)
                        tempString += "    ";
                    blockTokens[0].List.AddAfter(endNode, new Parsing.Tokens.StringToken(tempString));
                    blockTokens[0].List.AddAfter(endNode, new Parsing.Tokens.StringToken("\n"));
                }
                else if(endNode.Value.Value.ToLower() == "from")
                {
                    blockTokens.Add(endNode);
                    for (int i = 0; i < level - 1; i++)
                        tempString += "    ";
                    blockTokens[0].List.AddAfter(endNode, new Parsing.Tokens.StringToken(tempString));
                    blockTokens[0].List.AddAfter(endNode, new Parsing.Tokens.StringToken("\n"));
                    betweenSelectAndFrom = false;
                }
                else if(endNode != null && endNode.GetType() == typeof(Parsing.Tokens.WhitespaceToken))
                {

                }
                else
                {
                    blockTokens.Add(endNode);
                }
                if (endNode != null && endNode.GetType() != typeof(Parsing.Tokens.WhitespaceToken))
                {
                    blockTokens[0].List.AddAfter(endNode, new Parsing.Tokens.StringToken(" "));
                    endNode = endNode.Next;
                }
            }
            //holderString = holderString + "|";
            foreach (var s in blockTokens)
            {
                test += s.Value;
            }
            Console.WriteLine(test);
            Console.WriteLine("" + level);
            if (level <= 0 && startNode.List.Last != endNode)
                throw new IndexOutOfRangeException("too many ')'");
            return blockTokens;
        }
        public static string AttemptRecursive(string input, out int increment)
        {
            increment = 0;
            string outputString = "";
            bool done = false;
            LinkedList<Parsing.Tokens.Token> list = new LinkedList<Parsing.Tokens.Token>(Parsing.Parser.ParseToTokens(input));
            LinkedListNode<Parsing.Tokens.Token> endNode = list.First;
            while (!done)
            {
                endNode = endNode.Next;
                if (endNode == null)
                {
                    //if (level != 1)
                    //    throw new Exception("End of tokens reached while parsing function (likely too many '(' )");
                    //else
                        break;
                }
                increment += 1;
                if (endNode.Value is Parsing.Tokens.SymbolToken)
                {
                    if (endNode.Value.Value == "(")
                    {
                        int temp;
                        outputString += endNode.Value.Value;
                        outputString += AttemptRecursive(input.Substring(increment, input.Length - increment), out temp);
                        increment += temp;
                    }
                    else if (endNode.Value.Value == ")")
                    {
                        outputString += endNode.Value.Value;
                        break;
                    }
                    else
                        outputString += endNode.Value.Value;
                }
                else
                {
                    outputString += endNode.Value.Value;
                }
            }
            return outputString;
        }
        public static void ResetConverter()
        {
            level = 0;
        }
        public static string GetPascalCodeForString(string input, StringConvertingOptions options)
        {

            bool flag1 = options.HasAny(StringConvertingOptions.OneLineOutput);
            bool flag2 = options.HasAny(StringConvertingOptions.TrimInputLines);
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArray = input.Split(new string[3]
            {
        "\r\n",
        "\r",
        "\n"
            }, StringSplitOptions.None);
            for (int index = 0; index < strArray.Length; ++index)
            {
                string str = strArray[index];
                if (flag2)
                    str = str.Trim();
                if (str != "")
                {
                    if (index > 0 && !flag1)
                        stringBuilder.Append(" +\r\n");
                    stringBuilder.Append("'");
                    stringBuilder.Append(str.Replace("'", "''"));
                    stringBuilder.Append("'");
                    if (index < strArray.Length - 1)
                        stringBuilder.Append("#13#10");
                }
                else if (index < strArray.Length - 1)
                {
                    if (index > 0 && !flag1)
                        stringBuilder.Append(" +\r\n#13#10");
                    else
                        stringBuilder.Append("#13#10");
                }
            }
            return stringBuilder.ToString();
        }

        public static string GetStringFromPascalCode(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int startat = 0;
            while (startat < input.Length)
            {
                switch (input[startat])
                {
                    case '\'':
                        Match match1 = StringConverting._stringRegex.Match(input, startat);
                        if (!match1.Success)
                            throw new FormatException("Input contains an unterminated string at index " + startat.ToString());
                        stringBuilder.Append(match1.Groups[1].Value.Replace("''", "'"));
                        startat += match1.Length;
                        continue;
                    case '#':
                        Match match2 = StringConverting._charRegex.Match(input, startat);
                        if (!match2.Success)
                            throw new FormatException("Input contains an invalid char specifier at index " + startat.ToString());
                        stringBuilder.Append((char)int.Parse(match2.Groups[1].Value));
                        startat += match2.Length;
                        continue;
                    case ' ':
                    case '\t':
                    case '\r':
                    case '\n':
                    case '+':
                        ++startat;
                        continue;
                    default:
                        throw new FormatException("Unexpected character at index " + startat.ToString());
                }
            }
            return stringBuilder.ToString();
        }
    }
}
