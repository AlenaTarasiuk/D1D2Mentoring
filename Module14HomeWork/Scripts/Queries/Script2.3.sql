select distinct e.FirstName 
	from Employees e
			INNER JOIN EmployeeTerritories et
		on e.EmployeeID = et.EmployeeID
			INNER JOIN Territories t
		on et.TerritoryID = t.TerritoryID
			INNER JOIN Region r
		on r.RegionID = t.RegionID
	where r.RegionDescription = 'Western';

select c.ContactName, count(o.CustomerID) 
	from Customers c
			LEFT JOIN Orders o
		on c.CustomerID = o.CustomerID
	group by c.ContactName
	order by count(o.CustomerID)