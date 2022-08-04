# Assignments

# Date: 12-July-2022

1. Create a Console Application for math operations as follows
	- Add(), Subst(), Multi(), Devision(), Square(), SquareRoot(), Power()
		- ACcepts inputs from End-User using ReadLine()
2. Explore on
	- .NET COmmon Language Specification (CLS), Common Language Runtime (CLR) and Common Type System (CTS)

# Date: 13-July-2022

1. Ref, out, Params
2. Use the Following STring 
"The James Bond series focuses on a fictional British Secret Service agent created in 1953 by writer Ian Fleming, who featured him in twelve novels and two short-story collections. Since Fleming's death in 1964, eight other authors have written authorised Bond novels or novelisations: Kingsley Amis, Christopher Wood, John Gardner, Raymond Benson, Sebastian Faulks, Jeffery Deaver, William Boyd, and Anthony Horowitz. The latest novel is Forever and a Day by Anthony Horowitz, published in May 2018. Additionally Charlie Higson wrote a series on a young James Bond, and Kate Westbrook wrote three novels based on the diaries of a recurring series character, Moneypenny.

The character—also known by the code number 007 (pronounced "double-O-seven")—has also been adapted for television, radio, comic strip, video games and film. The films are one of the longest continually running film series and have grossed over US$7.04 billion in total, making it the fifth-highest-grossing film series to date, which started in 1962 with Dr. No, starring Sean Connery as Bond. As of 2021, there have been twenty-five films in the Eon Productions series. The most recent Bond film, No Time to Die (2021), stars Daniel Craig in his fifth portrayal of Bond; he is the sixth actor to play Bond in the Eon series. There have also been two independent productions of Bond films: Casino Royale (a 1967 spoof starring David Niven) and Never Say Never Again (a 1983 remake of an earlier Eon-produced film, 1965's Thunderball, both starring Connery). In 2015, the series was estimated to be worth $19.9 billion,[1] making James Bond one of the highest-grossing media franchises of all time."
- Perform FOllowing OPerations
	- Serious Note
		- Do not use Google with Ready COde
	- Count Words
	- Count Statements
	- Change first Characher of Each word in Upper case
	- Findout the special Characters in the string
	- Count of Blank Spaces
	- Print indexes where digits are used in string
String class
	- substr()
	- length
	- ToLower()
	- ToUpper()
Char class
	- Chat.IsUpper()

# 15-July-2022
Implement the following problem statments using Switch-Case in do..while loop
1. Create an Array of Strings and Sort and reverse the array based on Length of each string from array
2. Create an Array of integers and print index of even and odd number from the array
3. Create an Array of integers and print an index of prime numbers from the array
4. Create an Array of Strings and print only those strings that contains 'a' in it at any position in that string
5. Create an Array of Strings and print only those strings that starts from 'A' or 'M', or 'K' from the array
6. Create an Array of Strings and Find out count of repeated strings in an array and print them on console
	- e.g.
		- The 'Mahesh' appears 4 times in array
7. Reapeat the same problem statement 6 for integer arrays 
8. Repeate Tassks from 1 to 7 by using List of string and List of integeres 
9. Explore Following
	- C# Coding Practices
	- Take an experience of Single-File Publish in .NET Core
	- Read about KeyValuePair K,V class, HashSet class, and Dictionary .
		- https://www.dotnetcurry.com/csharp/1362/hashset-csharp-with-examples4

# Date:19-July-2022

1. Modify the Staff class with following Logic for validating Properties
	- StaffId shoud not be -Ve
	- StaffName must not have special Characters
	- DeptName, MUST be one of the following
		- Cancer, Heart, Pathology, Radiology, Bloob Bank, Organs, Orthopeic, Eye, Dental
	- StaffCategory, MUST be one of the following
		- Doctor, Nurse, Wardnboy, Brother, Technician
	- ALl String values are mandatory
2. USe Switch Case for all CRUD Operations

# Date:20-July-2022 

1. Create a Staff Class with Following Properties
	 public int StaffId { get; set; }
        public string StaffName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public int ContactNo { get; set; }
        public string? Education { get; set; }
        public int ShiftStartTime { get; set; }
        public int ShiftEndTime { get; set; }
        public int BasicPay { get; set; }
2. Create Doctor, Technician, Nurse classes derived from the Staff Class with their respective properties (YOU PLAN and THINK OF PROPERTIES)
3. Create DoctorLogic, TechnicianLogic, NurseLogic classes for performing CRUD OPerations in Memory using the Dictionary Collection.
4. Perform the following operations


	- List all Doctors of Specific 'Specialization' e.g. MBBS
	- Calculate Income for Each Staff and show it when the StaffId is entered to get details
	- Search Doctor / Nurse / Technician based using Name
		- If Names are same then return mutiple records


# Date 21-July-2022

1. Modify an assignment of 20-July-2022 by adding A StafLogic abstract class with following methods
		- GetGroddIncome()
		- GetTax()
		- GetNetIncome()   
Also add an Accountant class. THis class MUST have following method
	- GetIncome(StaffLogic staff)
		- The ABove method should return an income of any staff (Doctr,Nurse, Technician, Driver, etc) based on the Is-a relaionship of the StaffLogic class

# Date: 27-July-2022

1. Make sure that, when the New Staff is Added/Updated/Deleted the Norification is generated to the Main() method
2. Modify the APplication of date 26-July-2022 by adding Logic for Calculating Salary for each Staff. Display UI as Below

NAme:				Staff Id:				StaffType: 
=================================================================
Income Details	
=================================================================
BAsic Pay
(Othe Details According to Staff Type)

=================================================================
Gross Income: In Words and Digits
=================================================================
Hospital Share: In Words and Digits
=================================================================
Tax Paid: In WOrds and Digits
=================================================================
Net Income: In Words and Digits
=================================================================

# Date :28-July-2022
1. MOdify the class fr STring Operations on 13-July-2022 using extenion methos for 'STring' class

# Date:01-Aug-2022

1. Create a Collection of EMployees and Departments
	- Department: DeptNo,DeptNAme, Capacity, Location
		- Departments COllection: Min 20 Records
	- Employee: EmpNo, EmpName, Designation, Salary, DEptNo
		- Departments: MIn 50 Records
2. Print Maximum Salary Per Department with EMpNo and EmpName
3. Print Sum of Salary Group by DeptName 
4. Print Employee Details Per DEptName
5. Print Count of Employees working per Location 
6. Print EMployees details working Per Location

# Date 03-Aug-2022
	
1. (On SPOT) MOdify the CS_FirstFile Project with File Operation class with following required methods
	- MAke sure that all Methods should first Check an extension as '.txt' else the error Must be thrown
		- HINT: String.substr('.')
	- The CReate Method MUST accept 2 paraeters
		- Parameter 1: Directory
		- Parameter 2: File
	- Read/Wite/Append Methods MUST accept 3 paraeters
		- Parameter 1: Directory
		- Parameter 2: FileName
		- Parameter 3: the Data
			- For Read the 3rd parameter MUST be out
	- Move the file to Other Folder
	- ENcrypt and DEcryp the File
	- Delete The File (MUST be the last Operation)
2. Create Salary Slip for each Staff (Modify 27-July-2022 Project)


# Date:04-Aug-2022
1. CReate a File USing FileSTream. Using the StreamWriter Add Staff Records (Doctor, Nurses, Technician) in it (MIn 50 Records).
2. Create a class with Following Methods to perform OPerations on the File
	- ReadStaffByCategory(string staffCategory)
		- This should return staff based on the staffCategory e.g. staffCategory=Doctor will return all doctors
	- CheckIfTheStaffExsist(int StaffId)
		- This will return the Staff based on the StaffId
	- ReadRecordsByCount(int count)
		- This will return records from the file based on the COunt
	- DeleteStaffById(int StaffId)
		- This will delete the records by StaffIf
	- UpdateStaffById(int StaffId)
		- This will update record by StaffId
3. Explore The MemoryStream and NetworkStream class
	- Write a C# code that will read an Image File and Print its details as follows
		- FileName
		- FileSize
		- Extension
	- Write a C# Code that will convert the Byte Array into Image and Image into Byte Array
4. Write a C# COde to Read All Files from a DIctionary and its SubDirectories an print its details as follows
	- FileName	FileSize	DateCreated	DateMOdified
5. Write a C# COde that will copy all files from SourceDIrectory to TargetDictory
	