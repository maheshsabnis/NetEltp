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
	- Generic Classes
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
	- Reading Data from Collection Type
		- for..loop
		- foreach..loop
		- while..loop
		- do..while loop

3. OOPs
4. File IO
5. Database Programming
	- SQL Server
	- ORM

			
