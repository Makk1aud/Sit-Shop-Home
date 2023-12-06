using System.Net;
using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
namespace JsonSendRequests.Contracts;

public interface ICustomerJsonSendRequest : IJsonSendRequest<CustomerDTO>
{
    HttpStatusCode CreateCustomer(CustomerForManipulationDTO customerDto, DateOnly birth);
    void UpdateCustomer(Guid id, CustomerForManipulationDTO customerDto, DateOnly birth);
    CustomerDTO? FindCustomer(string login, string password);
    CustomerDTO? GetCustomer(Guid id, string token);
}