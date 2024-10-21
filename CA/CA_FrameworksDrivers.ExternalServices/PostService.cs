using CA_InterfaceAdapters.Adapters;
using CA_InterfaceAdapters.Adapters.Dto;
using System.Text.Json;

namespace CA_FrameworksDrivers.ExternalServices
{
    public class PostService : IExternalService<PostDto>
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions()
            { 
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IEnumerable<PostDto>> GetContentAsync()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<PostDto>>(data, _options);
        }
    }
}
