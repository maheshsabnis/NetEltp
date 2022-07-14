
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Ref and Out");

int x = 10, y=20;
Console.WriteLine($"Before XChange x = {x} and y = {y}");
// PAss by value for x and y to mathod
XChange(x,y);
Console.WriteLine($"After XChange x = {x} and y = {y}");
Console.WriteLine("Pass By reference");
XChangeByRef(ref x,ref y);
Console.WriteLine($"After XChangeByRef x = {x} and y = {y}");

double Salary = 450000;
double HRA;
double TA;
double GrossSalary;
double Tax;
double NetSalary;
/// The out parameter will take reference of the variable and pass to the method
/// The method has to manipulate the value for the out parameter and send back to the caller
CalculateSalaryDetails(Salary, out HRA, out TA, out GrossSalary, out Tax, out NetSalary);

Console.WriteLine($"Salary : {Salary}");
Console.WriteLine($"HRA :    {HRA}");
Console.WriteLine($"TA : {TA}");
Console.WriteLine($"Gross Salary : {GrossSalary}");
Console.WriteLine($"Tax : {Tax}");
Console.WriteLine($"Net Salary : {NetSalary}");



Console.ReadLine();

static void XChange(int a,int b)
{
    Console.WriteLine($"Before XChange in Method a = {a} and b = {b}");
    int c = a;
    a = b;
    b = c;
    Console.WriteLine($"After XChange in Method a = {a} and b = {b}");
}

/// Lets accept references for x and y
static void XChangeByRef(ref int a, ref int b)
{
    Console.WriteLine($"Before XChange in Method a = {a} and b = {b}");
    int c = a;
    a = b;
    b = c;
    Console.WriteLine($"After XChange in Method a = {a} and b = {b}");
}

/// The out parameter MUST be manipulated by the method

static void CalculateSalaryDetails(double sal, out double hra, out double ta, out double gross, out double tax, out double netsal)
{
    hra = sal * 0.05;
    ta = sal * 0.07;
    gross = sal + hra + ta;
    tax = gross * 0.2;
    netsal = gross - tax;
}