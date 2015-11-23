using System;

namespace Module2HomeWork
{
    class MagneticCard : Key
    {
        public void Open(bool flag)
        {
            if (flag)
                Console.WriteLine("The door was open magnetic card.");
            else
                Console.WriteLine("The door close!"); 
        }
    }
}
