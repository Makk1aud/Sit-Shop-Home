using System.Net;
using System.Security.Principal;
using Contracts;
using Shared.DataTransferObjects;

namespace JsonSendRequests.Contracts;

public interface IProductsJsonSendRequest : IJsonSendRequest<ProductDTO>
{
    HttpStatusCode CreateProduct(ProductForManipulationDTO productDTO, string token);
    IEnumerable<ProductDTO>? GetProductsOnPage(int pageNumber, int pageSize,
                                               int? minPrice = null,
                                               int? maxPrice = null,
                                               string? searchName = null,
                                               Guid? productCategoryId = null);
}