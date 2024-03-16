using Microsoft.AspNetCore.Mvc;

namespace SaveLoadAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoadController : ControllerBase
    {
        private readonly ILogger<LoadController> _logger;
        public LoadController(ILogger<LoadController> logger)

        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
                if (!System.IO.File.Exists(filePath))

                {
                    return NotFound("File not found.");
                }
                string jsonContent = await System.IO.File.ReadAllTextAsync(filePath);
                return Ok(jsonContent);

            }
            catch (Exception ex)

            {
                _logger.LogError(ex, "Error loading data.");
                return BadRequest("Error loading data.");
            }
        }
    }
}
