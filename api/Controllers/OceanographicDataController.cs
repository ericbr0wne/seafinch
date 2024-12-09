using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OceanographicDataController : ControllerBase
    {

        private readonly HttpClient _httpClient;

        public OceanographicDataController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("ocean-data")]
        public async Task<IActionResult> GetOceanographicData()
        {
            string url = "https://opendata-download-ocobs.smhi.se/api/version/latest.json";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);
        }
        else
        {
            return BadRequest("Failed to fetch data from SMHI");
        }
        }
    }
}