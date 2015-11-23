using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HomeWork._2_5_tasks
{
    abstract class CartOnlineShop
    {
        protected static int id = 0;
        virtual public Product CreateProduct(string name, int price)
        {
            return null;
        }

        virtual public int CountTotalAmountOrder()
        {
            return 0;
        }

        virtual public void RemoveItem(string name)
        { }

    }
}
