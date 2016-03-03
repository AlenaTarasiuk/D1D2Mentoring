select OrderId, ShippedDate, ShipVia 
	from Orders
		where ShippedDate >= CONVERT(datetime, '06.05.1998', 104) AND ShipVia >= 2;

select OrderID, 
	case
		when ShippedDate IS NULL then 'Not shipped'
			end as [Shipped Date]
		from Orders
			where ShippedDate IS NULL;

select OrderID as [Order Number],
	case
		when ShippedDate IS NULL then 'Not Shipped'
			else CONVERT(varchar(25), ShippedDate)
				end as [Shipped Date]
		from Orders
			where (ShippedDate IS NULL) OR (ShippedDate >= CONVERT(datetime, '06.05.1998', 104));