// See https://aka.ms/new-console-template for more information
Console.WriteLine("USing Static Modifiers");

StaffLogic logic = new DoctorLogic();

Doctor d1 = new Doctor()
{
    StaffId = 101,
    StaffName = "Dr. No",
    Education = "M.B.B.S",
    Specilization = "General Physician"
};
logic.RegisterStaff(d1);

Doctor d2 = new Doctor()
{
    StaffId = 102,
    StaffName = "Dr. Deng",
    Education = "B.H.M.S.",
    Specilization = "Heart"
};
logic.RegisterStaff(d2);


logic = new NurseLogic();
Nurse n1 = new Nurse()
{
     StaffId = 103,
     StaffName= "Mr. Bee",
     Experience = 10
};

logic.RegisterStaff(n1);

var Staffs = logic.GetStatffs();

Console.WriteLine();
Console.WriteLine("Statff are as below");

Console.WriteLine(JsonSerializer.Serialize(Staffs));


Console.ReadLine(); 
