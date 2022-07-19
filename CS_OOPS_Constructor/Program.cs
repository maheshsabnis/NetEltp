// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Constructor");

// 1. Lets instantiate the class
// The 'new' is nmoniker aka Operator that is used to infor
// the runtime that the 'MEMORY-MUST-BE-ALLOCATED'
Message msg = new Message("MAhesh");


msg.PrintMessage("This is OOPs");
msg.DisplayMessage();   
Console.ReadLine();



public class Message
{
    string mystr;
    //public Message()
    //{
    //    Console.WriteLine("Default Constructor Called");
    //}

    public Message(string str)
    {
        mystr = str;
    }

    public void PrintMessage(string str)
    {
        Console.WriteLine($"Message = {str}");
    }

    public void DisplayMessage()
    {
        Console.WriteLine($"New Message = {mystr}");
    }
}
