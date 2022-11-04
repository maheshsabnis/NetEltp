namespace APIApps.Models
{
    public class ResponseObject
    {
        public List<Category>? Categories { get; set; }
        public List<Product>? Products { get; set; }
        public Category? Category { get; set; }
        public Product? Product { get; set; }
        public int? StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
