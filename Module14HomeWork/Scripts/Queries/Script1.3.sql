select distinct OrderID 
	from [Order Details]
		where Quantity BETWEEN 3 AND 10;

select CustomerID, Country 
	from Customers
		where Lower(Country) BETWEEN 'b%' AND 'g%'
	order by Country;

select CustomerID, Country 
	from Customers
		where Lower(Country) >= 'b%' and Lower(Country) <= 'g%';