// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{

		private DataSource dataSource = new DataSource();

		[Category("Restriction Operators")]
		[Title("Task 1")]
        [Description("Give a list of all customers whose total turnover exceeds a certain variable X.")]
        public IEnumerable Linq1(int x)
		{
            return dataSource.Customers
                .Where(customer => customer.Orders
                        .Select(order => order.Total)
                        .Sum() > x);
		}

		[Category("Projection Operators")]
		[Title("Task 2")]
		[Description("For each client, make a list of suppliers who are in the same country and the same city.")]
		public IEnumerable Linq2()
		{
            return dataSource.Customers
                .Select(customer => new { customer.CustomerID,
                                          customer.Country,
                                          customer.City,
                                          suppliers = dataSource.Suppliers.Where(suppliers => (suppliers.City == customer.City & suppliers.Country == customer.Country)),
                                        });
		}
        
        [Category("Restriction Operators")]
        [Title("Task 3")]
        [Description("Find all customers who had orders that exceed the sum of variable X.")]
        public IEnumerable Linq3(int x)
        {
            return dataSource.Customers
                    .Where(customer => customer.Orders
                        .Select(order => order.Total)
                        .Any(order => order > x)
                        );
        }
        
        [Category("Projection Operators")]
        [Title("Task 4")]
        [Description("Give a list of clients indicating starting with a month of the year, they became customers.")]
        public IEnumerable Linq4()
        {
            return dataSource.Customers
                    .Select(customer => new 
                                            { customer.CustomerID,
                                              orders = customer.Orders.Select(orders => (orders.OrderDate.Month & orders.OrderDate.Year)).Min(),
                                            });
        }
        
        [Category("Groping Operators")]
        [Title("Task 5")]
        [Description("Give a list of clients indicating starting with a month of the year they become customers, a list sorted by year, month, customer turnover.")]
        public IEnumerable Linq5()
        {
            return dataSource.Customers
                            .Select(customerNew => new
                                                    {
                                                        companyName = customerNew.CompanyName,
                                                        orders = customerNew.Orders.Count()>0 ? customerNew.Orders.Min(order => order.OrderDate) : new DateTime(1000),
                                                        totalOrder = customerNew.Orders.Sum(order => order.Total)
                                                    })
                                                    .OrderBy(customer => customer.orders)
                                                        .OrderBy(customer => customer.totalOrder)
                                                            .OrderByDescending(customer => customer.companyName);
        }
  
        [Category("Quantifiens Operators")]
        [Title("Task 6")]
        [Description("List all customers who have not specified a digital code or full region or in the phone area code Unknown.")]
        public IEnumerable Linq6()
        {
            return dataSource.Customers
                        .Select(customer => (customer.PostalCode == null || !customer.PostalCode.All(c => Char.IsDigit(c)) || String.IsNullOrEmpty(customer.Region) || !customer.Phone.Contains("(")));
        }

        [Category("Restriction Operators")]
        [Title("Task 7")]
        [Description("Group all products by category, in - on the availability of stock within the last group of sort by cost.")]
        public IEnumerable Linq7()
        {
            return dataSource.Products
                    .GroupBy(product => product.Category)
                        .Select(group => new {
                                                category = group.Key,
                                                productsByUnitsInStock = group.GroupBy(product => product.UnitsInStock)
                                                .Select(group2 => new
                                                                 {
                                                                     ptoductGroup = group2.Key,
                                                                     unitPrice = group2.Select(product => product.UnitPrice)
                                                                  })
                                             });
        }
    
        [Category("Groping Operators")]
        [Title("Task 8")]
        [Description("Group the items by groups of cheap, average, expensive.")]
        public IEnumerable Linq8()
        {
            var MIN = dataSource.Products.Select(product => product.UnitPrice).Min();
            var MAX = dataSource.Products.Select(product => product.UnitPrice).Max();

            Func<Product, string> priceRanker = product =>
                product.UnitPrice > MAX 
                    ? "expensive"
                    : product.UnitPrice < MIN
                        ? "cheap"
                        : "middle";

            return dataSource.Products.GroupBy(priceRanker);
        }

        [Category("Aggregate Operators")]
        [Title("Task 9")]
        [Description("Calculate the average profitability of each city, and the average intensity.")]
        public IEnumerable Linq9()
        {
            return dataSource.Customers
                    .GroupBy(customer => customer.City)
                        .Select(customerBy => new
                                                {
                                                    City = customerBy.Key,
                                                    Count = customerBy.Average(order => order.Orders.Length),
                                                    Total = customerBy.Select(customerBy2 => new 
                                                                                                {
                                                                                                    Count = customerBy2.Orders.Length > 0 ? customerBy2.Orders.Average(order => order.Total) : 0
                                                                                                })
                                                                                                .Average(order => order.Count)
                                                });
        }
        
        [Category("Aggregate Operators")]
        [Title("Task 10.1")]
        [Description("Make an annual average customer activity by month")]
        public IEnumerable Linq101()
        {
            return dataSource.Customers
                        .SelectMany(order => order.Orders)
                            .GroupBy(customer => customer.OrderDate.Month)
                                .Select(newGroup => new
                                                {
                                                    Moth = newGroup.Key,
                                                    Avrg = newGroup.Average(order => order.Total)
                                                });
        }

        [Category("Aggregate Operators")]
        [Title("Task 10.2")]
        [Description("Make an annual average customer activity by year")]
        public IEnumerable Linq102()
        {
            return dataSource.Customers
                        .SelectMany(order => order.Orders)
                            .GroupBy(customer => customer.OrderDate.Year)
                                .Select(newGroup => new
                                                {
                                                    Year = newGroup.Key,
                                                    Avrg = newGroup.Average(order => order.Total)
                                                });
        }

        [Category("Aggregate Operators")]
        [Title("Task 10.3")]
        [Description("Make an annual average customer activity by years and months.")]
        public IEnumerable Linq103()
        {
            return dataSource.Customers
                        .SelectMany(order => order.Orders)
                            .GroupBy(customer => new
                                                    {
                                                        customer.OrderDate.Year,
                                                        customer.OrderDate.Month

                                                    }).Select(newGroup => new
                                                                            {
                                                                                Year = newGroup.Key.Year,
                                                                                Month = newGroup.Key.Month,
                                                                                Avrg = newGroup.Average(order => order.Total)
                                                                             });
        }
                              
	}
}
