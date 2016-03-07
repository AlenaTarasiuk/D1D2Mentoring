using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ProjectDAL
{
    public class NorthwindBDWork : IBDWork
    {
        private string connectionString = "NorthwindConnection";
        private DbConnection dbConnection;

        public NorthwindBDWork()
        {
            ConfConnection(ConfigurationManager.ConnectionStrings[this.connectionString].ConnectionString, ConfigurationManager.ConnectionStrings[this.connectionString].ProviderName);
        }

        public NorthwindBDWork(string connectionString)
        {
            this.connectionString = connectionString;
            ConfConnection(ConfigurationManager.ConnectionStrings[this.connectionString].ConnectionString, ConfigurationManager.ConnectionStrings[this.connectionString].ProviderName);
        }

        public NorthwindBDWork(string connectionString, string provider = "System.Data.SqlClient")
        {
            ConfConnection(connectionString, provider);
        }

        private void ConfConnection(string connectionString, string provider)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            this.dbConnection = factory.CreateConnection();
            this.dbConnection.ConnectionString = connectionString;
        }

        public IList<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            DbCommand command = this.dbConnection.CreateCommand();
            command.CommandText = "select * from Orders";
            dbConnection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    DateTime dataTimeOrder, dataTimeRequired, dataTimeShipped;
                    bool timeOrderFlag = DateTime.TryParse(reader["OrderDate"].ToString(), out dataTimeOrder);
                    bool timeRequiredFlag = DateTime.TryParse(reader["RequiredDate"].ToString(), out dataTimeRequired);
                    bool timeShippedFlag = DateTime.TryParse(reader["ShippedDate"].ToString(), out dataTimeShipped);
                    Order order = new Order()
                    {
                        CustomerID = ConversionValue<string>(reader["CustomerID"]),
                        EmployeeID = ConversionValue<int?>(reader["EmployeeID"]),
                        Freight = ConversionValue<decimal?>(reader["Freight"]),
                        OrderDate = timeOrderFlag ? dataTimeOrder : (DateTime?)null,
                        OrderID = ConversionValue<int>(reader["OrderID"]),
                        RequiredDate = timeRequiredFlag ? dataTimeRequired : (DateTime?)null,
                        ShipAddress = ConversionValue<string>(reader["ShipAddress"]),
                        ShipCity = ConversionValue<string>(reader["ShipCity"]),
                        ShipCountry = ConversionValue<string>(reader["ShipCountry"]),
                        ShipName = ConversionValue<string>(reader["ShipName"]),
                        ShippedDate = timeShippedFlag ? dataTimeShipped : (DateTime?)null,
                        ShipPostalCode = ConversionValue<string>(reader["ShipPostalCode"]),
                        ShipRegion = ConversionValue<string>(reader["ShipRegion"]),
                        ShipVia = ConversionValue<int?>(reader["ShipVia"])
                    };
                    orders.Add(order);
                }
            }
            dbConnection.Close();
            return orders;
        }

        private static T ConversionValue<T>(object obj)
        {
            return (obj == null || obj == DBNull.Value) ? default(T) : (T)obj;
        }

        public Details GetOrderDetails(Order order)
        {
            Details details = null;
            DbCommand command = this.dbConnection.CreateCommand();
            command.CommandText = String.Format("select od.OrderID, od.ProductID, od.UnitPrice, od.Quantity, od.Discount, p.ProductName from dbo.[Order Details] od inner join dbo.Products p on od.ProductID = p.ProductID where od.OrderID = {0}", order.OrderID);
            dbConnection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    details = new Details()
                    {
                        Discount = ConversionValue<Single>(reader["Discount"]),
                        OrderID = ConversionValue<int>(reader["OrderID"]),
                        ProductID = ConversionValue<int>(reader["ProductID"]),
                        ProductName = ConversionValue<string>(reader["ProductName"]),
                        Quantity = ConversionValue<Int16>(reader["Quantity"]),
                        UnitPrice = ConversionValue<decimal>(reader["UnitPrice"])
                    };
                }
            }
            dbConnection.Close();
            return details;
        }

        public void CreateOrder(Order order)
        {
            DbCommand command = this.dbConnection.CreateCommand();
            command.CommandText = String.Format("insert into Orders(CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) values ('{0}', {1}, '{2}', '{3}', '{4}', {5}, {6}, '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')",
            order.CustomerID, order.EmployeeID, order.OrderDate.HasValue ? order.OrderDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.RequiredDate.HasValue ? order.RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.ShippedDate.HasValue ? order.ShippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.ShipVia, order.Freight, order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode, order.ShipCountry);
            dbConnection.Open();
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        public bool UpdateOrder(Order order)
        {
            bool flag = (order.OrderStatus != Order.OrderStatuses.New) ? false : true;
                if (flag)
                {
                    DbCommand command = this.dbConnection.CreateCommand();
                    command.CommandText = String.Format("update Orders set CustomerID='{0}', EmployeeID={1}, RequiredDate='{2}', ShipVia={3}, Freight={4}, ShipName='{5}', ShipAddress='{6}', ShipCity='{7}', ShipRegion='{8}', ShipPostalCode='{9}', ShipCountry='{10}' where OrderID = {11}",
                    order.CustomerID, order.EmployeeID, order.RequiredDate.HasValue ? order.RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.ShipVia, order.Freight, order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode, order.ShipCountry, order.OrderID);
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                    dbConnection.Close();
                }
            return flag;
        }

        public bool DeleteOrder(Order order)
        {
            bool flag = (order.OrderStatus != Order.OrderStatuses.New || order.OrderStatus != Order.OrderStatuses.InProgress) ? false : true;
                if (flag)
                {
                    DbCommand command = this.dbConnection.CreateCommand();
                    command.CommandText = String.Format("delete from Orders where OrderID = {0}", order.OrderID);
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                    dbConnection.Close();
                }
            return flag;
        }

        public bool SetInProgress(Order order, DateTime? orderDate)
        {
            bool flag = (order.OrderStatus != Order.OrderStatuses.New) ? false : true;
                if (flag)
                {
                    DbCommand command = this.dbConnection.CreateCommand();
                    command.CommandText = String.Format("update Orders set OrderDate='{0}' where OrderID = {1}",
                    orderDate.HasValue ? orderDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.OrderID);
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                    dbConnection.Close();
                }
            return flag;
        }

        public void SetComplete(Order order, DateTime? shippedDate)
        {
            DbCommand command = this.dbConnection.CreateCommand();
            command.CommandText = String.Format("update Orders set ShippedDate='{0}' where OrderID = {1}",
            shippedDate.HasValue ? shippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : null, order.OrderID);
            dbConnection.Open();
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        public IList<CustOrderHist> GetCustomerOrdersHistory(string customerId)
        {
            List<CustOrderHist> orders = new List<CustOrderHist>();
            DbCommand command = this.dbConnection.CreateCommand();
            command.CommandText = "CustOrderHist";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add( new SqlParameter()
                                                        {
                                                            ParameterName = "@CustomerID",
                                                            Direction = ParameterDirection.Input,
                                                            Value = customerId
                                                        });
            dbConnection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CustOrderHist custHist = new CustOrderHist()
                    {
                        ProductName = ConversionValue<string>(reader["ProductName"]),
                        Total = ConversionValue<int>(reader["Total"])
                    };
                    orders.Add(custHist);
                }
            }
            dbConnection.Close();
            return orders;
        }

        public IList<CustOrdersDetail> GetCustomerOrdersDetail(int orderId)
        {
            List<CustOrdersDetail> ordersDetails = new List<CustOrdersDetail>();
            DbCommand command = this.dbConnection.CreateCommand();
            command.CommandText = "CustOrdersDetail";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add( new SqlParameter()
                                                        {
                                                            ParameterName = "@OrderID",
                                                            Direction = ParameterDirection.Input,
                                                            Value = orderId
                                                        });
            dbConnection.Open();
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CustOrdersDetail custDetails = new CustOrdersDetail()
                    {
                        Discount = ConversionValue<double>(reader["Discount"]),
                        ExtendedPrice = ConversionValue<double>(reader["ExtendedPrice"]),
                        ProductName = ConversionValue<string>(reader["ProductName"]),
                        Quantity = ConversionValue<int>(reader["Quantity"]),
                        UnitPrice = ConversionValue<decimal>(reader["UnitPrice"])
                    };
                    ordersDetails.Add(custDetails);
                }
            }
            dbConnection.Close();
            return ordersDetails;
        }
    }
}