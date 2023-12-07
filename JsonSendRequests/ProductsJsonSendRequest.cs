using System.Net;
using JsonSendRequests.Contracts;
using Shared.DataTransferObjects;

namespace JsonSendRequests;

public class ProductsJsonSendRequest : IProductsJsonSendRequest
{
    public HttpStatusCode CreateProduct(ProductDTO productDTO, string token)
    {
        return HttpStatusCode.Created;
    }

    public void DeleteObject(Guid id, string? token = null)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductDTO>? GetAllObject(string? token = null)
    {
        throw new NotImplementedException();
    }

    public ProductDTO? GetObject(Guid id, string? token = null)
    {
        throw new NotImplementedException();
    }
}