using System.Net;
using System.Text.Json;
using JsonSendRequests.Contracts;
using Service;
using Shared.DataTransferObjects;

namespace JsonSendRequests;

public class PurchaseJsonSendRequest : IPurchaseJsonSendRequest
{
    private const string _baseUrl = "http://localhost:5194/api/customers";
    public HttpStatusCode CreatePurchase(PurchaseForCreationDTO purchaseDto,Guid customerId, string token)
    {
        string url = _baseUrl + '/' + customerId.ToString() + "/purchases";
        string body = JsonSerializer.Serialize(purchaseDto);
        var status = JsonService.HttpPostRequest(url,body,token);
        return status;
    }

    public void DeleteObject(Guid id, string? token = null)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PurchaseDTO>? GetAllObject(string? token = null)
    {
        throw new NotImplementedException();
    }

    public PurchaseDTO? GetObject(Guid id, string? token = null)
    {
        throw new NotImplementedException();
    }
}