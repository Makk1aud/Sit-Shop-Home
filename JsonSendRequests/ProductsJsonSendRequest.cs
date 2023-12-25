using System.Net;
using System.Text.Json;
using JsonSendRequests.Contracts;
using Service;
using Shared.DataTransferObjects;

namespace JsonSendRequests;

public class ProductsJsonSendRequest : IProductsJsonSendRequest
{
    private const string _baseUrl = "http://localhost:5194/api/products";
    public HttpStatusCode CreateProduct(ProductForManipulationDTO productDTO, string token)
    {
        string url = _baseUrl;
        string body = JsonSerializer.Serialize(productDTO);
        var status = JsonService.HttpPostRequest(url,body,token);
        return status;
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

    

    public IEnumerable<ProductDTO>? GetProductsOnPage(int pageNumber, int pageSize, int? minPrice = null, int? maxPrice = null, string? searchName = null, Guid? productCategoryId = null)
    {
        string url = _baseUrl +$"?PageNumber={pageNumber}&PageSize={pageSize}";
        if(minPrice != null)
            url += "&MinPrice=" + minPrice; 
        if(maxPrice != null)
            url += "&MaxPrice=" + maxPrice; 
        if(searchName != null)
            url += "&SearchName=" + searchName;
        if(productCategoryId != null)
            url += "&ProductCategoryId=" + productCategoryId;

        var response = JsonService.HttpGetRequest(url);
        var productList = JsonSerializer.Deserialize<IEnumerable<ProductDTO>>(response.ToString());
        return productList;   
    }
}