using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_JOINS
{
    public class Person
    {
        int _id;
        int _idRole;
        string _lastName;
        string _firstName;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int IDRole
        {
            get { return _idRole; }
            set { _idRole = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
    }

    public class Role
    {
        int _id;
        string _roleDescription;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string RoleDescription
        {
            get { return _roleDescription; }
            set { _roleDescription = value; }
        }
    }
}
