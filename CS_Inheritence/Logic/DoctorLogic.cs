using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Inheritence.Models;

namespace CS_Inheritence.Logic
{
    public class DoctorLogic
    {
        List<Doctor> Doctors = new List<Doctor> ();

        //public DoctorLogic()
        //{
        //    Doctors = new List<Doctor>();
        //}

        public List<Doctor> Register(Doctor doctor)
        {
            Doctors.Add(doctor);
            return Doctors;
        }
        public List<Doctor> Get()
        {
            return Doctors;
        }
    }
}
