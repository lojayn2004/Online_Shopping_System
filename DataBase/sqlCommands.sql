create database OnlineShoppingSystem;

create table [User](
    userId int identity(1, 1) primary key,
	userName varchar(70) unique,
	[password] varchar(70),
	email varchar(50)

);

create table [Admin] (
   adminId int primary key,
   dateOfEmployment Date

);

create table Customer (
    customerId int primary Key,
    streetCode varchar(50),
	zipCode varchar(50),
	city varchar(50)
);

alter table [Admin]
add constraint fk_admin foreign key(adminId) references [User](userId)
on delete cascade;

alter table [Customer]
add constraint fk_customer foreign key(customerId) references [User](userId)
on delete cascade;

create table Products(
    productId int primary key identity(1, 1),
	productName varchar(70),
	productDescription text,
    productCategory varchar(70),
    productPrice decimal,
	productQuantity int,
);

create table ShoppingCart(
        customerId int,
	productId int,
	quantity int default 1,
	primary key(customerId, productId)

);

ALTER TABLE shoppingCart
ADD CONSTRAINT shoppingCart_Customer_fk 
FOREIGN KEY (customerId) REFERENCES customer(customerId);

ALTER TABLE shoppingCart
ADD CONSTRAINT shoppingCart_Product_fk 
FOREIGN KEY (productId) REFERENCES products(productId);

INSERT INTO Products (productName, productDescription, productCategory, productPrice, productQuantity)
VALUES ('Smartphone', 'Latest 5G smartphone with 128GB storage', 'Electronics', 699.99, 50);

INSERT INTO Products (productName, productDescription, productCategory, productPrice, productQuantity)
VALUES ('Novel', 'Bestselling fiction novel', 'Books', 19.99, 100);

INSERT INTO Products (productName, productDescription, productCategory, productPrice, productQuantity)
VALUES ('Sofa', 'Comfortable 3-seater sofa', 'Home', 499.99, 20);

INSERT INTO Products (productName, productDescription, productCategory, productPrice, productQuantity)
VALUES ('Vitamin C', 'High potency Vitamin C supplement', 'Health', 29.99, 200);

INSERT INTO Products (productName, productDescription, productCategory, productPrice, productQuantity)
VALUES ('Gold Necklace', '18K gold necklace with a diamond pendant', 'Jewelry', 1299.99, 10);

INSERT INTO Products (productName, productDescription, productCategory, productPrice, productQuantity)
VALUES ('Refrigerator', 'Energy-efficient double-door refrigerator', 'Appliances', 899.99, 15);

INSERT INTO Products (productName, productDescription, productCategory, productPrice, productQuantity)
VALUES ('Organic Pasta', 'Gluten-free organic pasta', 'Food', 4.99, 500);

INSERT INTO Products (productName, productDescription, productCategory, productPrice, productQuantity)
VALUES ('T-shirt', 'Cotton T-shirt with a cool print', 'Clothes', 19.99, 150);

INSERT INTO Products (productName, productDescription, productCategory, productPrice, productQuantity)
VALUES ('Running Shoes', 'Comfortable running shoes with good grip', 'Shoes', 79.99, 100);

