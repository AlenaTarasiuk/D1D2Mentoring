select ContactName, Country 
	from Customers
		where Country IN ('USA', 'Canada')
	order by ContactName, Country;

select ContactName, Country 
	from Customers
		where Country NOT IN ('USA', 'Canada')
	order by ContactName;

select distinct Country 
	from Customers
	order by Country desc;