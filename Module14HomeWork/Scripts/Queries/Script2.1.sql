select SUM(UnitPrice*Quantity*(1-Discount)) 
	as Totals 
		from dbo.[Order Details];

select COUNT(ShippedDate)
	from dbo.Orders;

select COUNT(p.CustomerID) 
	from (select distinct CustomerID from dbo.Orders) as p;