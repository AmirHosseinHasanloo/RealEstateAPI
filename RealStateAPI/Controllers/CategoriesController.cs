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
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_context.Categories.ToList());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Categories.Find(id));
        }

        [HttpGet("[action]")]
        public IActionResult SortCategories()
        {
            return Ok(_context.Categories.OrderByDescending(c => c.Name).ToList());
        }

        // POST api/<CategoriesController>
        [HttpPost("Add")]
        public IActionResult Post([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "object successfully added.");
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            if (_context.Categories.Any(c => c.Id == id))
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Category updated successfully.");
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Category deleted successfully.");
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}