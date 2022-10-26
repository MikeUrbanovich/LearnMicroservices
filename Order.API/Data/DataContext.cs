namespace Order.API.Data
{
    public class DataContext
    {
        public List<Order> Orders { get; set; }

        public DataContext()
        {
            Orders = new List<Order>
            {
                new() { Id = Guid.NewGuid(), Name = "Order1", Cost = 37 },
                new() { Id = Guid.NewGuid(), Name = "Order2", Cost = 41 },
                new() { Id = Guid.NewGuid(), Name = "Order3", Cost = 24 }
            };
        } 
    }
}
