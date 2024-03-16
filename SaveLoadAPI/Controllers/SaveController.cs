using Microsoft.AspNetCore.Mvc;

namespace SaveLoadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SaveController : ControllerBase
    {
        // POST api/<SaveController>
        [HttpPost]
        public IActionResult Post([FromBody] dynamic jsonData)
        {
            try
            {
                string jsonString = jsonData.ToString();
                string fileName = "data.json";
                // Save JSON data to a file

                System.IO.File.WriteAllText(fileName, jsonString);
                
                return Ok("Data saved successfully.");
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error saving data: {ex.Message}");

            }

        }

    }

}
