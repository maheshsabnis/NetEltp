using CS_Generic;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using Stack");

GenericStack<int> stkInt = new GenericStack<int>();

stkInt.Push(10);
stkInt.Push(20);
stkInt.Push(30);
stkInt.Push(40);
stkInt.Push(50);

Console.WriteLine("List");
foreach (var item in stkInt.GetMembers())
{
    Console.WriteLine(item);
}
Console.WriteLine();
Console.WriteLine($"Poped Item = {stkInt.Pop()}");
Console.WriteLine();
GenericStack<string> stkString = new GenericStack<string>();
stkString.Push("A");
stkString.Push("B");
stkString.Push("C");
stkString.Push("D");
stkString.Push("E");
Console.WriteLine();
foreach (var item in stkString.GetMembers())
{
    Console.WriteLine(item);
}

Console.WriteLine();

Staff staff1 = new Staff() { StaffId = 1, StaffName = "A" };
Staff staff2 = new Staff() { StaffId = 2, StaffName = "B" };
Staff staff3 = new Staff() { StaffId = 3, StaffName = "C" };
Staff staff4 = new Staff() { StaffId = 4, StaffName = "D" };
Staff staff5 = new Staff() { StaffId = 5, StaffName = "E" };

GenericStack<Staff> staffStack = new GenericStack<Staff>();
staffStack.Push(staff1);
staffStack.Push(staff2);
staffStack.Push(staff3);
staffStack.Push(staff4);
 



Doctor doc1 = new Doctor() { StaffId = 101, StaffName = "D1", Education = "E1", Specilization = "S1" };

 staffStack.Push(doc1);

Console.WriteLine();
Console.WriteLine(JsonSerializer.Serialize(staffStack.GetMembers()));


ConstraintsStack<Doctor> doctorStack = new ConstraintsStack<Doctor>();





Console.ReadLine();
