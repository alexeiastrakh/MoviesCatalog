using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Models;
using MoviesCatalog.Models.DBContext;
using System.Linq;

namespace MoviesCatalog.Controllers.APIControllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MovieApiController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpGet("{movieId}/categories")]
        public IActionResult GetRelatedCategories(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }

            var categories = _context.FilmCategories
                .Where(fc => fc.FilmId == movieId)
                .Select(fc => fc.Category)
                .ToList();

            return Ok(categories);
        }

        [HttpPost("{movieId}/categories/{categoryId}")]
        public IActionResult AddCategory(int movieId, int categoryId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound("Movie not found.");
            }

            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                return NotFound("Category not found.");
            }

            var existingAssociation = _context.FilmCategories
                .FirstOrDefault(fc => fc.FilmId == movieId && fc.CategoryId == categoryId);
            if (existingAssociation != null)
            {
                return BadRequest("Category is already associated with the movie.");
            }

            var newAssociation = new FilmCategory { FilmId = movieId, CategoryId = categoryId };
            _context.FilmCategories.Add(newAssociation);
            _context.SaveChanges();

            return Ok("Category added successfully.");
        }

        [HttpDelete("{movieId}/categories/{categoryId}")]
        public IActionResult RemoveCategory(int movieId, int categoryId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound("Movie not found.");
            }

            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                return NotFound("Category not found.");
            }

            var existingAssociation = _context.FilmCategories
                .FirstOrDefault(fc => fc.FilmId == movieId && fc.CategoryId == categoryId);
            if (existingAssociation == null)
            {
                return BadRequest("Category is not associated with the movie.");
            }

            _context.FilmCategories.Remove(existingAssociation);
            _context.SaveChanges();

            return Ok("Category removed successfully.");
        }
    }
}
