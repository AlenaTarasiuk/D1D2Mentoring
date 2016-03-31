using System;

namespace ProjectDAL
{
    public class Details
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }
        public Single Discount { get; set; }
        public string ProductName { get; set; }
    }
}
