using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DB.Entities
{
    [Table("Products")]
    public class Product
    {
        private EntityRef<Supplier> supplier = new EntityRef<Supplier>();
        private EntityRef<Category> category = new EntityRef<Category>();

        [Association(Storage = "supplier", ThisKey = "SupplierID", OtherKey = "SupplierID")]
        public Supplier Supplier
        {
            get { return supplier.Entity; }
            set { supplier.Entity = value; }
        }

        [Association(Storage = "category", ThisKey = "CategoryID", OtherKey = "CategoryID")]
        public Category Category
        {
            get { return category.Entity; }
            set { category.Entity = value; }
        }

        [PrimaryKey, Identity]
        public int ProductID { get; set; }

        [Column, NotNull]
        public string ProductName { get; set; }

        [Column, Nullable]
        public string QuantityPerUnit { get; set; }

        [Column, Nullable]
        public decimal UnitPrice { get; set; }

        [Column, Nullable]
        public Int16 UnitsInStock { get; set; }

        [Column, Nullable]
        public Int16 UnitsOnOrder { get; set; }

        [Column, Nullable]
        public Int16 ReorderLevel { get; set; }

        [Column, NotNull]
        public Boolean Discontinued { get; set; }

        [Column, Nullable]
        public int? SupplierID;

        [Column, Nullable]
        public int? CategoryID;
    }
}
