using CS_JOINS;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


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

var joinQuery = from per in lstPerson
                join role in lstRoles on per.IDRole equals role.ID
                select new
                {
                    FirstName = per.FirstName,
                    LastName = per.LastName,
                    Responsibility = role.RoleDescription
                };
Console.WriteLine("The Result of Join (Like Inner Join of Sql)");
Console.WriteLine("First Name \t\t Last Name\t\t Responsibility");
foreach (var item in joinQuery)
{
    Console.WriteLine(item.FirstName + "\t\t\t\t" + item.LastName + "\t\t\t" + item.Responsibility);
}
Console.WriteLine("Join Result Ends Here");

Method_Intersect();

static void Method_Intersect()
{
    Console.WriteLine("Intersect");
    int[] Seq1 = { 1, 1, 2, 3, 3 };
    int[] Seq2 = { 1, 3, 3, 4 };
    Seq1.Intersect(Seq2);
    foreach (var item in Seq1.Intersect(Seq2))
    {
        Console.WriteLine(item);
    }
    Console.WriteLine();
    Console.WriteLine("Ends Here");
}
Method_Union();

static void Method_Union()
{
    Console.WriteLine("Union");
    int[] Seq1 = { 1, 1, 3, 3 };
    int[] Seq2 = { 1, 2, 3, 4 };
    Seq1.Union(Seq2);
    foreach (var item in Seq1.Union(Seq2))
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("Ends Here");
}

Method_Except();

static void Method_Except()
{
    Console.WriteLine("Except");
    int[] Seq1 = { 1, 2, 3, 4 };
    int[] Seq2 = { 1, 1, 3, 3 };
    Seq1.Except(Seq2);
    foreach (var item in Seq1.Except(Seq2))
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("Ends Here");
}

CountWords.Main1();

static class CountWords
{
    public static void Main1()
    {
        string text = @"Historically, the world of data and the world of objects" +
          @" have not been well integrated. Programmers work in C# or Visual Basic" +
          @" and also in SQL or XQuery. On the one side are concepts such as classes," +
          @" objects, fields, inheritance, and .NET APIs. On the other side" +
          @" are tables, columns, rows, nodes, and separate languages for dealing with" +
          @" them. Data types often require translation between the two worlds; there are" +
          @" different standard functions. Because the object world has no notion of query, a" +
          @" query can only be represented as a string without compile-time type checking or" +
          @" IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +
          @" objects in memory is often tedious and error-prone.";

        string searchTerm = "data";

        //Convert the string into an array of words  
        string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

        // Create the query.  Use the InvariantCultureIgnoreCase comparision to match "data" and "Data"
        var matchQuery = from word in source
                         where word.Equals(searchTerm, StringComparison.InvariantCultureIgnoreCase)
                         select word;

        // Count the matches, which executes the query.  
        int wordCount = matchQuery.Count();
        Console.WriteLine("{0} occurrences(s) of the search term \"{1}\" were found.", wordCount, searchTerm);

        // Keep console window open in debug mode  
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}
/* Output:  
   3 occurrences(s) of the search term "data" were found.  
*/
 
public class Student
{
    public string First { get; set; }
    public string Last { get; set; }
    public int ID { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public List<int> Scores;
}

public class Teacher
{
    public string First { get; set; }
    public string Last { get; set; }
    public int ID { get; set; }
    public string City { get; set; }
}
class DataTransformations
{
    public static void Main2()
    {
        // Create the first data source.
        List<Student> students = new List<Student>()
        {
            new Student { First="Svetlana",
                Last="Omelchenko",
                ID=111,
                Street="123 Main Street",
                City="Seattle",
                Scores= new List<int> { 97, 92, 81, 60 } },
            new Student { First="Claire",
                Last="O’Donnell",
                ID=112,
                Street="124 Main Street",
                City="Redmond",
                Scores= new List<int> { 75, 84, 91, 39 } },
            new Student { First="Sven",
                Last="Mortensen",
                ID=113,
                Street="125 Main Street",
                City="Lake City",
                Scores= new List<int> { 88, 94, 65, 91 } },
        };

        // Create the second data source.
        List<Teacher> teachers = new List<Teacher>()
        {
            new Teacher { First="Ann", Last="Beebe", ID=945, City="Seattle" },
            new Teacher { First="Alex", Last="Robinson", ID=956, City="Redmond" },
            new Teacher { First="Michiyo", Last="Sato", ID=972, City="Tacoma" }
        };

        // Create the query.
        var peopleInSeattle = (from student in students
                               where student.City == "Seattle"
                               select student.Last)
                    .Concat(from teacher in teachers
                            where teacher.City == "Seattle"
                            select teacher.Last);

        Console.WriteLine("The following students and teachers live in Seattle:");
        // Execute the query.
        foreach (var person in peopleInSeattle)
        {
            Console.WriteLine(person);
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
/* Output:
    The following students and teachers live in Seattle:
    Omelchenko
    Beebe
 */

