using Microsoft.AspNetCore.Mvc;
namespace ImagesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{


    [HttpPost]
    public IActionResult Post([FromForm] IFormFile file)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
        Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(stream);
        }
        return Ok();
    }

}