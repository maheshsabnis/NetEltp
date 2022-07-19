using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Basic_Class
{
    /// <summary>
    /// Pure ENtity Class or DTO or VO
    /// </summary>
    public class Staff
    {
        // Private Data Members 
        private int _StaffId;
        public int StaffId
        {
            get { return _StaffId; }
            set {
                if (value < 0)
                {
                    // Validation Logic
                }
                else
                {
                    _StaffId = value;
                }
               }
        }
        private string _StaffName;
        public string StaffName
        {
            get { return _StaffName; }
            set { _StaffName = value; }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _DeptName;
        public string DeptName
        {
            get { return _DeptName; }
            set
            {
                _DeptName = value;
            }
        }
        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
            }
        }
        private DateTime _DateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                _DateOfBirth = value;
            }
        }
        private string _StaffCategory;
        public string StaffCategory
        {
            get { return _StaffCategory; }
            set { _StaffCategory = value; }
        }
        private string _Education;
        public string Education
        {
            get { return _Education; }
            set { _Education = value; }
        }
        private int _ContactNo;
        public int ContatNo
        {
            get { return _ContactNo; }
            set
            {
                _ContactNo = value;
            }
        }
    }


    
}
