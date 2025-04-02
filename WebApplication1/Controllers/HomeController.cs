using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/home")]
    public class HomeController(IUserService usersService) : Controller
    {
        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] InsertUserDto userDto)
        {
            try
            {
                usersService.AddUser(userDto);
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
