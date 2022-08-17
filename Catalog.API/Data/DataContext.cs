namespace Catalog.API.Data
{
    public class DataContext
    {
        public List<Product> Products { get; set; }

        public DataContext()
        {
            Products = new List<Product>
            {
                new() { Id = Guid.NewGuid(), Name = "Tom", Cost = 37 },
                new() { Id = Guid.NewGuid(), Name = "Bob", Cost = 41 },
                new() { Id = Guid.NewGuid(), Name = "Sam", Cost = 24 }
            };
        } 
    }
}
