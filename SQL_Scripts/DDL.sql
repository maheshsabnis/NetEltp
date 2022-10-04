-- CReate a Database
-- eShoppingCodi.mdf as well as eShoppingCodi.ldf
CReate Database eShoppingCodi;
-- Set the COntext with eShoppingCodi so that all Tables, SP, triggers, etc will be created in it
use eShoppingCodi;
-- CReate a Table
Create Table Category (
 CategoryId int Primary Key,
 CategoryName varchar(100),
 BasePrice decimal 
);

 -- MOdify the Table by adding Not Nul COnstraints on column
 ALter Table Category ALter COlumn CategoryName varchar(100) not null; 
 ALter Table Category ALter COlumn BasePrice decimal not null; 

 -- The Table with Identity COlumn of which value
 -- will be DB Generated the default is 1 and it is increased by 1
 -- Lets make the Produt as a child of the Category
 -- this will also establish the 'One-to-Many' Reationship
 -- this is also kown as 'Referential Integrity' Rule
 -- This will make the CategoryId value mandatory fr Creating Product
 -- as well as the value for the CategoryId MUST be preset into te Category Table
 Create Table Product(
   ProductUniqueId int Identity Primary Key,
   ProductId varchar(50) Not Null,
   ProductName varchar(300) Not Null,
   Descrition varchar(500) Not Null,
   Price decimal Not null,
   CategoryId int references Category(CategoryId) not null
 );

 -- Add a new Colun inProduct Table
 ALter Table Product add Manufacturer varchar(200) not null;

 -- Use the 'sp_rename' STored Procedure to Raname the column
 -- We need to execute the SP
 -- Exec sp_rename [OLD_COLUMN] [NEW_COLUMN]

 Exec sp_rename 'Product.Descrition', 'Description';


 -- Dependant Key, a COlumn that is diretcly depending on the Primary Key 
 -- A UNique keu is like primary Key but it can have Null Value 


 

CREATE TABLE Customer (
	CustomerUniqueId int Identity(1,1) Primary Key,
    CustomerID int NOT NULL UNIQUE,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255) Not Null,
    Age int 
);




