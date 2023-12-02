using Entities.Models;
using JsonSendRequests.Contracts;
using Shared.DataTransferObjects;
using Service;
using System.Text.Json;
namespace JsonSendRequests;

public class CustomerJsonSendRequest : ICustomerJsonSendRequest
{
    private const string _baseUrl = "http://localhost:5194/api/customers";
    public void CreateCustomer(CustomerForManipulationDTO customerDto, DateOnly birth)
    {
        string url = _baseUrl + $"?birth={birth.ToString()}";
        string body = JsonSerializer.Serialize(customerDto);
        System.Console.WriteLine(body);
        JsonService.HttpPostRequest(url, body);
    }

    public void DeleteObject(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetAllObject()
    {
        throw new NotImplementedException();
    }

    public Customer GetObject(Guid id)
    {
        throw new NotImplementedException();
    }

    public void UpdateCustomer(Guid id, CustomerForManipulationDTO customerDto, DateOnly birth)
    {
        throw new NotImplementedException();
    }
}