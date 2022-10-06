-------------------------------
-- Annonymous Blocks
-------------------------------
 
DECLARE
        @v_int int
BEGIN
        SET @v_int = 5
        PRINT @v_int
END
 
------------------------------
-- Named Programs
-- 1. Procedures
-- 2. Functions
-- 3. Triggers
------------------------------
 
------------------------------
-- Procedures
------------------------------
USE Northwind
GO
 
-- CREATE
CREATE PROCEDURE myfirstproc
AS
DECLARE
        @v_int int
BEGIN
        SET @v_int = 5
        PRINT @v_int
END
 
EXEC myfirstproc
 
GO
-- ALTER 
 
ALTER PROCEDURE myfirstproc
AS
DECLARE
        @v_int int
BEGIN
        SET @v_int = 10
        PRINT @v_int
END
 
EXEC myfirstproc
 
-- DROP 
 
DROP PROCEDURE myfirstproc
 
-- P1
GO
 
--------------------------------------------------
--empName
--------------------------------------------------
 
CREATE PROCEDURE empName
AS
DECLARE
        @v_name varchar(25)
BEGIN
        SELECT @v_name = FirstName
        FROM employees
        WHERE employeeID = 5
        PRINT @v_name
END
 
-- Procedure with parameters 
 
GO
 
ALTER PROCEDURE empName
(@p_empid int)
AS
DECLARE
        @v_name varchar(25)
BEGIN
        SELECT @v_name = FirstName
        FROM employees
        WHERE employeeID = @p_empid
        PRINT @v_name
END
 
EXEC empName 5
 
EXEC empName 6
 
--------------------------------------------------
-- emp_for_raise_proc
--------------------------------------------------
 
SELECT * FROM employees
GO 
 
CREATE PROCEDURE emp_for_raise_proc
(@p_empid int)
AS
DECLARE
        @v_empcity varchar(25),
        @v_empname varchar(25)
BEGIN
        SELECT @v_empcity = city , @v_empname = lastName
        FROM employees
        WHERE employeeID = @p_empid
 
        IF @v_empcity = 'London'
        PRINT 'This employee is up for a raise (go london !) --&amp;gt; ' + @v_empname
        ELSE
        PRINT 'This employees is not up for a raise -- &amp;gt; ' + @v_empname
END
 
EXEC emp_for_raise_proc 5
 
EXEC emp_for_raise_proc 1
 
------------------------------------------
-- P2
------------------------------------------
GO
 
Create PROCEDURE check_price_proc
(@p_productID  int)
AS
DECLARE
    @v_unitPrice int  ,
    @v_productName varchar(25)
BEGIN
    SELECT @v_unitPrice = unitPrice , @v_productName = productName
    FROM products
    WHERE productID = @p_productID
 
    PRINT 'Current unitPrice is : ' +  CAST(@v_unitPrice AS VARCHAR) + ' (' + @v_productName + ')'
 
    IF @v_unitPrice > 50
    PRINT 'Greater than 50'
    ELSE IF @v_unitPrice = 50
    PRINT 'Equal to 50'
    ELSE
    BEGIN
        PRINT 'Less than 50'
        UPDATE products SET unitPrice = unitPrice * 1.1 WHERE productID = @p_productID
        -- Print new price
        SELECT @v_unitPrice = unitPrice , @v_productName = productName
        FROM products
        WHERE productID = @p_productID
        PRINT 'Current unitPrice is : ' +  CAST(@v_unitPrice AS VARCHAR) + ' (' + @v_productName + ')'
    END
END
 
EXEC check_price_proc 13
 
SELECT productID  FROM products WHERE unitPrice <50 
 
-----------------------------------
-- Procedure with cursor
-----------------------------------
GO 
 
Create PROCEDURE price_range_proc
(@p_minprice int ,
 @p_maxprice int )
 AS
 DECLARE
    products_range_cur CURSOR FOR
    SELECT productName , unitPrice
    FROM products
    WHERE unitPrice BETWEEN @p_minprice AND @p_maxprice
DECLARE @v_unitPrice int ,
        @v_productName varchar(25)
 BEGIN
    OPEN products_range_cur
 
    FETCH NEXT FROM products_range_cur INTO @v_productName , @v_unitPrice
    WHILE @@FETCH_STATUS = 0
    BEGIN
            PRINT @v_productName + ' ' + CAST (@v_unitPrice AS VARCHAR)
            FETCH NEXT FROM products_range_cur INTO @v_productName , @v_unitPrice
    END
 
    CLOSE products_range_cur
    DEALLOCATE products_range_cur
 END
 
EXEC price_range_proc 50 , 51 
 
-----------------------------------
-- OUT PARAMETER
-----------------------------------
 
ALTER PROCEDURE empName
(@p_empID int,
 @p_firstName varchar(25) OUTPUT)
AS
DECLARE
        @v_name varchar(25)
BEGIN
        SELECT @v_name = FirstName
        FROM employees
        WHERE employeeID = @p_empID
        --PRINT @v_name
        SET @p_firstName = @v_name
END
 
DECLARE
    @v_catch_name varchar(25)
BEGIN
    EXEC empName 5, @v_catch_name OUTPUT
    PRINT @v_catch_name
END
 
-- P5/6
 
ALTER PROCEDURE procName_proc
(@p_productID  int,
 @p_productName varchar(25) OUTPUT ,
 @p_status int OUTPUT )
AS
DECLARE
        @v_name varchar(25) ,
        @v_price int
BEGIN
        SELECT @v_name = productName , @v_price = unitPrice
        FROM products
        WHERE ProductID  = @p_productID
        --PRINT @v_name
        SET @p_productName = @v_name
 
        IF @v_price &amp;gt; 50
        SET @p_status = 1
        ELSE
        SET @p_status = 0
END
 
DECLARE
    @v_catch_name varchar(25) ,
    @v_catch_status int
BEGIN
    EXEC procName_proc 5, @v_catch_name OUTPUT , @v_catch_status OUTPUT
    PRINT @v_catch_name
    PRINT @v_catch_status
END
 
-----------------------------------
-- Functions
-----------------------------------
GO
 
CREATE FUNCTION dbo.add_maam
(@num_to_plus_maam MONEY)
RETURNS MONEY
BEGIN
        RETURN @num_to_plus_maam*1.18
END
 
SELECT dbo.add_maam(100)
 
SELECT productName , unitPrice ,dbo.add_maam(unitPrice)
FROM products 