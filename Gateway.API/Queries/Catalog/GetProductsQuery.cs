using Gateway.API.Models.Catalog;
using MediatR;

namespace Gateway.API.Queries.Catalog
{
    public class GetProductsQuery: IRequest<IEnumerable<Product>>
    {
    }
}
