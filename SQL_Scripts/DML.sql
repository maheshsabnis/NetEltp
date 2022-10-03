use eShoppingCodi;

insert into Category Values(1001, 'Electronics', 2000);

insert into Category Values(1002, 'Electrical', 20);
insert into Category Values(1003, 'Food', 60);
insert into Category Values(1004, 'Fashion', 200);

Select * from Category;

-- Lets Update
Update Category SET CategoryName='Electronics-IT' where CategoryId=1001;

-- Lets Delete
Delete Category where CategoryId=1004;

-- Now for Product
Insert into Product Values('Prod-001','Laptop', '64 GB RAM 1 TB SSD', 234000, 1001, 'Apple');

Insert into Product Values('Prod-002','Laptop', '32 GB RAM 2 TB SSD', 220000, 1001, 'Acer');


select * from Product;

Delete Product where ProductUniqueId=3;

-- Truncate the Table by Resetting it and deleting all Roecords

truncate Table Product;


Insert into Product Values('Prod-003','RAM', '64 GB', 34000, 1001, 'HP');

Insert into Product Values('Prod-004','DVD Writter', 'Fast Writer', 4000, 1001, 'Nero');

Insert into Product Values('Prod-005','Mixer', 'Mix Anything', 3000, 1002, 'Bajaj');

Insert into Product Values('Prod-006','Iron', 'Press All', 5000, 1002, 'Phillipse');








