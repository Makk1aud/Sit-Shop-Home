using Entities.Models;
using JsonSendRequests.Contracts;
using Shared.DataTransferObjects;
using Service;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Net;
using AutoMapper;
using Entities.Exceptions;
namespace JsonSendRequests;

public class CustomerJsonSendRequest : ICustomerJsonSendRequest
{
    private const string _baseUrl = "http://localhost:5194/api/customers";
    private const string _baseUrlAuth  = "http://localhost:5194/api/authorisation";
    public HttpStatusCode CreateCustomer(CustomerForManipulationDTO customerDto, DateOnly birth)
    {
        string url = _baseUrlAuth + $"/Registration?birth={birth.ToString()}";
        string body = JsonSerializer.Serialize(customerDto);
        var status = JsonService.HttpPostRequest(url, body);
        return status;
    }

    public void DeleteObject(Guid id, string token = null)
    {
        throw new NotImplementedException();
    }

    public CustomerDTO? FindCustomer(string login, string password, out string? token)
    {
        string url = _baseUrlAuth + $"/Login?email={login}&password={password}";
        var response = JsonService.HttpPostRequest(url);
        JsonNode jsonNode = JsonNode.Parse(response.ToString()!)!;
        CustomerDTO? customer;
        try
        {
            var customerId = jsonNode["customerId"].ToString();
            var customerToken = jsonNode["access_token"].ToString();
            token = customerToken.ToString();
            customer = GetCustomer(Guid.Parse(customerId), customerToken); 
        }
        catch (Exception e)
        {
            var message = jsonNode["message"].ToString();
            throw  new GenericNotFoundException<object>(message);
        } 
       return customer;
    }

    public IEnumerable<CustomerDTO> GetAllObject(string? token = null)
    {
        throw new NotImplementedException();
    }

    public CustomerDTO? GetCustomer(Guid id, string token)
    {
        string url = _baseUrl +$"/{id}";
        var response =  JsonService.HttpGetRequest(url,token);
        var customerDto = JsonSerializer.Deserialize<CustomerDTO>(response.ToString());
        return customerDto;
    }

    public CustomerDTO? GetObject(Guid id, string? token = null)
    {
        throw new NotImplementedException();
    }

    public void UpdateCustomer(Guid id, CustomerForManipulationDTO customerDto, DateOnly birth)
    {
        throw new NotImplementedException();
    }
}