using System.IO;
using CS_FirstFile.Operations;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using Files");
try
{
    string fileName = @"c:\Coditas\Files\Info.txt";
    FileOperation operation = new FileOperation();
    
    operation.CreateFile(fileName);

    operation.WriteFile(fileName, "The FIrst File CReated using the File Class");
    
    var dataFromFile = operation.ReadFile(fileName);
    
    Console.WriteLine($"Initial Data = " +
        $"{dataFromFile}");
    
    operation.AppendFile(fileName, "THe Next Data for APpend");

    dataFromFile = operation.ReadFile(fileName);

    Console.WriteLine($"Data After Append = " +
        $"{dataFromFile}");

    string[] data = new string[] {
      "Line 1","Line 2","Line 3","Line 4"
    }; 
    operation.AppendFile(fileName, data);

    dataFromFile = operation.ReadFile(fileName);

    Console.WriteLine($"Data After Appending Array = " +
       $"{dataFromFile}");


    operation.MakeCopy(fileName, @"c:\Coditas\Files\DEstFile.txt");

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


Console.ReadLine();
