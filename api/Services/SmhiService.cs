using System.Text.Json; // Prefer System.Text.Json for performance
using api.Models;

namespace api.Services;
public class SmhiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<SmhiService> _logger;

    public SmhiService(HttpClient httpClient, ILogger<SmhiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<OceanographyParameter> GetOceanographyAsync()
    {
        try
        {
            string url = " https://opendata-download-ocobs.smhi.se/api";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonData = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Oceanography data fetched successfully.");

            var parameter = JsonSerializer.Deserialize<OceanographyParameter>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return parameter!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching oceanography data.");
            throw;
        }
    }

    public async Task<OceanographyParameter?> GetOceanographyParameterAsync(string key)
    {
        try
        {
            var parameter = await GetOceanographyAsync();

            if (parameter?.Key == key)
            {
                return parameter;
            }
            var matchingStationSet = parameter?.StationSet
                .FirstOrDefault(stationSet => stationSet.Key == key);

            if (matchingStationSet != null)
            {
                return parameter;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching oceanography parameter.");
            throw;
        }
    }

}
