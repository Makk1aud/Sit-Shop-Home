using System.Text.Json;
using JsonSendRequests.Contracts;
using Service;
using Shared.DataTransferObjects;

namespace JsonSendRequests;

public class GenderJsonSendRequest : IGenderJsonSendRequest
{
    private const string _baseURL = "http://localhost:5194/api/genders";
    public void DeleteObject(Guid id, string? token = null)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<GenderDTO>? GetAllObject(string? token = null)
    {
        string url = _baseURL;
        var response = JsonService.HttpGetRequest(url);
        var genderList = JsonSerializer.Deserialize<IEnumerable<GenderDTO>>(response.ToString());
        return genderList;
        
    }

    public GenderDTO? GetObject(Guid id, string? token = null)
    {
        throw new NotImplementedException();
    }
}