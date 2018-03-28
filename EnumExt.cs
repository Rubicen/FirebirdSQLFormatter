using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatSQLFirebird
{
    public static class EnumExt
    {
        public static bool HasAll(this StringConvertingOptions en, StringConvertingOptions flags)
        {
            return (en & flags) == flags;
        }

        public static bool HasAny(this StringConvertingOptions en, StringConvertingOptions flags)
        {
            return (en & flags) != StringConvertingOptions.None;
        }
    }
}
