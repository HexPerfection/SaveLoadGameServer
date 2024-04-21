using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace SaveLoadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        // DELETE api/<DeleteController>
        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.json");

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    return Ok("File deleted successfully.");
                }
                else
                {
                    return NotFound("File not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error deleting file: {ex}");

                // Return a generic error message to the client
                return StatusCode(500, "An unexpected error occurred while deleting the file.");
            }
        }
    }
}
