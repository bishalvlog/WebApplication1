using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] InsertUserDto userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Gender = userDto.Gender,
                ImageURL = userDto.ImageURL,
                RegisteredDate = userDto.RegisteredDate,
                IsActive = true
            };

            _context.Users.Add(user);

            _context.SaveChanges();

            return Ok("User Addede Successfully");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();

             return Ok(users);
        }

    }
}
