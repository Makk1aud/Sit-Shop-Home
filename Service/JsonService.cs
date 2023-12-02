using System.Net.Http.Json;
using System.Text;

namespace Service;

public static class JsonService
{
    private static HttpClient _client = new HttpClient();
    public static void HttpPostRequest(string url, string body)
    {
        StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
        var response =  _client.PostAsync(url, content).Result;
        Console.WriteLine(response.Content.ToString());
      
    }
}