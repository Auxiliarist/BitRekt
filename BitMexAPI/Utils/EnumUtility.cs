﻿using System;
using System.Linq;

namespace BitMexAPI.Utils
{
    public static class EnumUtility
    {
        public static string GetStringValue(this Enum e)
        {
            return e.GetAttribute<StringValue>().Value;
        }

        public static T GetAttribute<T>(this Enum e) where T : Attribute
        {
            return (T)e.GetType().GetFields().First(x => x.Name == e.ToString()).GetCustomAttributes(typeof(T), true)
                .First();
        }

        public static T GetFieldByStringValue<T>(this T t, string expected)
        {
            var fields = typeof(T).GetFields().ToList();

            foreach (var fieldInfo in fields)
            {
                var stringValueAttribute = (StringValue)fieldInfo.GetCustomAttributes(typeof(StringValue), true).FirstOrDefault();

                if (stringValueAttribute != null)
                {
                    if (stringValueAttribute.Value == expected)
                    {
                        return (T)fieldInfo.GetValue(t);
                    }
                }
            }

            return default(T);
        }

        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return Char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}