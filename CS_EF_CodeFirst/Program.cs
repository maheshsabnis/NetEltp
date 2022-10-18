using CS_EF_CodeFirst.Models;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("EF Code First");

InfoDbContext ctx = new InfoDbContext();
//Category cat = new Category();
//cat.CategoryId = "Cat-001";
//cat.CategoryName = "IT";
//cat.BasePrice = 300;
//ctx.Categories.Add(cat);
//ctx.SaveChanges();

//Product prd = new Product();
//prd.ProductId = "Prd-001";
//prd.ProductName = "Laptop";
//prd.Manufacturer = "HP";
//prd.Price = 90000;
//prd.CategoryRowId = 1;
//ctx.Products.Add(prd);
//ctx.SaveChanges();


//List<Order> orders = new List<Order>()
//{
//	new Order() {OrderItem="Laptop", Price=231000 },
//	new Order() {OrderItem="Rouer", Price=10000 }
//};

//Customer cust = new Customer();
//cust.CustomerName = "Mahesh";
//cust.Orders = orders;

//ctx.Customers.Add(cust);
//ctx.Orders.AddRange(orders);



Movies movie = new Movies()
{
    // Id = 9,
    Name = "No Time For Die",
    ReleaseYear = 2021,
    BoxOfficeCollection = 90000,
    Category = "Spy",
    PlayDuration = 180
};
ctx.ProductionUnits.Add(movie);
ctx.SaveChanges();



Console.ReadLine(); 
