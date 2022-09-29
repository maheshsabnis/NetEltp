// See https://aka.ms/new-console-template for more information
Console.WriteLine("THrow An Exception From TAsk BAsed Method");

try
{
	Console.WriteLine("Enter x");
	int x = Convert.ToInt32(Console.ReadLine());
	Console.WriteLine("Enter y");
	int y = Convert.ToInt32(Console.ReadLine());

	Task<int> task = Task.Factory.StartNew<int>(() => { return Divide(x, y); });

	Console.WriteLine($"Result of Division is = {task.Result}");
}
catch (Exception ex)
{
	Console.WriteLine($"Error Occurred = {ex.Message}");
}

Console.ReadLine(); 

static int Divide(int x,int y)
{
    if (y == 0)
        throw new Exception("Denominator Cannot be 0");
    return x / y;
}
