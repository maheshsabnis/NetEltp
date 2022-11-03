// See https://aka.ms/new-console-template for more information
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

Console.WriteLine("COnsume The REST API");
Console.WriteLine("Press a Key when Service Starts");
Console.ReadLine();    
HttpClient client = new HttpClient();

var cats = await client.GetFromJsonAsync<List<Category>>("https://localhost:7083/api/Category");

foreach (var item in cats)
{
    Console.WriteLine($"{item.CategoryId} {item.CategoryName} {item.BasePrice}");
}

Console.WriteLine("POSTA");
var catNew = new Category()
{
     CategoryId=1010, CategoryName="Shose", BasePrice=4444
};
var response = await client.PostAsJsonAsync<Category>("https://localhost:7083/api/Category", catNew);
// resonse.Content, will return HttpContext Object
// response.Content.ReadAsStringAsync(), will provde actual Details in Response Message
Console.WriteLine(await response.Content.ReadAsStringAsync());

var response1 = await client.PutAsJsonAsync<Category>($"https://localhost:7083/api/Category/{catNew.CategoryId}", catNew);

var response2 = await client.DeleteAsync($"https://localhost:7083/api/Category/{catNew.CategoryId}");


Console.ReadLine();

public partial class Category
{
    public Category()
    {
        Products = new HashSet<Product>();
    }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public decimal BasePrice { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}

public partial class Product
{
    public int ProductUniqueId { get; set; }
    public string ProductId { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public string Manufacturer { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
