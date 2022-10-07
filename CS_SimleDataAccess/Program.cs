using CS_SimleDataAccess.Models;
using CS_SimleDataAccess.DataAccess;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("USing ADO.NET");
try
{
    CategoryDbAccess categoryDbAccess = new CategoryDbAccess();

    var categories = categoryDbAccess.GetRecords();
    PrintData(categories);
    Console.WriteLine();
    var cat = new Category()
    {
         CategoryId = 10005,
         CategoryName= "Healthcare (Infants)",
         BasePrice = 8000
    };
    //categoryDbAccess.CreateRecord(cat);

    //categoryDbAccess.UpdateRecord(cat.CategoryId,cat);
    categoryDbAccess.DeleteRecord(cat.CategoryId);


    categories = categoryDbAccess.GetRecords();
    PrintData(categories);
}
catch (Exception ex)
{
    Console.WriteLine($"Error Occurred {ex.Message}");
}
Console.ReadLine();

static void PrintData(IEnumerable<Category> categories)
{
    foreach (var cat in categories)
    {
        Console.WriteLine($"{cat.CategoryId} {cat.CategoryName} {cat.BasePrice}");
    }
}