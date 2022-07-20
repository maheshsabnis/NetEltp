// See https://aka.ms/new-console-template for more information
using CS_Basic_Class;

Console.WriteLine("Simple Class");

Staff staff = new Staff();

StaffLogic logic = new StaffLogic();

var staffs = logic.GetAllStaff();

foreach (var s in staffs)
{
    Console.WriteLine($"{s.StaffId} {s.StaffName}");
}


staff = logic.GetStaffById(1);
Console.WriteLine($"{staff.StaffId} {staff.StaffName} {staff.DeptName}");

staff = new Staff() 
{
    StaffId = 1,
    StaffName = "AMar",
    Email = "amar@myhosp.com",
    DeptName = "Pathology",
    Gender = "Male",
    DateOfBirth = new DateTime(1976, 9, 6),
    StaffCategory = "Technician",
    Education = "Bsc. Path",
    ContatNo = 77474996
};

staffs =  logic.UpdateStaffInfo(1,staff);

foreach (var s in staffs)
{
    Console.WriteLine($"{s.StaffId} {s.StaffName}");
}

Console.ReadLine();    
