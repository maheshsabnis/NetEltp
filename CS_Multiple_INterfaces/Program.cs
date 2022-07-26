using CS_Multiple_INterfaces.Models;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using Mutiple Interfaces");

FileOperations fileOP = new FileOperations();

((ITextFile)fileOP).CreateFile("f.txt");
((ITextFile)fileOP).ReadFile("f.txt");


// Logic for Text Complited Polymorphism using INterfaces
ITextFile text = new FileOperations();
text.CreateFile("f1.txt");
text.ReadFile("f1.txt");
// Logic for XML Complited Polymorphism using INterfaces
IXmlFile xml = new FileOperations();
xml.CreateFile("f1.xml");
xml.ReadFile("f1.xml");

Console.ReadLine();
