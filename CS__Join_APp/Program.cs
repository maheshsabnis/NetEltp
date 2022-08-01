// See https://aka.ms/new-console-template for more information
using CS__Join_APp;

Console.WriteLine("Using JOINS");
List<Person> lstPerson = new List<Person> {
        new Person
        {
            ID = 1,
            IDRole = 1,
            LastName = "Sabnis",
            FirstName = "Mahesh"
        },
        new Person
        {
            ID = 2,
            IDRole = 2,
            LastName = "Pandit",
            FirstName = "Ajay"
        },
        new Person
        {
            ID = 3,
            IDRole = 2,
            LastName = "Patil",
            FirstName = "Sanjay"
        },
        new Person
        {
            ID = 4,
            IDRole = 3,
            LastName = "Puranik",
            FirstName = "Rajesh"
        },
        new Person
        {
            ID=5,
            IDRole=2,
            LastName="Deshpande",
            FirstName="Amol"
        }
};

List<Role> lstRoles = new List<Role>
{
    new Role { ID = 1, RoleDescription = "Manager" },
    new Role { ID = 2, RoleDescription = "Developer" }
};


var joinQuery = from per in lstPerson // Left Side Collection
                        // Join on Right Side Collection on a Matching
                        // Key for Let to Right
                join role in lstRoles on per.IDRole equals role.ID
                select new
                {
                    FirstName = per.FirstName,
                    LastName = per.LastName,
                    Responsibility = role.RoleDescription
                };

foreach (var item in joinQuery)
{
    Console.WriteLine(item.FirstName + " " + item.LastName  + "  " + item.Responsibility) ;
}


Console.ReadLine(); 
