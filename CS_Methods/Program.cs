// See https://aka.ms/new-console-template for more information

/// Default Masin Method Code
/// The Main() method is implicit
Console.WriteLine("C# Methods");
PrintMessage();
// a variable
string Message = "I am a Parameter";
// The Message is an Actual Parameter
DisplayMessage(Message);

// Actual Parameter
double num1 = 30;
double num2 = 15;
// RaisedTo() method return value which MUST be collected by Caller Method (Here it is Main()) 
double Power = RaisedTo(num1,num2);
Console.WriteLine($"{num1} raised to {num2} is =  {Power}" );

int a, b;

Console.WriteLine("Enter value of a");
a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter value of b");
b = Convert.ToInt32(Console.ReadLine());

decimal ResultMultiply = Convert.ToDecimal(a * Convert.ToDecimal(b));

Console.WriteLine($"Multiplication of {a} and {b} is = {ResultMultiply}");

decimal ResultDivide = Convert.ToDecimal(a / Convert.ToDecimal(b));
Console.WriteLine($"Division of {a} and {b} is = {ResultDivide}");






Console.ReadLine();



// a One-way method that does not return anything
static void PrintMessage()
{
    Console.WriteLine("Hello Print Message");
}
/// Method with input parameter
/// str is formal parameter
static void DisplayMessage(string msg)
{
    Console.WriteLine($"The Message is {msg}");
}

///Method with Rteun value aka Two-Way Method
static double RaisedTo(double x, double y)
{ 
    double resultRaisedTo = Math.Pow(x, y);
    return resultRaisedTo;
}
