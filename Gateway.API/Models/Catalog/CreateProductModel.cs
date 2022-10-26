using System.ComponentModel.DataAnnotations;

namespace Gateway.API.Models.Catalog
{
    public class CreateProductModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Cost { get; set; }
    }
}
