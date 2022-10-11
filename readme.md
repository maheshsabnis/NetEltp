#.NET 6 Programming for C#
1. Language Specifications
	- Data Types, Value Types and Reference Types
		- Numeric
Data Type		Keyword			TypeName		Size (in bytes)
Byte			byte			System.Byte		1	
Short			short			System.Int16	2
Ushort			ushort			System.UInt16	2
Integer			int				System.Int32	4
Unsigned Int	uint			System.UInt32	4
Long			long			System.Int64	8
ULong			ulong			System.Int64	8
FLoating		float			System.Float32	4
Duble			double			System.Float64	8
Decimal			decimal			System.Decimal	16


		- Character
Character		char			System.Char		2 for Unicode
String			string			System.String	2 * Length, The Reference Type
		- Boolean
Boolean			bool			System.Boolean	1 byte	
		- Date
Date			datetime		System.DataTime	10 mm/dd/yyyy, UTC Support

- The Reference Types
	- Object
	- String
	- Array
	- Collections

- Data Conversion
	- The 'Convert' class under the 'System' NAmespace
	- Convert.ToInt32("STRING"), ToFloat32() ToDate(), ToBoolean(), etc.
	- The 'ToString()' method of 'Object' to convert the value into string


	- Input Output Statements
		- Namsepsace
			- Group of CLasses as well as child namespaces
				- Standard 
					- System, a top level namespace
				- Custom
					- Each Project Name is namespace by default
		- The System.Console
			- The Console Class
				- Console.WriteLine(), the Output Statement
					- WriteLine(), is a Method
				- Console.ReadLine(), the Input Statement
					- ReadLine(), is a method
		- Namespace Fact
			- TO use a class in .cs file, the namespace under which the class is defined MUST be used in the class file as follows
				 - using [NAMESPACE-NAME]
				 - e.g.
					- using System;

	- Programming Constructs
		- Operators
			- +,-,*,/
				- The '+' is by default overloaded for 'String Concatenation' if both operands are string
					- if a and b are string
						- a + b, it will be concatenation	
			- ++, --, +=,-=
			- >,<,>=, <=, !=, ==
			- ! (nor or not), || (or), && (and)
			- Using Template string or String Interpolation
				- New syntax for String Conctenation
				- e.g.
					- string fname="James";
					- string lname ="Bond";
					- Older way
						- "The Name is " + fname +  lname +
					- Newer Way
						- $"The Name is {fname} {lname}"
							- The Name is James Bond
- Common Language Specifications (CLS)
	- Rules
		- Evaluate LHS = RHS
- CTS
	- Data Types
	- Value Types
	- Reference Types
		- Object
		- System.Type
			- Type, the highest level type class that define structure for every data type
- BCL or FCL
	- STandard Set of .NET CLasses grouped under their NAmespaces
		- Nmespaces under Assemblies
			- Assembly is a Compiled Output of each .NET App
				- .exe or .dll
			- Each Assembly is NAmespace and it contains set of classes in it
				- EAch .NET Project is assembly by itself
		- System.dll
			- System.Data.dll
			- System.IO.dll
		- Microsoft.NetCore.App (The BCL for .NET COre Apps)
			- .NET 5,6, FRamework with its assemblies in it
- Common Language Runtime
	- SIngle File Publish
		- Compile and Build the Entire Project into a Single Exe for the Platform
# Programming
1. Foundation of C# for Value ad Reference Types
	- Methods
		- Repetative Statements put inside a named block which will be accessible whenever and whereever it is needed
			- Method which does not return anything
				- One-Way Method
			- Methods with retutrn Value
				- Two-Way Method
		- Method my or may not have input parameters aka arguments aka Formal Parameters	
	- integer * interger is integer
	- integer / integer is integer
		- For Logically Accurate Result Try one of the following
			- Either Type-Cast the Result
				- This will not work for Result Coversion, recommended to avoid it
				- Instead Try to Type-Cast the Data Type of Operand

			- Or Change the datatype from integer to more size data type as per the requirements
		- Use of 'var'
			- Introduced in C# 3.0 on .NET Frwk 3.5 to make sure that the result of expressions are stored w/o any type-casting
				- Use this in case where we cannot predict the result from the expression
				- The Compiler will evaluate the expression and set the type of 'var' to the actual data type of the resultant
			- The 'var' is only available within the method scope
			- The 'var' declaration MUST be initialized
			- The 'var' cannot bt input and output parameter to a method
			- Once the compiler set the data type for 'var' it cannot be changed
	- ref, out, params
		- ref: Pass the Reference, while passing reference of vaiable, the initial value for the variable MUST be present
		- out: PAss the reference, same as 'ref' but not initial value is required
		- params: Pass variable number of parameters
2. Collection Framework
	- Collection Classes
		- .NET Frwk 1.0 to 4.x (Alseo in .NET Core)
		- Each ENrty in Colletion is Object
		- System.Collections Namespace
			- ArrayList, Stack, LinkedList, Queue, etc.
	- The Array class
		- reference Type
		- System.Array
			- When we declare an array of any type, it by default is an instance of array class
			- Use 'new' to instantiate it
			- The identitifer for array is an instance of array class and hence it has access to all non-static array methods
			- e.g.
				- int[] arr = new int[5];
					- the 'arr' is an identifier which is an instance of 'Array' class
			- Can store data of 'Same-Type' in fix size length
		- Enumerations
			- Start Reading from the first record (aka 0th index) and conytinue search and read next record till end-of-collection is not reached.
				- MoveNext() and Current
					- Current is a record which is fetched while enumerating (reading) and MoveNext() will check if there is next record presewnt or exist into the collection 
	- WHile using collection use loops for reading/writing data from and to the collection	
		- for..loop
		- foreach..loop
			- Uses Enumeration internally
		- while..lopp
		- do..while loop
	- Collections
		- Ready-to-Use Data Structures for managing large amount of data in Application's memory
		- Each entry in collection is 'object'
			- Each value is converted into object (Box) and while extracting it is Unboxed to its original Data Type
		- Collections does not have any max limit to store data init like array
		- Primtive as well as custom types (User defined) classes can be added into the Collection
	- Generic Classes
		- Type-Safe Approach for stroing data in the form of Data Structure
			- Use the 'T' as Template for Single-Type Generic
			- For Complex Key:Value pair data structures use  K:V a multi-type generic
		- .NET Frwk 2+
		- Concurrent Classes
			.NET Frwk 4.x + and in .NET Core
		- Typesafe Data STructures having Binary Reusability of Data
			- USe 'T'
		- Generic Types
			- Class, Interface, Methods, Variable, Parameter, Event, Delegate
		- Class<T>
			- WHere T is .NET Type (Standard and Custom)
			- E.g.
				- T can int, string, bool, objet
				- Custom Classes e.g. Employee
		- Multi-Type Generic Classes
			- Class<K,V>
				- For Creation of Key,Value Pair or Dictionary type of data
		- System.Collections.Generic with all classes as Enumerable 
			- List<T>, Stakc<T>, Queue<T>, LinkedList<T>
				- T can be primitype or custom type
				- No Type-Casting is needed for storing and extracting data from it 
			- HashSet<K,V>, KeyValuePair<K,V>, Dictionary<K,V>

	- Reading Data from Collection Type
		- for..loop
		- foreach..loop
		- while..loop
		- do..while loop

3. OOPs

- Access Specifiers
	- private, public, protected
		- Private : Scope (accessible) only in the declaring class
		- proteted: Scope to declaring class and its derived class
		- public: scropt to entire app
	- internal
		- Scope to all classes in the declaring namespace
		- e.g.
			namespace n1 {  class C { internal x;} class A{  ths can access objc.x }  }
	- proteted internal
		- COmbinition of protected and internal
			- Scope with the namespace and in derived class of other namespace
- Contents of class
	- Data Members
		- With any access specifier as per the requirements
	- Member Functions aka Methods
		- With any access specifier as per the requirements
		- But to expose them use 'public'
	- Properties aka Fields
		- They are REad/Write methods on a private data memebr
		- get: to REad data for Private member
		- set: to write data to private member. THis can also cotains a logic for Private member validation
		- Syntax 1: [Access Specifier] [PROPERTY-NAME] {get;set;}  form C# 3.0+
		- SYntax 2:
			- [Access-Specifier] [PROPERTY-NAME]    Evergreen Syntax
			{
			    get { return PRIVATE_MEMBER}
				set {
				   ..... SOME LOGIC HERE
				   PRIVATE_MEMBER = value;
				}
			}
	- Class Instance Streregies
		- USe 'new'
		- The default ctor will be invoked
		- We can have Mutiple ctors in class

	- abstract, virtual are access modifiers

	- Sealed Class
		- Keyword is 'sealed'
		- Cannot be extended (aka inherited)
	- Generics
		- Class
		- Member
		- Method
		- Interface
		- Delegate
		- Event
	- Generic COntsraints
		- Restrict the T parameter to use a specific TYpe and its Derived Types for Instance creation
	- Extension Methods
		- The class tat defines etension method MUST be 'static'
		- This class will declare the method which is to be used as 'extension' as 'static'
		- THis method will accept the 'first parameter as "this" refered reference of the class (or interface)' for which the current method will be used as 'extension method'
		- e.g.
			- The class MyCLass
```` csharp
	public interface IClass {}
    public  class MyClass:IClass {}
	public class MyDerivedClass : MyClass {}
````

		    - The Extension Method class

```` csharp
     public static class MyExtensions 
	 {
	     public static void ExtMethod(this ICLass obj)
		 {
		 }
	 }
````

	- Language INtegrated Queries (LINQ)
		- Methods (Mostly Extension Methods)
			- OrderBy, OrderByDescending
			- Join
			- GroupBy
			- Set OPerators
				- Take
				- Skip
				- INtersect
				- Union
				- All
				- Any
			- Sum, Min, Max, Average
			- First, FirstOrDefault
			- Last, LastOrDefault
		- AsParallel

4. File IO
	- MAke sure that while using IOs use Exception Management
		- System.Exception
			- The Highes Leve Exception Class
			- Properties
				- Message: Provide An Exception Thrown by the code
				- InnerException: Errors in detail
		- Blocks
			- try {... CODE TO EXECUTE ...} catch(Exception ex){...AN EXCEPTION THROWN}finally {MANDATOY EXECUTABLE CODE}
			- FActs
				- one try can have multiple-Catch
					- catch(Specific Exception 1){....} catch(Specific Exception 2){....}.....catc(Exception ex){....}
				- We can throw exception conditionally
					if(CONDITION) throw new Exception("MESSAGE")
			- Rule to be followed while using an exe calling dll
				- MAke sure that if the method fromm the .dll throws an exception, then please catch it in a caller method from .exe
	- System.IO Namespace
		- Stream
			- Contineous Set of Data (CHaracter/Byte) organized in Order
			- FileStream
				- Text, Xml, Json, Binary Files
			- NetworkStream
				- Messaging across application using Network Protocol
			- MemoryStream
				- USed to Write (or generate) Binary Files with 'PLay' Sequence
					- Audio, Video, Images
		- StreamReader
			- Read Stream
				- A Line
				- To End
				- A Block with Spcific bytes
		- StreamWriter
			- Write STream
	- OS Levele File ACcess Classes
		- Directory and DirectoryInfo
			- Manage Directories
		- File and FileInfo
			- Manages Files 
# Casting
 Upcasting is conversion from a derived (child) class to a base (parent) class. Going up the family tree. Downcasting is the opposite going from a base class to a derived class, down the tree. We will also look at the as and is keywords.


# Upcasting
Circle circle = new Circle();
Shape shape = circle;  // upcasting

# Downcasting
--  At compile time it is a shape but at run time it will be Text.
Shape shape = new Text();

Text text = (Text) shape;  // downcasting!

Console.WriteLine(text.FontSize.ToString("F5"));




5. Threading
6. Database Programming
	- SQL Server
	- ORM
# Using ADO.NET
	The Connected Archi	
		- The client is always connected with Database
	- System.Data, the base namsepace
	- System.Data.SqlClient
		- SqlConnection, Connecto to Database
			- Sync and Asyc Methods
				- Open(), OpenAsync()
					- Used to Ope COnnection With Database
				- Close(), CLose Connection
			- The 'ConnectionStrng' property, accepts DB Connection String
			- BeginTransaction, starts and Monitors Transactions across Mutiple Table
		- SqlCommnad, USed to Execute SQL COmmands and SP
			- The CommandType Property
				- USed to define what type of command is passed to Database
					- CommandText, Select, Insert, Update, and Delete Queries
					- StoredProcedure, name of SP
					- Table, the direct table to read data
			- ExecureReader() and ExecureReaderAsync()
				- USed when COmmand Text is Select Query
				- Returns an instance of SqlDataReader
			- ExecuteNonQuery() and ExecuteNonQueryAsync()
				- USed when COmmand Text is DML Statement
				- Returns an int representing no. of records affected
			- ExecuteScalar() and ExecuteScalarAsync()
				- USed when COmand Text is either using select statement with scalar function or the Stored Proc
				- It returns a Single Value	
			- The 'Parameters' collection Property
				- ACcepts SqlParameters used in case when the QUERY or SP accepts parameters
				
		- SqlDataReader, Used to STore the resultSet aka Cursor
			- Represents a resutset that stored the result of select statement
			- REad-Only-Forward-Only cursor
				- STarts reading the first row onwards by default
			- The Read() method used to start reading
			- The Close() method to close Reader
			- We can have 'only-one reader' active over a connection by default
		- SqlParameter, Parameters to SPS

	- System.Data.OracleClient
	- System.Data.OleDbClient
	- System.Data.OdbcClient

- COnnection Strings
 - Using SL Server with WInows Auth
	- Data Source=[DB-INSTANCE-NAME | IP ADDRESS | localhost | .]; Initial Catalog=[DATABASE-NAME];Integrated Security=SSPI;
	- Server=[DB-INSTANCE-NAME | IP ADDRESS | localhost | .];Database=[DATABASE-NAME];Integrated Security=SSPI;
- Using SQL Server Authentication
	- Data Source=[DB-INSTANCE-NAME | IP ADDRESS | localhost | .]; Initial Catalog=[DATABASE-NAME];User Id=[USER-NAME];Password=[PASSWORD];
	- Server=[DB-INSTANCE-NAME | IP ADDRESS | localhost | .];Database=[DATABASE-NAME];User Id=[USER-NAME];Password=[PASSWORD];
- Using Multiple REaders over a connection aka MARS
	- Data Source=[DB-INSTANCE-NAME | IP ADDRESS | localhost | .]; Initial Catalog=[DATABASE-NAME];Integrated Security=SSPI;MultipleActiveResultSets=true;
- Connecting to Datbase aynchronously
	- Data Source=[DB-INSTANCE-NAME | IP ADDRESS | localhost | .]; Initial Catalog=[DATABASE-NAME];Integrated Security=SSPI;MultipleActiveResultSets=true;Asynchronous Processing=true


# ADO.NET DIsonnected Architecture

1.Establish Connection usin SqlConnecton
2. CReate a DataSet
	- DataSet Ds = new DataSet()
3. DEfine an Adapter
	- SQlDataAdpater Ad = new SqlDataAdapter(Conn, "PLain Select Statement")
		- The Table MUST have Primary Key
4. Fill Data into DataSet
	- Two Types of DataSets
		- Typed DataSet
			- The DataSet will fill data of table along ith all of its Constraints
		- UnTyped DataSet (DEfault)
			- Only Data will be present
	- Before Filling Data into the DataSet, ask adpater to read Keys and other Constraints
		- Ad.MissingShmaAction = MIssinSchemaAction.AddWithKey;
	- Ad.Fill(Ds,"TABLE-NAME");
5. STructrization
	- Ds.Tables, return DataTableCollection
	- Ds.Table[INDEX | TABLE-NAME], returns a DataTable
	- DataTable Dt = new DataTable()
		- Dt.Columns, return DataColumnCollection
		- Dt.Column[INDEX | COLUMN-NAME], returns a Single DataColumn 
		- Dt.Rows, return DataRowCollection
		- Dr.Rows[INDEX], return a Single DataRow
6. Adding a New Row in DataTable of DataSet
	- First CReate a DataRow Object That points to New Row of DataTable in DataSet
		- DataRow Dr = Ds.Tables["NAME"].NewRow();
	- Set the Column Values for Row
		- Dr["COLUMN-NAME" | IDNEX] = VALUE;
	- Add this Row in Rows COllection of DataTable in DataSet
		- Ds.Tables["TABLE-NAME"].Rows.Add(Dr);
	- Define a COmmand Builder and PAss Adapater to It
		- SqlCOmmandBuilder bldr = new SqlCommandBuilder(Ad);
	- Call Update Method on Data Adpater
		- Ad.Update(Ds, "TABLE-NAME");
7. Update Record
	- Search Record based on Primary Key (Typed DataSet)
		- DataRow DrFind = Ds.Tables["TABLE-NAME"].Rows.Find(PRIMARY-KEY-VALUE);
	- Update Colum Valus for Searched DataRow Object
	- Call COmmand Builder
	- Ad.Update(Ds,"TABLE-NAME");
8. Delete Record
	- Search Record based on Primary Key (Typed DataSet)
		- DataRow DrDelete = Ds.Tables["TABLE-NAME"].Rows.Find(PRIMARY-KEY-VALUE);
		- DrDelete.Delete()
	- Call COmmand Builder
	- Ad.Update(Ds,"TABLE-NAME");