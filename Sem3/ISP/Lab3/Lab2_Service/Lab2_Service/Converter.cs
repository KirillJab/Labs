using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab3
{
    public static class Converter
    {
        static List<string> SplitJSON(string json)
        {
            var list = new List<string>();
            int bracketsCount = 0;
            var line = new StringBuilder();

            json = json.Trim(new char[] { '{', ' ', '}' });
            foreach (char ch in json)
            {
                if (char.IsLetterOrDigit(ch) || char.IsPunctuation(ch))
                {
                    if ((ch == ',') && (bracketsCount == 0))
                    {

                        list.Add(line.ToString());
                        line.Clear();
                    }
                    else
                    {
                        if (ch == '{')
                        {
                            line.Append(ch);
                            bracketsCount++;
                        }
                        else
                        {
                            if (ch == '}')
                            {
                                line.Append(ch);
                                bracketsCount--;
                            }
                            else
                            {
                                line.Append(ch);
                            }
                        }
                    }
                }
            }
            if (list.Count != 0)
            {
                list.Add(line.ToString());
            }
            return list;
        }

        public static T DeserializeJSON<T>(string input) where T : new()
        {
            Type type = typeof(T);
            T res = new T();
            List<string> list = SplitJSON(input);
            string key;
            string value;
            string complexPattern = @"(\w+)\s*:\s*{(.*)}";
            string simplePattern = @"(\w+)\s*:\s*(.*)";
            Regex complexRgx = new Regex(complexPattern, RegexOptions.Singleline);
            Regex simpleRgx = new Regex(simplePattern, RegexOptions.Singleline);
            Match match;

            foreach (string prop in list)
            {
                match = complexRgx.Match(prop);
                if (match.Success)
                {
                    key = match.Groups[1].ToString();
                    value = match.Groups[2].ToString();
                    System.Reflection.FieldInfo info = type.GetField(key);
                    info.SetValue(res, typeof(Converter).GetMethod("Deserialize").MakeGenericMethod(new Type[] { info.FieldType }).Invoke(null, new object[] { value }));
                }
                else
                {
                    match = simpleRgx.Match(prop);
                    if (match.Success)
                    {
                        key = match.Groups[1].Value;
                        value = match.Groups[2].Value;

                        System.Reflection.FieldInfo info = type.GetField(key);
                        info.SetValue(res, Convert.ChangeType(value, info.FieldType));
                    }
                }
            }
            return res;
        }
    }
}
