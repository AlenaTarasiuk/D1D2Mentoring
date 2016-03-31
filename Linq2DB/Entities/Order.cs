using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DB.Entities
{
    [Table("Orders")]
    public class Order
    {
        private EntityRef<Customer> customer = new EntityRef<Customer>();
        private EntityRef<Employee> employee = new EntityRef<Employee>();
        private EntityRef<Shipper> shipper = new EntityRef<Shipper>();

        [Association(Storage = "customer", ThisKey = "CustomerID", OtherKey = "CustomerID")]
        public Customer Customer
        {
            get { return customer.Entity; }
            set { customer.Entity = value; }
        }

        [Association(Storage = "employee", ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
        public Employee Employee
        {
            get { return employee.Entity; }
            set { employee.Entity = value; }
        }

        [Association(Storage = "shipper", ThisKey = "ShipVia", OtherKey = "ShipperID")]
        public Shipper Shipper
        {
            get { return shipper.Entity; }
            set { shipper.Entity = value; }
        }

        [PrimaryKey, Identity]
        public int OrderID { get; set; }

        [Column, Nullable]
        public DateTime OrderDate { get; set; }

        [Column, Nullable]
        public DateTime RequiredDate { get; set; }

        [Column, Nullable]
        public DateTime ShippedDate { get; set; }

        [Column, Nullable]
        public decimal Freight { get; set; }

        [Column, Nullable]
        public string ShipName { get; set; }

        [Column, Nullable]
        public string ShipAddress { get; set; }

        [Column, Nullable]
        public string ShipCity { get; set; }

        [Column, Nullable]
        public string ShipRegion { get; set; }

        [Column, Nullable]
        public string ShipPostalCode { get; set; }

        [Column, Nullable]
        public string ShipCountry { get; set; }

        [Column, Nullable]
        public string CustomerID;

        [Column, Nullable]
        public int? EmployeeID;

        [Column, Nullable]
        public int? ShipVia;
    }
}
