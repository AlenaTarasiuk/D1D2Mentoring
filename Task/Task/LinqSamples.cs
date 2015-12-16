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
            var customers = dataSource.Customers
                            .Select(customer => new
                                                    {
                                                        customer.CustomerID,
                                                        orders = customer.Orders.Select(orders => (orders.OrderDate.Month & orders.OrderDate.Year)).Min(),
                                                    });

            return customers.OrderBy(dataSource.Customers
                                .Select(customer => customer.CompanyName)
                                    .OrderByDescending(dataSource.Customers
                                    .Select(customer => customer.Orders
                                        .Where(order => order.OrderDate.Year & order.OrderDate.Month)))
                                    );
        }

        [Category("Quantifiens Operators")]
        [Title("Task 6")]
        [Description("List all customers who have not specified a digital code or full region or in the phone area code Unknown.")]
        public IEnumerable Linq6()
        {
            return dataSource.Customers
                        .Select(customer => (!customer.PostalCode.Contains("()") & !customer.PostalCode.Contains("()")));
        }


        [Category("Restriction Operators")]
        [Title("Task 7")]
        [Description("Group all products by category, in - on the availability of stock within the last group of sort by cost.")]
        public void Linq7()
        {
            return dataSource.Products
                    .GroupBy(product => product.Category)
                        .Select(group => new {
                                                category = group.Key,
                                                productsByUnitsInStock = group.GroupBy(product => product.UnitsInStock)
                                             }
                                             .Select(group2 => new
                                                                 {
                                                                     group = group2.Key,
                                                                     unitPrice = group2.GroupBy(product => product.UnitPrice)
                                                                  })
                               );
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
                    .GroupBy(customer => customer.City).Sum();

            return dataSource.Customers
                    .GroupBy(customer => customer.City).Count();
        }

        [Category("Aggregate Operators")]
        [Title("Task 10")]
        [Description("Make an annual average customer activity by month, by year, by years and months.")]
        public IEnumerable Linq10()
        {
            return dataSource.Customers
                        .Where(customer => customer.Orders
                                .SelectMany(order => new 
                                                        { 
                                                            order.OrderDate.Month,
                                                            order.OrderDate.Year
                                                        }));
        }
	}
}
