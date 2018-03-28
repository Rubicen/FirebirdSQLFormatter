using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatSQLFirebird
{
    public static class StringExt
    {
        public static string Join(this IEnumerable<string> sequence, string joiner)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            foreach (string str in sequence)
            {
                if (flag)
                    stringBuilder.Append(joiner);
                else
                    flag = true;
                stringBuilder.Append(str);
            }
            return stringBuilder.ToString();
        }
    }
}
