// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using Dictionary");

Dictionary<int, string> names = new Dictionary<int, string>();

Console.WriteLine("Insert Data into DItionary");
int i = 0;

for (int count = 0; count <=10; count++)
{
    string name = Console.ReadLine();
    names.Add(i++, name);
}

foreach (string record in names.Values)
{
    Console.WriteLine($"NAme = {record}");
}
Console.WriteLine("Enter index to serach name");
int index = Convert.ToInt32(Console.ReadLine());
names.TryGetValue(index, out string searchedname);
Console.WriteLine($" Name at {index} is {searchedname}");


Dictionary<int, List<string>> compleDict = new Dictionary<int, List<string>>();

 


Console.ReadLine();


