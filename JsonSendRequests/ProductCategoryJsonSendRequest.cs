using System.Text.Json;
using Entities.Models;
using JsonSendRequests.Contracts;
using Service;
using Shared.DataTransferObjects;

namespace JsonSendRequests;

public class ProductCategoryJsonSendRequest : IProductCategoryJsonSendRequest
{
    private const string _baseUrl = "http://localhost:5194/api/productscategories";
    public void DeleteObject(Guid id, string? token = null)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductCategoryDTO>? GetAllObject(string? token = null)
    {
        string url = _baseUrl;
        var response = JsonService.HttpGetRequest(url);
        var productCategories = JsonSerializer.Deserialize<IEnumerable<ProductCategoryDTO>>(response.ToString());
        return productCategories;
    }

    public ProductCategoryDTO? GetObject(Guid id, string? token = null)
    {
        throw new NotImplementedException();
    }
}