select YEAR (OrderDate) 
	as YEAR, 
		COUNT(*) as Total from dbo.Orders
	group by YEAR(OrderDate);

select COUNT(*) 
	as Totals from dbo.Orders;

select (e.LastName + ' & ' + e.FirstName) 
	as Seller, 
		COUNT(o.EmployeeID) as Amount from dbo.Orders o INNER JOIN dbo.Employees e
	on o.EmployeeID = e.EmployeeID
		where o.EmployeeID IS NOT NULL
	group by o.EmployeeID, e.LastName, e.FirstName
	order by COUNT(o.EmployeeID) desc;

select o.EmployeeID, o.CustomerID, 
	COUNT(*) from dbo.Orders o
		where YEAR(o.OrderDate) = 1998
	group by o.EmployeeID, o.CustomerID;

select e.FirstName, c.ContactName, e.City 
	from dbo.Employees e, dbo.Customers c
		where e.City = c.City;
	
select COUNT(c.CustomerID) 
	as [Customer Count], c.City 
		from dbo.Customers c
	group by c.City;

select e.FirstName 
	as Employee, (select distinct e1.FirstName from Employees e1 where e1.EmployeeID = e.ReportsTo) 
		as [Reports To] from Employees e;