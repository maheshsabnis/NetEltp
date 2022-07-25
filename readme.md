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


4. File IO
5. Database Programming
	- SQL Server
	- ORM

			
