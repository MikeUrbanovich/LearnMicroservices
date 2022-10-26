using System.Net.Mime;
using System.Text;
using Gateway.API.Models.Catalog;
using MediatR;
using Newtonsoft.Json;

namespace Gateway.API.Commands.Catalog
{
    public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CreateProductCommandHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient("CatalogApi");

            var newProductContent = new StringContent(
                JsonConvert.SerializeObject(request.Product),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);

            var response = await httpClient.PostAsync("/api/product/addproduct", newProductContent);

            if (response.IsSuccessStatusCode)
            {
                return request.Product;
            }

            return null;
        }
    }
}
