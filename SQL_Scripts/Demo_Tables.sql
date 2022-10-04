Create Table Department(
  DeptNo int Primary Key,
  DeptName varchar(100) Not Null,
  Location varchar(100) Not Null,
  Capacity int Not Null
);

Insert into Department Values(10, 'Information Technology', 'Pune', 400);

Insert into Department Values(20, 'Human Resource', 'Pune', 45);
Insert into Department Values(30, 'Maintenence', 'Pune', 13);
Insert into Department Values(40, 'Projects', 'Pune', 8000);
Insert into Department Values(50, 'Accounts', 'Pune', 800);

Create Table Employee(
  EmpNo int Primary Key,
  EmpName varchar(200) Not Null,
  Designation varchar(200) Not Null,
  Salary int Not Null,
  DeptNo int Not Null References Department(DeptNo) -- Foreign Key
);


insert into Employee Values (101, 'Mahesh', 'Director', 900000, 10);
insert into Employee Values (102, 'Tejas', 'Director', 900000, 20);
insert into Employee Values (103, 'Ramesh', 'Director', 900000, 30);
insert into Employee Values (104, 'Sharad', 'Director', 900000, 40);
insert into Employee Values (105, 'Sanjay', 'Director', 900000, 50);
insert into Employee Values (106, 'Vijay', 'Manager', 900000, 10);
insert into Employee Values (107, 'Vilas', 'Manager', 900000, 20);
insert into Employee Values (108, 'Abhay', 'Manager', 900000, 30);
insert into Employee Values (109, 'Vivek', 'Manager', 900000, 40);
insert into Employee Values (110, 'Satish', 'Manager', 900000, 50);
insert into Employee Values (111, 'Mukesh', 'Lead', 900000, 10);
insert into Employee Values (112, 'Sandeep', 'Lead', 900000, 20);
insert into Employee Values (113, 'Vinay', 'Lead', 900000, 30);
insert into Employee Values (114, 'Kaustubh', 'Lead', 900000, 40);
insert into Employee Values (115, 'Tushar', 'Lead', 900000, 50);
insert into Employee Values (116, 'Krishna', 'Associate', 900000, 10);
insert into Employee Values (117, 'Arav', 'Associate', 900000, 20);
insert into Employee Values (118, 'Nainesh', 'Associate', 900000, 30);
insert into Employee Values (119, 'Aditya', 'Associate', 900000, 40);
insert into Employee Values (120, 'Sujay', 'Associate', 900000, 50);

Select * from Employee;
Select * from Department;