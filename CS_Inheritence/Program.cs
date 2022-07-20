using CS_Inheritence.Models;
using CS_Inheritence.Logic;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Inheritence");
 
DoctorLogic logic = new DoctorLogic();

var doc1 = new Doctor()
{
    StaffId = 1,
    StaffName = "Dr.No",
    Email = "drno@villian.com",
    ContactNo = 999999,
    Education = "M.B.B.S",
    ShiftStartTime = 10,
    ShiftEndTime = 19,
    Specialization = "Heart",
    Fees = 3456,
    MaxPatientsPerDay = 50
};
doc1.SetBasicPay(10000);

logic.Register(doc1);



logic.Register(new Doctor()
{
    StaffId = 2,
    StaffName = "Dr.DoLittle",
    Email = "drno@Movie.com",
    ContactNo = 998899,
    Education = "M.B.B.S",
    ShiftStartTime = 8,
    ShiftEndTime = 20,
    Specialization = "Cancer",
    Fees = 6456,
    MaxPatientsPerDay = 10
});

var doctors = logic.Get();
// Convert the List<Doctor> inso JSON Text
var doctorsJSONData = JsonSerializer.Serialize(doctors);
Console.WriteLine($"Data \n {doctorsJSONData}");
Console.ReadLine(); 

