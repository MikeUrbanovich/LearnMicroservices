using Gateway.API.Models.Catalog;
using MediatR;

namespace Gateway.API.Commands.Catalog
{
    public class CreateProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }
    }
}
