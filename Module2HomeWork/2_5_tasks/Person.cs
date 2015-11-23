using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HomeWork._2_5_tasks
{
    class Person : CartOnlineShop
    {
        public Dictionary<string, int> dictionary = new Dictionary<string, int>();

        public override Product CreateProduct(string name, int price)
        {
            Product p = new Widget(id++);

            dictionary.Add(name, price);
            p.setPrice(price);
            p.setNameItem(name);

            return p;
        }

        public override int CountTotalAmountOrder()
        {
            return dictionary.Values.Sum();
        }

        public override void RemoveItem(string name)
        {
            dictionary.Remove(name);
        }
    }
}
