using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ExtensionMethod
{
    public sealed class STringOperation
    {
        public int GetLength(string str)
        {
            return str.Length;
        }

        public string ChangeCase(string str, char c)
        {
            if (c == 'l') return str.ToLower();
            if (c == 'u') return str.ToUpper();
            return str;
        }
    }

    public static class StringExtensions
    {
        public static string ReverseString(this STringOperation op, string str)
        {
            string reverse = String.Empty;
            for (var i = str.Length-1; i >= 0; i--)
            {
                reverse += str[i];
            }
            return reverse;
        }

        public static string ReverseExt(this string str)
        {
            string reverse = String.Empty;
            for (var i = str.Length - 1; i >= 0; i--)
            {
                reverse += str[i];
            }
            return reverse;
        }

    }
}
