using System.Xml.Serialization;
using api.Models;

namespace api.Services
{
    public class SmhiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SmhiService> _logger;

        public SmhiService(HttpClient httpClient, ILogger<SmhiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<SmhiData> GetOceanoParametersAsync()
        {
            try
            {
                string url = "https://opendata-download-ocobs.smhi.se/api"; // Hardcoded URL

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xmlContent = await response.Content.ReadAsStringAsync();
                var serializer = new XmlSerializer(typeof(SmhiData));

                // Create a new XmlSerializerNamespaces instance to handle XML namespaces
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.w3.org/2005/Atom"); // Add Atom namespace

                using (var reader = new StringReader(xmlContent))
                {
                    return (SmhiData)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                // Handle or log exceptions
                _logger.LogError(ex, "Error fetching or deserializing SMHI data.");
                throw new InvalidOperationException("Error fetching or deserializing SMHI data.", ex);
            }
        }

    }
}


/*     public async Task<OceanoParameters> GetOceanographyAsync()
    {
        try
        {
            string url = "https://opendata-download-ocobs.smhi.se/api";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var serializer = new XmlSerializer(typeof(OceanoParameters)); 
            return (OceanoParameters)serializer.Deserialize(stream);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching oceanography data.");
            throw;
        }
    } */
/* 
    public async Task<OceanoParameters?> GetOceanographyParameterAsync(string key)
    {
        try
        {
           var data = await GetOceanographyAsync();

            // Replace with actual property to filter by key
            return data.OceanoParameters.FirstOrDefault(p => p.Key == key);

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching oceanography parameter.");
            throw;
        }
    } */

