using CS_Simple_Interface.Models;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("SImple Interface");

// SimpleMath math = new SimpleMath();

// Define an Instance for Interface Reference using the Class THat is implementing the interface


ISimpleMath math = new SimpleMath();

Console.WriteLine($"Add = {math.Add(3,4)}");
Console.WriteLine($"Sub = {math.Sub(4,6)}");

// USe of Interface Reference is Mandatory for class
// If the class is implementing interface explicitly
ISimpleMath objM = new ExplicitMath();

Console.WriteLine($"Add Explicit = {objM.Add(30,40)}");
Console.WriteLine($"Sub Explicit = {objM.Sub(44,3)}");




Console.ReadLine(); 
