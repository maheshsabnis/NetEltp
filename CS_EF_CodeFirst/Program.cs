using CS_EF_CodeFirst.Models;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("EF Code First");

InfoDbContext ctx = new InfoDbContext();
Category cat = new Category();
cat.CategoryId = "Cat-001";
cat.CategoryName = "IT";
cat.BasePrice = 300;
ctx.Categories.Add(cat);
ctx.SaveChanges();

Product prd = new Product();
prd.ProductId = "Prd-001";
prd.ProductName = "Laptop";
prd.Manufacturer = "HP";
prd.Price = 90000;
prd.CategoryRowId = 1;
ctx.Products.Add(prd);
ctx.SaveChanges();


Console.ReadLine(); 
