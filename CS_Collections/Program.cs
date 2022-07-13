using System.Collections;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Collections");

int i = 10;
Console.WriteLine($"Type of i = {i.GetType()} and value of i = {i}");
object obj = i; // Storing i into object BOXING
Console.WriteLine($"Type of obj = {obj.GetType()} and Value in obj = {obj}");

int j = (int)obj; // Casting to retrieve data from Object UNBOXING
Console.WriteLine($"j = {j}");

ArrayList arrayList = new ArrayList();
arrayList.Add(10);
arrayList.Add(20);
arrayList.Add(30);
arrayList.Add("Mahesh");
arrayList.Add("Tejas");
arrayList.Add('A');
arrayList.Add('B');
arrayList.Add(10.10);
arrayList.Add(20.10);


for (int k = 0; k < arrayList.Count; k++)
{
    if (arrayList[k].GetType() == typeof(int))
    {
        Console.WriteLine($"TYpe of {arrayList[k].GetType()} Value = {arrayList[k]} ");
    }
}


Stack stack =   new Stack();

SortedList list = new SortedList();


Console.ReadLine();


