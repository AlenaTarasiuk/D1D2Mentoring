using System;

namespace Module2HomeWork
{
    class MetalKey : Key
    {
        public void Open(bool flag)
        {
            if (flag)
                Console.WriteLine("The door was open metal key.");
            else
                Console.WriteLine("The door close!");
        }
    }
}
