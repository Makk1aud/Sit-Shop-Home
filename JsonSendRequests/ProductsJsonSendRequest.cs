using System.Net;
using System.Text.Json;
using JsonSendRequests.Contracts;
using Service;
using Shared.DataTransferObjects;

namespace JsonSendRequests;

public class ProductsJsonSendRequest : IProductsJsonSendRequest
{
    private const string _baseUrl = "http://localhost:5194/api/products";
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
        string url = _baseUrl + "/" + id.ToString();
        var response = JsonService.HttpGetRequest(url, token);
        var product = JsonSerializer.Deserialize<ProductDTO>(response.ToString());
        return product;
    }

    public IEnumerable<ProductDTO>? GetProductsOnPage(int pageNumber, int pageSize)
    {
        string url = _baseUrl +$"?PageNumber={pageNumber}&PageSize={pageSize}";
        var response = JsonService.HttpGetRequest(url);
        var productList = JsonSerializer.Deserialize<IEnumerable<ProductDTO>>(response.ToString());
        return productList;
    }
}