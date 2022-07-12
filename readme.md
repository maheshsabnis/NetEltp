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
