using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DB.Entities
{
    [Table("Order Details")]
    public class OrderDetail
    {
        private EntityRef<Order> order = new EntityRef<Order>();
        private EntityRef<Product> product = new EntityRef<Product>();

        [Association(Storage="order", ThisKey="OrderID", OtherKey="OrderID")]
        public Order Order
        {
            get { return order.Entity; }
            set { order.Entity = value; }
        }

        [Association(Storage="product", ThisKey="ProductID", OtherKey="ProductID")]
        public Product Product
        {
            get { return product.Entity; }
            set { product.Entity = value; }
        }

        [Column, NotNull]
        public decimal UnitPrice { get; set; }

        [Column, NotNull]
        public Int16 Quantity { get; set; }

        [Column, NotNull]
        public Single Discount { get; set; }

        [Column, NotNull, PrimaryKey]
        public int? OrderID;

        [Column, NotNull, PrimaryKey]
        public int? ProductID;
    }
}
