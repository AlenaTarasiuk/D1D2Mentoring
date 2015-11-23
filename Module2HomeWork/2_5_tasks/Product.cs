using System;

namespace Module2HomeWork._2_5_tasks
{
    abstract class Product
    {
        protected string producerItem;
        protected int priceItem;
        protected string nameItem;
        protected int value;

        virtual public string getItem()
        {
            return producerItem;
        }

        virtual public void setPrice(int price)
        {
            priceItem = price;
        }

        virtual public void setNameItem(string name)
        {
            nameItem = name;
        }
    }
}
