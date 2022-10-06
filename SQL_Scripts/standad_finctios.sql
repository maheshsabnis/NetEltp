SELECT CONCAT('webnethelper', '.com');

SELECT 'WebNetHelper' + '.com';

-- The CONCAT_WS() function adds two or more strings together with a separator.

SELECT CONCAT_WS('.', 'www', 'webnethelper', 'com');

SELECT DATALENGTH('webnethelper.com');

-- Compares two SOUNDEX values, and return an integer:

-- The DIFFERENCE() function compares two SOUNDEX values, and returns an integer. 
--The integer value indicates the match for the two SOUNDEX values, from 0 to 4.
SELECT DIFFERENCE('MAhesh', 'Mahesh');
 
-- Fromat

DECLARE @d DATETIME = '12/01/2018';
SELECT FORMAT (@d, 'd', 'en-US') AS 'US English Result',
               FORMAT (@d, 'd', 'no') AS 'Norwegian Result',
               FORMAT (@d, 'd', 'zu') AS 'Zulu Result',
			   Format(@d, 'd', 'hi-IN') AS 'India';


-- SQL Reverse

SELECT REVERSE('MAhesh Sabnis');

-- The RIGHT() function extracts a number of characters from a string (starting from right).
SELECT RIGHT('MAhesh Sabnis', 3) AS ExtractString;

-- The SUBSTRING() function extracts some characters from a string.
SELECT SUBSTRING('Mahesh Sabnis', 1, 3) AS ExtractString;

-- The CAST() function converts a value (of any type) into a specified datatype.
SELECT CAST(25.65 AS int);

-- The CONVERT() function converts a value (of any type) into a specified datatype.

SELECT CONVERT(int, 25.65);

SELECT CURRENT_USER;

-- The IIF() function returns a value if a condition is TRUE, or another value if a condition is FALSE.

SELECT IIF(700<1000, 'YES', 'NO');

-- ISNULL, ISNUERIC

SELECT ISNULL(NULL, 'webnethelper.com');
declare @x varchar(30);
set @x = 'ss';
SELECT ISNUMERIC(@x);

-- User Defined Functions

-- Table-Valued Functions
-- Scalar Valued Functions
Go
-- Table VAlued Function
Create function Fun_EmployeeList()      
returns table       
as      
return(select * from Employee  )  


select * from Fun_EmployeeList()  ;
Go
-- Scalar FUnction
create function Fun_JOINCOLUMNS  
(  
   @EmpName varchar(200),  
   @Designation varchar(200) 
)  
returns varchar(400)  
as  
begin 
	return(select @EmpName+ ' ' +@Designation )  
end  


select  dbo.Fun_JOINCOLUMNS ('Mahesh', 'Director') as Details;