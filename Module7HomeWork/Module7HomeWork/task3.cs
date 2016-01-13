using System;
using System.Collections;
using System.Collections.Generic;

namespace Module7HomeWork
{
    public class task3
    {
        public static IDictionary CreateAndFillDictionary()
        {
            IDictionary dictionary = MakeDictionary(typeof(int), typeof(string));
            dictionary.Add(14, "ds");
            dictionary.Add(33, "sd");
            dictionary.Add(8, "qa");
            dictionary.Add(54, "io");
            dictionary.Add(1, "qw");
            dictionary.Add(3, "sd");
            dictionary.Add(84, "qa");
            dictionary.Add(52, "io");
            dictionary.Add(9, "qw");
            return dictionary;
        }

        private static IDictionary MakeDictionary(Type TKey, Type TValue)
        {
            return (IDictionary)Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(TKey, TValue));
        }
    }
}
