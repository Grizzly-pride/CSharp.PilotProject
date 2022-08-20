using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject
{
    public static class StringMod
    {
        public static object StringCut(this string str, int value)
        {
            return
                value > 3 && str.Length > value ?
                str.Substring(0, value - 3) + "..." : str;
        }
    }
}
