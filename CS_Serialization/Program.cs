using CS_Serialization;
using System.Runtime.Serialization;
// Binary Formatter for Binary Serialization
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Demo Serialization");




// Serialize();
// DeSerialize();

JsonSerializerMethod();

static void Serialize()
{
    Employee emp = new Employee() { EmpNo = 101, EmpName = "Mahesh" };
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    // CReate a  File
    Stream fs = new FileStream(@"c:\Coditas\Files\Emp.dat", FileMode.CreateNew);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
    binaryFormatter.Serialize(fs, emp);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

    Console.WriteLine("The Object is Serialized");
    fs.Close(); // CLose the File
    fs.Dispose(); // Release the Object

}


static void DeSerialize()
{
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    // OPen a  File for Reading
    Stream fs = new FileStream(@"c:\Coditas\Files\Emp.dat", FileMode.Open);

    Employee emp = (Employee)binaryFormatter.Deserialize(fs);

    Console.WriteLine($"EmpNo = {emp.EmpNo} and EmpName = {emp.EmpName}");

    Console.WriteLine("The Object is DeSerialized");
    fs.Close(); // CLose the File
    fs.Dispose(); // Release the Object
}


static void JsonSerializerMethod()
{
    Employee emp = new Employee() { EmpNo = 101, EmpName = "Mahesh" };
    Stream fs = new FileStream(@"c:\Coditas\Files\Emp.json", FileMode.CreateNew);
    JsonSerializer.Serialize(fs, emp);
    fs.Close(); // CLose the File
    fs.Dispose(); // Release the Object
}




