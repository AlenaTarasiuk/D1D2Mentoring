using System;
using System.Collections;
using System.Collections.Generic;

namespace Module7HomeWork
{
    public class task1
    {
        public static IList CreateAndFillList()
        {
            IList list = MakeList(typeof(int));
            list.Add(14);
            list.Add(33);
            list.Add(8);
            list.Add(54);
            list.Add(1);
            return list;
        }

        private static IList MakeList(Type type)
        {
            return (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
        }
    }
}
