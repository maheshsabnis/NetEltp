using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_UsingStatic.Entities;
using CS_UsingStatic.Database;

namespace CS_UsingStatic.Models
{
    public abstract class StaffLogic
    {
        public abstract void RegisterStaff(Staff statff);
        public abstract List<Staff> GetStatffs();
        
    }

    public class DoctorLogic : StaffLogic
    {
        public override void RegisterStaff(Staff statff)
        {
            if (HospitalDbStore.GlobalStaffStore != null)
            { 
                HospitalDbStore.GlobalStaffStore.Add(statff);
            }
        }
        public override List<Staff> GetStatffs()
        {
            return HospitalDbStore.GlobalStaffStore;
        }
    }

    public class NurseLogic : StaffLogic
    {
        public override void RegisterStaff(Staff statff)
        {
            if (HospitalDbStore.GlobalStaffStore != null)
            {
                HospitalDbStore.GlobalStaffStore.Add(statff);
            }
        }
        public override List<Staff> GetStatffs()
        {
            return HospitalDbStore.GlobalStaffStore;
        }
    }

}
