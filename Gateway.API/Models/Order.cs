namespace Gateway.API.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }
    }
}
