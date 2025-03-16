using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public static List<Item> _items = new List<Item>
        {
            new Item {Id = Guid.NewGuid(), Name = "Bishal" , Description = "Dotnet tutor"},
            new Item {Id = Guid.NewGuid(), Name =" student", Description =" dear student"}
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_items);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);

            if (item == null)  return NotFound();

            return Ok(item);

        }

        [HttpPost]
        public IActionResult Create([FromBody] Item item)
        {
            if(item == null) return BadRequest("invalid data");

            item.Id = Guid.NewGuid();

            _items.Add(item);

            return CreatedAtAction(nameof(GetById), new { id   = item.Id}, item);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update( Guid id, [FromBody] Item updatedItem)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);

            if(item == null) return NotFound("data not fount");

            item.Name = updatedItem.Name;

            item.Description = updatedItem.Description;

            return Ok(item);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete (Guid id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);

            if (item == null) return NotFound("Data not found");

            _items.Remove(item);
            return Ok(new
            {
                message = " item deleted successfully",
                deletedItem = item,
                HttpStatusCode = (int)HttpStatusCode.OK
            });
        }

        public class Item
        {
            public Guid Id { get; set; }

            [Required(ErrorMessage = "Name is require !")]
            public string Name { get; set; }

            public string Description { get; set; }
        }
    }
}
