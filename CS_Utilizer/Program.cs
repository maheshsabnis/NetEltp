using CS_Utilities;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Utilizer to Call Utility Library");


IStringUtilities ops = new StringOperations();

var res = ops.GetLength("GGGGG");

MyClass m = new MyClass     ();

m.Print();

m.Print1();
 

Console.ReadLine();


public class MyClass : StringOperations
{
    public void Print()
    {
        base.PrintMessage("HHDHDHD");
    }
    public void Print1()
    {
        base.PrintMessageNew("ffffff");
    }
}
