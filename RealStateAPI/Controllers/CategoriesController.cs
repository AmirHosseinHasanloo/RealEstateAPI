using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealStateAPI.Context;
using RealStateAPI.Models;

namespace RealStateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ApiDbContext _context;

        public CategoriesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Category.ToList());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Category.Find(id));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (category != null)
            {
                _context.Category.Add(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "object successfully added.");
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            if (_context.Category.Any(c => c.Id == id))
            {
                _context.Category.Update(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Category updated successfully.");
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Category.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Category deleted successfully.");
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
