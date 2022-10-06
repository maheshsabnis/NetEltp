-- Stored Procs (SP)
-- Programming with DB
	-- COmpiled and Residing in DB ENgine
	-- LOaded and Immediately Executed on DB Engine
	-- A Modularity Approach of Database Centric Logic on Database Server
	-- SP may have Input and Output Parameters
	-- The SP is recommended for following
		-- COmplex Operation those needs mutiple Tables and Transactions on them
		-- Structured Error Handling
		-- COditinal Execution  
	-- THey are not transferable across databases 	
	
-- SYntax
-- Create Procedure [PRODECURE-NAME]
-- INPUT and OUTPUT Paramaters @[NAME][DATATYPE]
--AS
--BEGIN
	-- YOUR LOGIC HERE
--END
--GO

-- EXEC [PRODECURE-NAME] @PARAMETER @PARAMETER OUTPUT

Create Proc sp_getAllEmployees
AS
Begin
	select EmpNo, EmpName, Designation, Salary, DeptNo
	From Employee;
End
Go


EXEC sp_getAllEmployees;
GO

-- Let's pass an input parameter (By default each parameter is input) 
create proc sp_getEmployeesByDeptNo
@DeptNo int -- INPUT Parameter by Default
As
Begin
  select EmpNo, EmpName, Designation, Salary
  From Employees
  where DeptNo=@DeptNo
End
Go

EXEC sp_getEmployeesByDeptNo @DeptNo=10;
GO
-- Let's Try to ALter The SP

Create or Alter proc sp_getEmployeesByDeptNo
@DeptNo int -- INPUT Parameter by Default
As
Begin
  select EmpNo, EmpName, Designation, Salary
  From Employee
  where DeptNo=@DeptNo;

  PRINT 'Hay!!! I am Successful';
End
Go

-- Let's DROP PRocedure
Drop procedure sp_getEmployeesByDeptNo;
Go
-- Let's have a Conditional Statemen in SP

create or alter proc sp_getEmpsByDeptNo
@DeptNo int
As
Begin
	-- Please check the @DeptNo is not -ve or 0
	IF @DeptNo <= 0
		select 'The Parameter DeptNo cannot be 0 or -ve' as ERROR_MESSAGE;
	ELSE
		select EmpNo, EmpName, Designation,Salary
		from Employee
		where DeptNo=@DeptNo;
	 
End
Go


exec sp_getEmpsByDeptNo @DeptNo=20;
GO

-- Let the PROC Return value
-- Difference Between OUT Parameters and return value
-- IF SP returns vaue, the client App MUST wait for the return data explicitly
-- THis is 2-way SP
-- The OUTPUT Parameter is already known to Client App, so the CLient app
-- need not to wait for the result explicitly, instead when the SPI is 
-- ready with output parameter, the value will be made available to CLient APp

-- Let's write a SP that will return sum of salary for all 
-- Employees of the DeptNo 20
create or alter proc sp_getSumOfSalByDeptNo
@DeptNo int
As
Begin
 -- Lets declare local variable
  declare @SumSalary int;
  -- lets check the DeptNo
  if @DeptNo <=0 
    select 'DEptNo is invalid' as Error_Message;
  else
	select @SumSalary = Sum(Salary) from Employee
	where DeptNo = @DeptNo;
	-- Lets return a value
	return @SumSalary;
End
go
-- DEclare a variable where the client will collect return value from SP
DEclare @SumSal int
-- Execute a SP and pass parameter to it and let the SP return data
Exec @SumSal = sp_getSumOfSalByDeptNo @DeptNo=20;
-- Print the return data
Select @SumSal;
go
-- How to use Output Parameter


create or alter proc sp_getSumOfSalByDeptNoWitOutput
@DeptNo int,
@ResultSalary int OUTPUT -- The output parameter
As
Begin
 -- Lets declare local variable
  declare @SumSalary int;
  -- lets check the DeptNo
  if @DeptNo <=0 
    select 'DEptNo is invalid' as Error_Message;
  else
	select @SumSalary = Sum(Salary) from Employee
	where DeptNo = @DeptNo;
	-- pass the resut to OUtput parameter

	select @ResultSalary =  @SumSalary;
End
go

Declare @sums int; 
-- Execute with output parameter
									-- Each  Paameter to SP has a 'Value' property
									-- THis could be a scalary data or resultset
Exec sp_getSumOfSalByDeptNoWitOutput @DeptNo=20, @ResultSalary=@sums Output;
Select @sums as Salary;
go
-- Lets INsert
create or alter proc sp_InsertDept
 @DeptNo int, @DeptNAme varchar(100), @Location varchar(100), @Capacity int
As
Begin
	insert into Department (DeptNo, DeptName, Location,Capacity)
	values
	(@DeptNo,@DeptName,@Location,@Capacity);
End
Go

Exec sp_InsertDept @DeptNo=201,@DeptName='Warehouse',@Location='Pune',@Capacity=200;

Select * from Department;
Go

-- SP With Exceptions

create or alter proc sp_InsertDeptException
 @DeptNo int, @DeptNAme varchar(100), @Location varchar(100), @Capacity int
As
Begin
    begin try
		insert into Department (DeptNo, DeptName, Location,Capacity)
		values
	(@DeptNo,@DeptName,@Location,@Capacity);	
	End Try
	BEgin catch
		 select ERROR_NUMBER() as Error_Number,
		   ERROR_MESSAGE() as Error_Message,
		   ERROR_SEVERITY() as Error_Severity,
		   ERROR_STATE() as Error_State
   end catch
End
Go

Exec sp_InsertDeptException @DeptNo=201,@DeptName='Warehouse',@Location='Pune',@Capacity=200;

Go

Create or alter Proc sp_MultiTableInsert
  @DeptNo int, @DeptName varchar(100), @Location varchar(100), @Capacity int,
  @EmpNo int, @EmpName varchar(200), @Designation varchar(200), @Salary int
As
Begin
	Begin Tran
	  Begin Try	
		-- Insert Dept
		Insert into Department (DeptNo, DeptName, Location,Capacity)
		Values
		(@DeptNo, @DeptName, @Location, @Capacity);
		-- Insert Emp
		Insert into Employee (EmpNo, EmpName, Designation, Salary,DeptNo)
		Values
		(@EmpNo, @EmpName, @Designation, @Salary, @DeptNo);
		 -- If No Error Coomit Transaction
		 COMMIT Transaction
	  End Try
	  Begin Catch
		-- Rollback Changes if Error Occurres
		ROLLBACK Transaction
	  End Catch	
End
Go

--Lets Success

Exec sp_MultiTableInsert @DeptNo=203, @DeptName='DEpt_203', @Location='Mumbai',@Capacity=2000, @EmpNo=707,@EmpName='Mahesh', @Designation='Manager',@Salary=40000;

Select * from Department;
Select * From Employee;





