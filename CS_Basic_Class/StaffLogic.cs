using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Basic_Class
{
    public class StaffLogic
    {
       /// <summary>
       /// In-Memory Collection
       /// </summary>
        List<Staff> staffs;

        public StaffLogic()
        {
            // Lets have some DEfault Data
            // COllection Initializer (C# 3.0)
            staffs = new List<Staff>()
            { 
                // Object Initializer, provide the object has public properties
               new Staff() {StaffId=1,StaffName="Ajay",Email="ajay@myhosp.com", DeptName="Cancer",Gender="Male",DateOfBirth= new DateTime(1976, 8, 7),StaffCategory="Doctor",Education="MBBS",ContatNo=7747474 },

                new Staff() {StaffId=2,StaffName="KIshan",Email="kishan@myhosp.com", DeptName="Heart",Gender="Male",DateOfBirth= new DateTime(1976, 9, 7),StaffCategory="Brother",Education="DMLT",ContatNo=7747499 },

            };
        }

        // Public Methods or BEhavior
        public List<Staff> RegisterNewStaff(Staff staff)
        {
            staffs.Add(staff);
            return staffs;
        }
        public List<Staff> UpdateStaffInfo(int id, Staff staff)
        {
            if (id == staff.StaffId)
            {
                foreach (var item in staffs)
                {
                    if (item.StaffId == staff.StaffId)
                    {
                        // Update
                        item.StaffName = staff.StaffName;
                        item.Email = staff.Email;
                        item.DeptName = staff.DeptName;
                        item.StaffCategory = staff.StaffCategory;
                        item.ContatNo = staff.ContatNo;
                        item.Education = staff.Education;
                        item.DateOfBirth = staff.DateOfBirth;
                        item.Gender = staff.Gender;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Record Not Found");
            }
            return staffs;
        }
        public List<Staff> DeleteStaff(int id)
        {
            // Logic for Delete
            // 1. Serach the object
            Staff searchefStaff = null;
            foreach (var item in staffs)
            {
                if (item.StaffId == id)
                {
                    searchefStaff = item;
                    break;
                }
            }
            // 2. Delete
            staffs.Remove(searchefStaff);
            return staffs;
        }
        public List<Staff> GetAllStaff()
        {
            return staffs;
        }
        public Staff GetStaffById(int id)
        {
            // Search based on if if dounf return else return null
            return new Staff();
        }
    }
}
