using System.Net.Http;
using System.Net.Http.Headers;

namespace MultiApiDemoLibrary;

public class ApiHelper
{
    public static HttpClient ApiClient { get; set; }

    public static void InitializeClient()
    {
        ApiClient = HttpClientFactory.Create();
        ApiClient.DefaultRequestHeaders.Accept.Clear();
        ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}
