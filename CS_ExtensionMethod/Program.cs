using CS_ExtensionMethod;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Demo Extension");
STringOperation op = new STringOperation();
string str = "C# is great.";
Console.WriteLine($"Length of {str} = {op.GetLength(str)}");
Console.WriteLine($"Upper Case {str} = {op.ChangeCase(str, 'u')}");
Console.WriteLine($"Lower Case {str} = {op.ChangeCase(str, 'l')}");
Console.WriteLine($"Reverse of {str} = {op.ReverseString(str)}");

string MyString = "I am Wrath";
Console.WriteLine($"Reverse of {MyString} = {MyString.ReverseExt()}");
List<string> list = new List<string>();
list.Concat();

Console.ReadLine();
