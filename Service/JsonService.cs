using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Service;

public static class JsonService
{
    private static HttpClient _client = new HttpClient();
    public static HttpStatusCode HttpPostRequest(string url, string body, string? token = null)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
        var response =  _client.PostAsync(url, content).Result;
        return response.StatusCode;
    }

    public static object HttpPostRequest(string url)
    {
        var response =  _client.PostAsync(url, null).Result;
        var result = response.Content.ReadAsStringAsync().Result;
        return result;
    }

    public static object HttpGetRequest(string url, string? token = null) 
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = _client.GetAsync(url).Result;
        var result = response.Content.ReadAsStringAsync().Result;
        return result;
    }
}