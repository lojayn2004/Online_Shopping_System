

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
