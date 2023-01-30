create table Customer (
	UserId int identity (1,1) primary key,
	Username varchar (20) Not null,
	Email varchar (50) Not null,
	FirstName varchar (20) Not null,
	LastName varchar (20) Not null,
	CreateOn varchar (20) Not null,
	IsActive bit Not null, 
);

select * from Customer

insert into Customer (Username,Email,FirstName,LastName,CreateOn,IsActive)
values ('Dilan perers','dilan@reqres.in','Dilan','Perers','24-01-2023',1);

create table Supplier (
SupplierId int identity (1,1) primary key,
SupplierName varchar (50)  Not null,
CreatedOn datetime  Not null,
IsActive bit  Not null,
);

insert into Supplier (SupplierName,CreatedOn,IsActive)
values ('Dilan Perera Panchacharam',24-01-2023,1);

select * from Supplier

create table Product (
ProductId int identity (1,1) primary key,
ProductName varchar (50)  Not null,
UnitPrice decimal Not null,
SupplierId int FOREIGN KEY REFERENCES Supplier(SupplierId),
CreatedOn datetime Not null,
IsActive bit Not null,
);

insert into Product(ProductName,UnitPrice,SupplierId,CreatedOn,IsActive)
values ('Dushi Perera',150.00,3,24-01-2023,1);

select * from Product

create table P_Order (
OrderId int identity (1,1) primary key,
ProductId int FOREIGN KEY REFERENCES Product(ProductId),
OrderStatus int  Not null,
OrderType int Not null,
OrderBy int FOREIGN KEY REFERENCES Customer(UserId),
OrderedOn varchar (20) Not null,
SippedOn varchar (20) Not null,
IsActive bit Not null,

);

select * from P_Order

select * 
from Customer customer, P_Order p_order ,Product product, Supplier supplier 
where p_order.ProductId = product.ProductId and p_order.OrderBy = customer.UserId and product.SupplierId = supplier.SupplierId a



USE [Ado_Example]
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllcustomerRelatedData]    Script Date: 1/30/2023 12:00:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_getAllcustomerRelatedData]
as
begin

	select * 
	from dbo.Customer customer, dbo.P_Order p_order ,dbo.Product product, dbo.Supplier supplier 
	where p_order.ProductId = product.ProductId and p_order.OrderBy = customer.UserId and product.SupplierId = supplier.SupplierId  

end


USE [Ado_Example]
GO
/****** Object:  StoredProcedure [dbo].[sp_getAllcustomers]    Script Date: 1/30/2023 12:03:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_getAllcustomers]
as
begin

	select * from dbo.Customer

end