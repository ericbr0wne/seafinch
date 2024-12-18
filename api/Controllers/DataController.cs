using api.Services;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                var valueDtos = await _smhiService.GetValueDtosAsync();

                return Ok(valueDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching data", Details = ex.Message });
            }
        }
    }
}
