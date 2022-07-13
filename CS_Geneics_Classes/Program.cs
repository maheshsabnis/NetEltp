// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<int> lstInt = new List<int>();
lstInt.Add(10);
lstInt.Add(20);
lstInt.Add(30);
lstInt.Add(40);

Console.WriteLine($"{lstInt.IndexOf(30)}");

List<string> lstString = new List<string>();
lstString.Add("Tejas");
lstString.Add("Mahesh");
lstString.Add("Ramesh");
lstString.Add("Tushar");
Console.WriteLine("Before SOrt");
foreach (string str in lstString)
{
    Console.WriteLine(str);
}

Console.WriteLine();
lstString.Sort();

Console.WriteLine("After SOrt");
foreach (string str in lstString)
{
    Console.WriteLine(str);
}

Console.WriteLine();
lstString.Reverse();

Console.WriteLine("After SOrt");
foreach (string str in lstString)
{
    Console.WriteLine(str);
}

string[] arr = new string[] { "JB", "EH" };

lstString.AddRange(arr);

foreach (string str in lstString)
{
    Console.WriteLine(str);
}
Console.ReadLine();