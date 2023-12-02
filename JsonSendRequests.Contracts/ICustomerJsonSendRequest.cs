using Contracts;
using Entities.Models;
using Shared;
using Shared.DataTransferObjects;
namespace JsonSendRequests.Contracts;

public interface ICustomerJsonSendRequest : IJsonSendRequest<Customer>
{
    void CreateCustomer(CustomerForManipulationDTO customerDto, DateOnly birth);
    void UpdateCustomer(Guid id, CustomerForManipulationDTO customerDto, DateOnly birth);
}