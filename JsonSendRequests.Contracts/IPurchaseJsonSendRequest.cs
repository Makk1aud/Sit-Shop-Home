using System.Net;
using Contracts;
using Shared.DataTransferObjects;

namespace JsonSendRequests.Contracts;

public interface IPurchaseJsonSendRequest : IJsonSendRequest<PurchaseDTO>
{
    HttpStatusCode CreatePurchase(PurchaseForCreationDTO purchaseDto, Guid customerId, string token);
    IEnumerable<PurchaseDTO> GetAllCustomersPurchases(Guid customerId, string token);
}