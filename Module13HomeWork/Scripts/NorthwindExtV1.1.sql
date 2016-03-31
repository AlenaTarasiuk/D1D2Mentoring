if NOT EXISTS (select * from sys.objects where OBJECT_ID = OBJECT_ID(N'[dbo].[Credit Cards]'))
	begin
		create table [dbo].[Credit Cards](
			[CreditCardID] [int] identity(1,1) NOT NULL,
			[CreditCardNumber] [varchar](20) NOT NULL,
			[ExpirationDate] [datetime] NOT NULL,
			[CardHolder] [nvarchar](200) NOT NULL,
			[EmployeeID] [int],
			constraint [PK_CreditCards] primary key ([CreditCardID] asc),
			constraint [FK_EmpID] foreign key ([EmployeeID]) references [dbo].[Employees] ([EmployeeID]))
	end