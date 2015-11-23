using System;

namespace Module2HomeWork
{
    class Key : IOpenDoor
    {
        public Key()
        {  }
        
        public void Open(bool flag)
        {
            if (flag)
                Console.WriteLine("The door was open key.");
            else
                Console.WriteLine("The door close!"); 
        }
    }
}
