using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Models;

namespace api.Controllers;
[Route("api")]
public class OceanographyController : ControllerBase
{
    private readonly SmhiService _smhiService;
    private readonly ILogger<OceanographyController> _logger;

    public OceanographyController(SmhiService smhiService, ILogger<OceanographyController> logger)
    {
        _smhiService = smhiService;
        _logger = logger;
    }



    [HttpGet("oceano")]
    public async Task<IActionResult> GetOceanoParameters()
    {
        try
        {
            var oceanoParameters = await _smhiService.GetOceanoParametersAsync();
            return Ok(oceanoParameters);
        }
        catch (Exception ex)
        {
            // Log error (optional)
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}



/*     [HttpGet("oceano")]
    public async Task<IActionResult> GetOceanography()
    {
        try
        {
            var data = await _smhiService.GetOceanographyAsync();
            return Ok(data);
        }
        catch (HttpRequestException)
        {
            return BadRequest("Failed to fetch data from SMHI");
        }
    } */
/* 
    [HttpGet("parameter/{key}")]
    public async Task<IActionResult> GetOceanographyParameter(string key)
    {
        try
        {
            var parameter = await _smhiService.GetOceanographyParameterAsync(key);

            if (parameter == null)
            {
                _logger.LogWarning("Parameter with key {key} not found.", key);
                return NotFound("Parameter not found.");
            }

            return Ok(parameter);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching oceanography parameter.");
            return BadRequest($"Failed to fetch data from SMHI: {ex.Message}");
        }
    } */
