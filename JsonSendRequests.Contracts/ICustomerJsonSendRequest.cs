using System.Net;
using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
namespace JsonSendRequests.Contracts;

public interface ICustomerJsonSendRequest : IJsonSendRequest<Customer>
{
    HttpStatusCode CreateCustomer(CustomerForManipulationDTO customerDto, DateOnly birth);
    void UpdateCustomer(Guid id, CustomerForManipulationDTO customerDto, DateOnly birth);
    Customer? FindCustomer(string login, string password);
    Customer? GetCustomer(Guid id, string token);
}