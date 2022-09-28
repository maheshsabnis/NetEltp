// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Task task = Task.Factory.StartNew(() => {
    Print1();
}) ;

Task task1 = Task.Factory.StartNew(() => {
    Print2();
});

Task.WaitAll();
for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Main");
}

Console.ReadLine();

static void Print1()
{
    Console.WriteLine("Print 1");
}


static void Print2()
{
    Console.WriteLine("Print 2");
}




