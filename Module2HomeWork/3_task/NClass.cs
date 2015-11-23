using System;

namespace Module2HomeWork
{
    class ClassA
    {
        public ClassA()
        {
            Console.WriteLine("\n\nclassA");
        }

        public class NestedClass
        {
            public NestedClass()
            {
                System.Console.WriteLine("nested class");
            }
        }
    }
}