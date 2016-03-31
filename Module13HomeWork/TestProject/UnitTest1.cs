using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Linq2DB.Entities;
using Linq2DB.Queries;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ProductList()
        {
            SelectQueries.Products();
        }

        [TestMethod]
        public void EmployeeShipper()
        {
            SelectQueries.GetEmployeeShipperCoworking();
        }

        [TestMethod]
        public void NewEmployee()
        {
            ManipQueries.AddEmployee("Ivanov", new string[] { "11223", "22113" });
        }

        [TestMethod]
        public void AddProducts()
        {
            ManipQueries.AddProducts(new Product[] {
                new Product()
                {
                    ProductName = "Сold tea",
                    Category = new Category()
                    {
                        CategoryName = "Tea"
                    },
                    Supplier = new Supplier()
                    {
                        CompanyName = "OrCool"
                    }
                }
            });
        }
    }
}
