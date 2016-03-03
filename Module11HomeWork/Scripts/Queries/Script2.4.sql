select CompanyName 
	from Suppliers s
		where s.SupplierID 
			IN (select distinct SupplierID from Products p where p.UnitsInStock = 0);

select e.FirstName 
	from Employees e
		where e.EmployeeID 
			IN ( select o.EmployeeID from Orders o group by o.EmployeeID having count(*) > 150);

select * 
	from Customers c
		where c.CustomerID 
			IN (select o.CustomerID from Orders o group by o.CustomerID having count(o.CustomerID) > 0);