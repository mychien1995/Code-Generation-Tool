using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Engine.Extensions
{
    public static class StringExtensions
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            List<int> indexes = new List<int>();
            if (String.IsNullOrEmpty(value))
                return indexes;
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        public static string GetPropertiesLoopContent(this string str, int loopIndex)
        {
            bool start = false;
            StringBuilder content = new StringBuilder();
            for (int i = loopIndex; i < str.Length; i++)
            {
                if (str[i] == '$' && !start)
                {
                    start = true;
                    continue;
                }
                if (str[i] == '$' && start)
                {
                    return content.ToString();
                }
                if (start)
                {
                    content.Append(str[i]);
                }
            }
            return string.Empty;
        }

        public static string RemoveUntil(this string str, int startIndex, char until, int appearance)
        {
            int count = 0;
            StringBuilder s = new StringBuilder(str);
            for (int i = startIndex; i < str.Length; i++)
            {
                s.Remove(startIndex, 1);
                if (str[i] == until)
                {
                    count++;
                }
                if (count == appearance) return s.ToString();
            }
            return string.Empty;
        }
    }
}
