using CS_ADONET_Disconnected;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("CS_ADONET_Disconnected.NET DIsconneted");
DataAccess dataAccess = new DataAccess();
//dataAccess.CreateDept();

dataAccess.Delete(80);
Console.ReadLine();
