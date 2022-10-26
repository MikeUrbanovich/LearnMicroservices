using Gateway.API.Models.Catalog;
using MediatR;
using Newtonsoft.Json;

namespace Gateway.API.Queries.Catalog
{
    public class GetProductsQueryHandler: IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GetProductsQueryHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var serializer = new JsonSerializer();
            var httpClient = _httpClientFactory.CreateClient("CatalogApi");

            IEnumerable<Product> product = null;
            var response = await httpClient.GetAsync("/api/product/getproducts");

            if (response.IsSuccessStatusCode)
            {
                var contentStream = await response.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(contentStream);
                using var jsonReader = new JsonTextReader(streamReader);

                product = serializer.Deserialize<IEnumerable<Product>>(jsonReader);
            }

            return product;
        }
    }
}
