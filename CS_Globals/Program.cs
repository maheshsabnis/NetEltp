using CS_Globals;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Global Access");

Standard s1 = new Standard();
s1.Increment();
s1.Decrement();


Standard s2 = new Standard();

Console.WriteLine(s1 == s2);

s2.Increment();
s2.Decrement();


Console.ReadLine(); 
