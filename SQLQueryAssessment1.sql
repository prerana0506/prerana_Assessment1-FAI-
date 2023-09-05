use PreranaCP
---------------
Create table Categories(
CategoryId int primary key,
CategoryName varchar(200)
);
----------------
Create table Suppliers(
SupplyId int primary key,
SupplierName varchar(200),
ContactName varchar(200),
ContactEmail varchar(200)
);
-------------------
Create table Products(
ProductId int Primary key,
ProductName varchar(200),
CategoryId int,
Price int,
Description1 Text,
Constraint Fk1 Foreign Key(CategoryId) References Categories(CategoryId)
);
----------------------
Create table ProductSuppliers(
ProductId int,
SupplierId int,
Constraint FK2 Foreign Key(ProductId)References Products(ProductId),
Constraint FK3 Foreign Key(SupplierId)References Suppliers(SupplyId),
Primary key(ProductId,SupplierId)
);
----------------------------- 
Create table Inventory(
ProductId int Primary key,
QuanityInStock int,
Constraint FK4 Foreign key(ProductId)References Products(ProductId)
);
--------------------------------
insert into Categories(CategoryId,CategoryName)values(1,'Electronics')
insert into Categories(CategoryId,CategoryName)values(2,'Clothing')
insert into Categories(CategoryId,CategoryName)values(3,'HomeAppliances')
---------------------------------
insert into Suppliers(SupplyId,SupplierName,ContactName,ContactEmail)values(1,'ABCElectronics','John','john@gmail.com')
insert into Suppliers(SupplyId,SupplierName,ContactName,ContactEmail)values(2,'FashionMart','Jack','jack@gmail.com')
----------------------------------
insert into Products(ProductId,ProductName,CategoryId,Price,Description1)values(1,'Smartphone',1,59000,'Latest version')
insert into Products(ProductId,ProductName,CategoryId,Price,Description1)values(2,'Tshirts',1,5000,'Various colors available')
---------------------------------
insert into ProductSuppliers(ProductId,SupplierId)values(1,1)
insert into ProductSuppliers(ProductId,SupplierId)values(1,2)
insert into ProductSuppliers(ProductId,SupplierId)values(2,2)
-----------------------------------
insert into Inventory(ProductId,QuanityInStock)values(1,100)
insert into Inventory(ProductId,QuanityInStock)values(2,700)
-------------------------------------------------------------
---------------------------RETRIEVE DATA-----------------------
SELECT p.ProductName,p.Price,p.CategoryId,c.CategoryName,s.SupplierName,i.QuanityInStock,p.ProductId,c.CategoryId
FROM Products p Join Categories c on p.CategoryID = c.CategoryID join ProductSuppliers ps on p.ProductID = ps.ProductID join Suppliers s on ps.SupplierID = s.SupplyId join Inventory i on p.ProductID = i.ProductID;
-------------------------
Select * from Categories


