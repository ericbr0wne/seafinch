using api.Models;
using api.DTOs;
using api.Mappers;
using Newtonsoft.Json;


namespace api.Services
{
    public class SmhiService
    {
        private readonly HttpClient _httpClient;

        public SmhiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ValueDto>> GetValueDtosAsync()
        {
            var url = "https://opendata-download-ocobs.smhi.se/api/version/1.0/parameter/3/station/33106/period/latest-day/data.json";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var smhiResponse = JsonConvert.DeserializeObject<SmhiResponse>(json);

            return ValueMapper.MapToDto(smhiResponse);
        }
    }
}
