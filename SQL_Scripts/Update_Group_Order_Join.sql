-- Lets Update the EMployee Table with Seperate Salary

update Employee Set Salary = 700000 where Designation='Manager'; 
update Employee Set Salary = 500000 where Designation='Lead'; 
update Employee Set Salary = 300000 where Designation='Associate'; 
-- Lets Group
select DeptNo, Sum(Salary) From Employee Group By DeptNo;
select Designation, Sum(Salary) From Employee Group By Designation;


-- Lets Order By
Select EmpNo, EMpName, Salary from EMployee Order by EmpName; -- Default is Ascending
Select EmpNo, EMpName, Salary from EMployee Order by EmpName desc; 

Select * from Department, EMployee;
-- Simple Join
select EmpNo, EmpName, DeptName, Designation, Salary, Location
From Department, Employee
where Department.DeptNo = Employee.DeptNo;

select EmpNo, EmpName, DeptName, Designation, Salary, Location
From Department
Left Join Employee
on  Department.DeptNo = Employee.DeptNo;

select EmpNo, EmpName, DeptName, Designation, Salary, Location
From Department
Right Join Employee
on  Department.DeptNo = Employee.DeptNo;

-- SUb Query
select DeptName, Location from Department
where DeptNo in ( select DeptNo From  Employee);

Select max(Salary) from EMployee where Salary < (Select max(Salary) from Employee);

 



