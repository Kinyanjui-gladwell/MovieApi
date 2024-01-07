using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDBContext _context;

        public MovieController(MovieDBContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Movies>> Get()
        {
            return await _context.Movies.ToListAsync();
        }
        [HttpGet("id")]
        [ProducesResponseType(typeof(Movies), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Movies movies)
        {
            await _context.Movies.AddAsync(movies);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = movies.id }, movies);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateId (int id, Movies movies)
        {
            if (id != movies.id) { return BadRequest(); }
            _context.Entry(movies).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var movieToDelete = await _context.Movies.FindAsync( id);
            if (movieToDelete == null) { return NotFound(); }
            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
