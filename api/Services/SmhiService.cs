using api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace api.Services
{
    public class SmhiService
    {
        private readonly HttpClient _httpClient;

        public SmhiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SmhiResponse> GetDataAsync()
        {
            var url = "https://opendata-download-ocobs.smhi.se/api/version/1.0/parameter/3/station/33106/period/latest-day/data.json";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<SmhiResponse>(json);

            return data;
        }
    }

}