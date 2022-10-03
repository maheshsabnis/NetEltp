-- Select, From, Where, GroupBy, Having, OrderBy
-- Operators: Like, Between, In, or, and, not
-- Scalar Functions: Sum(), Max(), Min(), Count(), Average(), etc.

Select * from Product where CategoryId=1001;

-- Using Two Tables
-- The FOllowing Query will show all records from all Tables with Data Repetation 
-- so avoid usng such queries
select * from Category, Product;

select Category.CategoryId,CategoryName,BasePrice, ProductId, ProductName, Price
From Category, Product
where Category.CategoryId = Product.CategoryId and CategoryName='Electrical';

-- Print Products Having Price between 10000 to 300000
select * from Product where Price Between 10000 and 300000

-- Print Products for specific Categories
select * from Product where CategoryId = 1001 or CategoryId=1003;

select * from Product where CategoryId in(1001,1003);

-- Using Like Pattern Matching, ProductNAme stars from L
Select * from Product where ProductNAme Like 'L%';














 