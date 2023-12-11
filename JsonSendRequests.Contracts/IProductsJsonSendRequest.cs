using System.Net;
using System.Security.Principal;
using Contracts;
using Shared.DataTransferObjects;

namespace JsonSendRequests.Contracts;

public interface IProductsJsonSendRequest : IJsonSendRequest<ProductDTO>
{
    HttpStatusCode CreateProduct(ProductDTO productDTO, string token);
    IEnumerable<ProductDTO>? GetProductsOnPage(int pageNumber, int pageSize);
}