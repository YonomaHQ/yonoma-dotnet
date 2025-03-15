using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace yonoma
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api.yonoma.io/v1/";

        public ApiClient(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        // Asynchronous GET request
        public async Task<string> GetAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{endpoint}");
            
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            throw new Exception($"GET request failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
        }

        // Asynchronous POST request
        public async Task<string> PostAsync(string endpoint, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync($"{_baseUrl}{endpoint}", content);
            
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            throw new Exception($"POST request failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
        }
    }
}
