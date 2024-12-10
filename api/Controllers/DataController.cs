using api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class SmhiController : ControllerBase
    {

        private readonly SmhiService _smhiService;

        public SmhiController(SmhiService smhiService)
        {
            _smhiService = smhiService;
        }

        [HttpGet("data")]
        public async Task<IActionResult> GetSmhiData()
        {
            try
            {
                // Get the data from the service
                var data = await _smhiService.GetDataAsync();
                return Ok(data); // Return the data as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching data", Details = ex.Message });
            }
        }
    }

}
