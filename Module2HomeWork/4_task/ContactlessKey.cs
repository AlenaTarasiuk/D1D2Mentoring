using System;

namespace Module2HomeWork
{
    class ContactlessKey : Key
    {
        public void Open(bool flag)
        {
            if (flag)
                Console.WriteLine("The door was open contactless key.");
            else
                Console.WriteLine("The door close!");
        }
    }
}
